using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG.Behaviors
{
     public abstract class Behavior
     {
          private static List<Behavior> behaviors = new List<Behavior>();
          public static List<Behavior> Behaviors => behaviors;

          public static void CreateBehaviors(string name, Behavior behavior)
          {
               behavior.BehaviorName = name;

               behaviors.Add(behavior);

               
          }

          public string BehaviorName { get; private set; } = string.Empty;
          public string BehaviorDesc { get; private set; } = string.Empty;

          public virtual void Start()
          {
               Console.Clear();
          }
     }
}
