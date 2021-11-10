using Newtonsoft.Json;

namespace UnityEngine.Examples.RestTemplateEntity.Dto
{
    public class TestDto 
    {
        [JsonProperty("uuid")]
        public string Id { get; private set; }
    }
}
