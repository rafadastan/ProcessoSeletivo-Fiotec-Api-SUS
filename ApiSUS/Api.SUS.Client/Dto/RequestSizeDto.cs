using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.SUS.Client.Dto
{
    public class RequestSizeDto
    {
        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }
    }
}
