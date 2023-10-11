using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Code.Core.Serialization
{
    public static class JsonSerializer
    {
        public static void Serialize(object value, string fileName)
        {
            var json = JsonConvert.SerializeObject(value, GetSettings());
            File.WriteAllText(Path.Combine(Application.dataPath,fileName), json);
        }

        public static T Deserialize<T>(string fileName)
        {
            var path = Path.Combine(Application.dataPath, fileName);
            
            if (!File.Exists(path))
            {
                return default;
            }
            var fileContent = File.ReadAllText(path);
           return JsonConvert.DeserializeObject<T>(fileContent);
        }
        
        private static JsonSerializerSettings GetSettings()
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return settings;
        }
    }
}