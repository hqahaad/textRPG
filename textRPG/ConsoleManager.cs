using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
     public static class ConsoleManager
     {
          public enum MessageType
          {
               WriteLine,
               Write
          }

          public static void Message(string msg, MessageType type = MessageType.WriteLine)
          {
               if (type == MessageType.Write)
               {
                    Console.Write(msg);
               }
               else
               {
                    Console.WriteLine(msg);
               }
          }
     }
}
