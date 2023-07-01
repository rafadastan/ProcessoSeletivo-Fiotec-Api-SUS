using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.SUS.Domain.Model.IntegrationModel
{
    public class RequestSizeModel
    {
        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }
    }
}
