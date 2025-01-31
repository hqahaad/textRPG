using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG.Scenes
{
     public abstract class Scene
     {
          public virtual void View()
          {
               Console.Clear();
          }
     }
}
