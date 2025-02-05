using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using textRPG.Data;
using textRPG.Item;

namespace textRPG.Scenes
{
     public class LobbyScene : Scene
     {
          public override void Awake()
          {
               base.Awake();
          }

          public override void Start()
          {
               base.Start();

               Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n" +
                    "이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");

               Shop shop = new Shop(GameManager.Instance.GetInventory(), 1001, 1002, 1003, 1004, 1005, 1006);

               var selecter = OptionSelecter.Create();
               selecter.AddOption("1. 상태 보기", "1", GameManager.Instance.GetPlayer().Display);
               selecter.AddOption("2. 인벤토리", "2", GameManager.Instance.GetInventory().Display);
               selecter.AddOption("3. 상점", "3", shop.Display);
               selecter.AddOption("\n9. 저장하기", "9", SaveGame);
               selecter.SetExceptionMessage("\n잘못된 입력입니다.");
               selecter.Display();
               selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
          }

          private void SaveGame()
          {
               GameManager.Instance.GetPlayer().SaveData();
               GameManager.Instance.GetInventory().SaveData();

               SceneManager.Instance.LoadScene("LobbyScene");
          }
     }
}