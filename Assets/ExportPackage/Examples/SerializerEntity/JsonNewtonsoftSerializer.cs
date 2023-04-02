using CodeFramework.Runtime.BaseServices.SerializerService;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;

namespace CodeFramework.Examples.SerializerEntity
{
    public class JsonNewtonsoftSerializer :ISerializerService
    {
        public string Serialize<T>(T jsonData)
        {
            return JsonConvert.SerializeObject(jsonData, 
                Formatting.None, 
                new JsonSerializerSettings { 
                    NullValueHandling = NullValueHandling.Ignore
                });
        }

        public T Deserialize<T>(string jsonData)
        {
            return JsonConvert.DeserializeObject<T>(jsonData,
                new JsonSerializerSettings { 
                    NullValueHandling = NullValueHandling.Ignore
                });
        }
    }
    
    
    public class JsonSerializer : ISerializer
    {
        /// <summary>Default serializer</summary>
        public JsonSerializer() => this.ContentType = "application/json";

        /// <summary>Serialize the object as JSON</summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns>JSON as String</returns>
        public string Serialize(object obj) => SimpleJson.SerializeObject(obj);

        /// <summary>Unused for JSON Serialization</summary>
        public string DateFormat { get; set; }

        /// <summary>Unused for JSON Serialization</summary>
        public string RootElement { get; set; }

        /// <summary>Unused for JSON Serialization</summary>
        public string Namespace { get; set; }

        /// <summary>Content type for serialized content</summary>
        public string ContentType { get; set; }
    }
}
