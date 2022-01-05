using System;
using Newtonsoft.Json;
using RestSharp;
using UnityEngine.Examples.RestTemplateEntity.HttpContext;
using UnityEngine.Examples.RestTemplateEntity.Rest;
using UnityEngine.MyPackage.Runtime.Scripts.Patterns.Proxy;

namespace UnityEngine.Examples.RestTemplateEntity.Proxy
{
    public class RestDelayProxy : BaseProxy<IDelayHttpContext, ITemplateRestApi>
    {
        public RestDelayProxy(IServerModelMiddleWare serverModelMiddleWare) : base(serverModelMiddleWare)
        {
        }

        public override void Request(IDelayHttpContext context)
        {
            RestResponse<DelayedDto> restResponse = restService.GetWithDelay(context.Duration);
            Debug.Log(restResponse.Content);
        }
    }

    [Serializable]
    public struct DelayedDto
    {
        [JsonProperty("args")] public string[] Arguments { get; private set; }
        [JsonProperty("data")] public string data { get; private set; }
        [JsonProperty("files")] public string files { get; private set; }
        [JsonProperty("form")] public string form { get; private set; }
        [JsonProperty("headers")] public string headers { get; private set; }


    }
}


