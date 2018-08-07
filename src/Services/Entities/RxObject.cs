using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Services.Entities
{
    public class RxObject
    {
        public IDictionary<string, string> Headers;

        public JToken Body { get; protected set; }

        protected T[] GetNodeArray<T>()
        {
            return Body.ToObject<T[]>();
        }

        protected void SetNodeArray<T>(T[] array)
        {
            Body = JArray.FromObject(array);
        }

        protected T GetNodeValue<T>(string name)
        {
            return Body.Value<T>(name);
        }

        protected void SetNodeValue(string name, string value)
        {
            Body[name] = value;
        }
    }
}
