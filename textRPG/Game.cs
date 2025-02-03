using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textRPG.Scenes;

namespace textRPG
{
     public class Game
     {
          public void Start()
          {
               SceneManager.Instance.AddScene("TitleScene", new TitleScene());
               SceneManager.Instance.AddScene("LobbyScene", new LobbyScene());

               SceneManager.Instance.LoadScene("TitleScene");
          }

          public void End()
          {

          }
     }
}
