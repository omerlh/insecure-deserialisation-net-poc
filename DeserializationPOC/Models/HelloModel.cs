using Newtonsoft.Json;

namespace DeserializationPOC.Models
{
    public class HelloModel
    {
        [JsonProperty(PropertyName = "body")]
        public dynamic Body { get; set; }
    }
}
