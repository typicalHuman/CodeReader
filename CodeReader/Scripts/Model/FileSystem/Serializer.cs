using Newtonsoft.Json;

namespace CodeReader.Scripts.FileSystem
{
    internal static class Serializer
    {


        static JsonSerializerSettings settings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };

        internal static string Serialize(CodeComponentsCollection components)
        {
            return JsonConvert.SerializeObject(components, typeof(CodeComponentsCollection), settings);
        }

        internal static CodeComponentsCollection Deserialize(string jsonString)
        {
            return JsonConvert.DeserializeObject<CodeComponentsCollection>(jsonString, settings);
        }
    }
}
