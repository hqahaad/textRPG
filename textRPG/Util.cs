using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
     public static class Util
     {
          public static class String
          {
               public static string PadLeft(int len, string str)
               {
                    foreach (char c in str)
                    {
                         len -= char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter ? 2 : 1;
                    }

                    return len >= 0 ? str + new string(' ', len) : str;
               }

               public static string PadRight(int len, string str)
               {
                    foreach (char c in str)
                    {
                         len -= char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter ? 2 : 1;
                    }

                    return len >= 0 ? new string(' ', len) + str : str;
               }
          }
     }
}
