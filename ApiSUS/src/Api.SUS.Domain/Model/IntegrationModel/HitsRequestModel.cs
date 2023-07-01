using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Api.SUS.Domain.Model.IntegrationModel
{
    public class HitsRequestModel
    {
        [JsonProperty(PropertyName = "total")]
        public TotalRequestModel TotalRequestModel { get; set; }

        [JsonProperty(PropertyName = "max_score")]
        public double MaxScore { get; set; }

        [JsonProperty(PropertyName = "hits")]
        public List<ResponseSusModel> Hits { get; set; }
    }
}
