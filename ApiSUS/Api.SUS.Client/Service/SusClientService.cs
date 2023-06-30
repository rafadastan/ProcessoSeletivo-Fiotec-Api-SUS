using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.SUS.Client.Contracts;
using Api.SUS.Domain.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Api.SUS.Client.Dto;

namespace Api.SUS.Client.Service
{
    public class SusClientService : ISusClientService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly NotificationContext _notificationContext;
        private readonly string _aliasConfig;

        public SusClientService(
            HttpClient httpClient,
            IConfiguration configuration,
            NotificationContext notificationContext)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _notificationContext = notificationContext;

            _aliasConfig = $"{configuration["IntegracaoSus:Alias"]}";
            if (!string.IsNullOrWhiteSpace(_aliasConfig))
                _httpClient.BaseAddress = new Uri(_httpClient.BaseAddress!, $"{_aliasConfig}/");
        }

        public async Task<List<ResponseSusDto>?> GetInformationAsync()
        {
            var responseSus = new List<ResponseSusDto>();

            ConfigurationAddHeaders();

            var size = new RequestSizeDto
            {
                Size = 1000
            };

            using var response = await _httpClient.PostAsync(_aliasConfig, CreateStringContent(size));

            var ret = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                _notificationContext.AddNotification(response.ReasonPhrase!,response.StatusCode.ToString());
            }

            if (ret != null! && response.IsSuccessStatusCode)
            {
                responseSus = JsonConvert.DeserializeObject<List<ResponseSusDto>>(ret);

                return responseSus;
            }

            return _notificationContext.HasNotifications ? null : responseSus;
        }

        private void ConfigurationAddHeaders()
        {
            _httpClient.DefaultRequestHeaders.Add("Accept", "ApplicationJson");
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("ContentType", "ApplicationJson");
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", GetHeadersAuthRyver());
        }

        private StringContent CreateStringContent<T>(T dto)
        {
            return new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
        }

        private string GetHeadersAuthRyver() =>
            _configuration["IntegracaoSus:SecretKey"];
    }
}
