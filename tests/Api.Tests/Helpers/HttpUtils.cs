using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace Api.Tests.Helpers
{
    public static class HttpUtils
    {
        public static StringContent Serialize(object o)
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            var content = JsonConvert.SerializeObject(o, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            return new StringContent(content, Encoding.UTF8, "application/json");
        }
    }
}
