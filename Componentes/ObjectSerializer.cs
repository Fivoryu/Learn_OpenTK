using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Hello_OpenTK.Componentes
{
    public class ObjectSerializer
    {
        
        public static void Serialize<T>(T obj, string filepath)
        {

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(obj, options);

            File.WriteAllText(filepath, jsonString);

        }
        public static T Deserialize<T>(string filepath) where T : ITriangle
        { 
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException($"El archivo Json '{filepath}' no se encuentra.");
            }

            string jsonString = File.ReadAllText(filepath);

            if (string.IsNullOrEmpty(jsonString))
            {
                throw new JsonException("El archivo JSON está vacío o el contenido es nulo.");
            }

            T obj = JsonSerializer.Deserialize<T>(jsonString);

            obj.Load();

            return obj;
        }
    }
}
