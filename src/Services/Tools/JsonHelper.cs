using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Services.Tools
{
    internal class JsonHelper
    {
        private static JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        public static JToken ToBody(object obj)
        {
            return JToken.FromObject(obj, JsonSerializer.Create(_settings));
        }
        public static string Serialize(object obj)
        {
           return JsonConvert.SerializeObject(obj, _settings);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _settings);
        }

    }
}
