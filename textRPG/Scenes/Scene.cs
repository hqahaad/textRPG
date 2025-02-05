using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG.Scenes
{
     public abstract class Scene
     {
          public virtual void Awake() { }

          public virtual void Start()
          {
               Console.Clear();
          }

          public virtual void End()
          {
               Console.Clear();
          }
     }
}
