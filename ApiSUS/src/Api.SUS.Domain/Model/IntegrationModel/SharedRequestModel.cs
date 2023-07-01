using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.SUS.Domain.Model.IntegrationModel
{
    public class SharedRequestModel
    {
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }

        [JsonProperty(PropertyName = "successful")]
        public int Successful { get; set; }

        [JsonProperty(PropertyName = "skipped")]
        public int Skipped { get; set; }

        [JsonProperty(PropertyName = "failed")]
        public int Failed { get; set; }
    }
}
