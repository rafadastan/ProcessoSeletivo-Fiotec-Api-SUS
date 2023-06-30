using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.SUS.Client.Dto
{
    public class ResponseSusDto
    {
        [JsonProperty(PropertyName = "_id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "_index")]
        public string Index { get; set; }

        [JsonProperty(PropertyName = "_type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "_score")]
        public int Score { get; set; }

        [JsonProperty(PropertyName = "_source")]
        public SourceRequestSusDto Source { get; set; }
    }
}
