using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace textRPG.Data
{
     public static class GameTable
     {
          public static readonly string itemTableName = "ItemTable";
          public static readonly string characterTableName = "CharacterTable";

          private static readonly string directoryFolder = "DataTable";
          private static readonly string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directoryFolder);
          private static readonly string fileExtension = ".json";

          public static string GetFilePath(string fileName) => Path.Combine(directoryPath, fileName + fileExtension);

          private static Dictionary<string, dynamic> tables = new();

          public static void LoadTable<T>(string fileName) where T : ITableData
          {
               string filePath = GetFilePath(fileName);

               if (tables.TryGetValue(filePath, out var value))
               {
                    return;
               }
               else
               {
                    if (File.Exists(filePath))
                    {
                         string json = File.ReadAllText(filePath);
                         var dates = JsonSerializer.Deserialize<List<T>>(json);

                         if (dates != null)
                         {
                              Dictionary<int, T> newDict = new();
                              newDict = dates.ToDictionary(x => x.GetID());
                              tables.Add(fileName, newDict);
                         }
                    }
               }
          }

          public static Dictionary<int, T>? GetTable<T>(string fileName) where T : ITableData
          {
               if (tables.TryGetValue(fileName, out var value))
               {
                    return value;
               }
               return null;
          }

          public static T? GetElement<T>(string fileName, int id) where T : ITableData
          {
               Dictionary<int, T>? table = GetTable<T>(fileName);

               if (table.TryGetValue(id, out var value))
               {
                    return value ?? default;
               }
               return default;
          }
     }
}
