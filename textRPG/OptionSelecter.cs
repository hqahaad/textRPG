using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
     public static class OptionSelecter
     {
          public class OptionContainer
          {
               public string optionName = string.Empty;
               public Action optionEvent { get; set; } = delegate { };

               public void Invoke()
               {
                    optionEvent?.Invoke();
               }
          }

          private static Dictionary<string, OptionContainer> options = new Dictionary<string, OptionContainer>();
          private static OptionContainer exception = new OptionContainer();

          public static void SetExceptionMessage(string msg)
          {
               exception.optionName = msg;
          }
          public static void SetExceptionEvent(Action? action)
          {
               exception.optionEvent += action;
          }

          public static void Clear()
          {
               options.Clear();
          }

          public static void AddOption(string text, string key, Action? action = null)
          {
               if (!options.TryGetValue(key, out var result))
               {
                    OptionContainer container = new OptionContainer();

                    container.optionName = text;
                    container.optionEvent += action;

                    options.Add(key, container);
               }
          }

          public static void Choice(string frontText = "")
          {
               Console.Write(frontText);
               string? input = Console.ReadLine();

               if (options.TryGetValue(input, out var value))
               {
                    value?.Invoke();
                    options.Clear();
               }
               else
               {
                    Console.Clear();
                    ShowAll();
                    Console.WriteLine(exception?.optionName);
                    exception?.Invoke();
                    Choice(frontText);
               }
          }

          public static void ShowAll()
          {
               foreach (var iter in options)
               {
                    Console.WriteLine(iter.Value.optionName);
               }
          }
     }
}
