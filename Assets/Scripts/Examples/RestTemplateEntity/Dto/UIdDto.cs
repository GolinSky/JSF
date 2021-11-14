using System;
using Newtonsoft.Json;

namespace UnityEngine.Examples.RestTemplateEntity.Dto
{
    [Serializable]
    public class UIdDto 
    {
        [JsonProperty("uuid")]
        public string uuid { get; private set; }
    }
}
