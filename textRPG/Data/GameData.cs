using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace textRPG.Data
{
     public static class GameData
     {
          private static readonly string directoryFolder = "SaveData";
          private static readonly string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directoryFolder);
          private static readonly string fileExtension = ".json";

          public static string GetFilePath(string fileName) => Path.Combine(directoryPath, fileName + fileExtension);

          public static void Save<T>(string fileName, T data)
          {
               if (!Directory.Exists(directoryPath))
               {
                    Directory.CreateDirectory(directoryPath);
               }

               string filePath = GetFilePath(fileName);
               string json = JsonSerializer.Serialize<T>(data);

               File.WriteAllText(filePath, json);
          }

          public static T? Load<T>(string fileName)
          {
               string filePath = GetFilePath(fileName);

               if (!File.Exists(filePath))
               {
                    return default;
               }

               string json = File.ReadAllText(filePath);

               return JsonSerializer.Deserialize<T>(json) ?? default;
          }
     }
}
