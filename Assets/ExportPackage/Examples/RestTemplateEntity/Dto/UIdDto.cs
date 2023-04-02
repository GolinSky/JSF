using System;
using Newtonsoft.Json;

namespace CodeFramework.Examples.RestTemplateEntity.Dto
{
    [Serializable]
    public class UIdDto 
    {
        [JsonProperty("uuid")]
        public string uuid { get; private set; }
    }
}
