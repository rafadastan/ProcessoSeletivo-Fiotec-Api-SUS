using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.SUS.Domain.Model.IntegrationModel
{
    public class MainRequestDto
    {
        [JsonProperty(PropertyName = "took")]
        public int Took { get; set; }

        [JsonProperty(PropertyName = "timed_out")]
        public bool TimedOut { get; set; }

        [JsonProperty(PropertyName = "_shards")]
        public SharedRequestModel Shareds { get; set; }

        [JsonProperty(PropertyName = "hits")]
        public HitsRequestModel Hits { get; set; }
    }
}
