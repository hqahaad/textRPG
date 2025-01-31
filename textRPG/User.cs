using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
     public class User
     {
          private UserData userData;

          public User()
          {
               userData = new();
          }
     }

     public class UserData
     {
          public string Name { get; set; }
          public int Gold { get; set; }
     }
}
