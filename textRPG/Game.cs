using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textRPG.Data;
using textRPG.Item;
using textRPG.Scenes;
using textRPG.CharacterClass;

namespace textRPG
{
    public class Game
     {
          public void Start()
          {
               GameTable.LoadTable<ItemData>("ItemTable");
               GameTable.LoadTable<CharacterData>("CharacterTable");
               /*--------------------------------Load Table-----------------------------*/

               /*-------------------------------------------------------------------------*/
               SceneManager.Instance.AddScene("TitleScene", new TitleScene());
               SceneManager.Instance.AddScene("LobbyScene", new LobbyScene());
               /*--------------------------------Added Scene-----------------------------*/
               SceneManager.Instance.LoadScene("TitleScene");
          }

          public void End()
          {

          }
     }
}
