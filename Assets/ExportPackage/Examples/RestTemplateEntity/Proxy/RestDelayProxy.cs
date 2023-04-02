using System;
using CodeFramework.Examples.RestTemplateEntity.HttpContext;
using CodeFramework.Examples.RestTemplateEntity.Rest;
using CodeFramework.Runtime.Proxy;
using Newtonsoft.Json;
using RestSharp;
using UnityEngine;

namespace CodeFramework.Examples.RestTemplateEntity.Proxy
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


