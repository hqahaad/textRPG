using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG.Scenes
{
     public sealed class SceneManager : Singleton<SceneManager>
     {
          private Dictionary<string, Scene> scenes = new Dictionary<string, Scene>();
          private Scene? currentScene = null;

          public void AddScene(string sceneName, Scene scene)
          {
               if (!scenes.TryGetValue(sceneName, out var value))
               {
                    scenes.Add(sceneName, scene);
               }
          }

          public bool LoadScene(string sceneName)
          {
               if (currentScene == null)
               {
                    if (scenes.TryGetValue(sceneName, out var value))
                    {
                         currentScene = value;
                         currentScene.Start();

                         return true;
                    }
               }
               else
               {
                    if (scenes.TryGetValue(sceneName, out var value))
                    {
                         currentScene.End();
                         currentScene = value;
                         currentScene.Start();

                         return true;
                    }
               }

               return false;
          }
     }
}
