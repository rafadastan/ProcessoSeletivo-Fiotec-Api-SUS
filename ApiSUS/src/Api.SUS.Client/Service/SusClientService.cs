using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Domain.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Api.SUS.Domain.Contracts.Client;
using Api.SUS.Domain.Model.IntegrationModel;

namespace Api.SUS.Client.Service
{
    public class SusClientService : ISusClientService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly NotificationContext _notificationContext;
        private readonly string _aliasConfig;
        private readonly int _size;

        public SusClientService(
            HttpClient httpClient,
            IConfiguration configuration,
            NotificationContext notificationContext)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _notificationContext = notificationContext;

            _aliasConfig = $"{configuration["IntegracaoSus:Alias"]}";
            _size = int.Parse(configuration["IntegracaoSus:Size"]);
        }

        public async Task<MainRequestDto> GetInformationAsync()
        {
            var responseSus = new MainRequestDto();

            ConfigurationAddHeaders();

            var size = new RequestSizeModel
            {
                Size = _size
            };
            
            using var response = await _httpClient.PostAsync(_aliasConfig, CreateStringContent(size));

            var ret = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                _notificationContext.AddNotification(response.ReasonPhrase!,response.StatusCode.ToString());
            }

            if (ret != null! && response.IsSuccessStatusCode)
            {
                responseSus = JsonConvert.DeserializeObject<MainRequestDto>(ret)!;

                return responseSus;
            }

            return (_notificationContext.HasNotifications ? null : responseSus)!;
        }

        private void ConfigurationAddHeaders()
        {
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("ContentType", "application/json");
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "application/json");
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", GetHeadersAuthSus());
        }

        private StringContent CreateStringContent<T>(T dto)
        {
            return new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
        }

        private string GetHeadersAuthSus() =>
            _configuration["IntegracaoSus:SecretKey"];
    }
}
