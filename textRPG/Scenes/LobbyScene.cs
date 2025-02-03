using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG.Scenes
{
     public class LobbyScene : Scene
     {
          public override void Start()
          {
               base.Start();

               Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n" +
                    "이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");

               var selecter = OptionSelecter.Create();
               selecter.AddOption("1. 상태 보기", "1", ShowStatus);
               selecter.AddOption("2. 인벤토리", "2", ShowInventory);
               selecter.AddOption("3. 상점", "3", ShowShop);
               selecter.AddOption("4. 던전 입장", "4");
               selecter.AddOption("5. 휴식하기", "5");
               selecter.SetExceptionMessage("\n잘못된 입력입니다.");
               selecter.ShowSelecter();
               selecter.Read("\n원하시는 행동을 입력해주세요.\n>>  ");
          }

          private void ShowStatus()
          {
               Console.Clear();
               Console.WriteLine("[상태 보기]");
               Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

               Player player = Player.Instance;
               Console.WriteLine("Lv. {0}", player.level.ToString("D2"));
               Console.WriteLine("{0} ({1})", player.userName, 1);
               Console.WriteLine("공격력 : {0}", (float)player.character.strikingPower);
               Console.WriteLine("방어력 : {0}", (float)player.character.defensivePower);
               Console.WriteLine("체력 : {0}", player.hp);
               Console.WriteLine("Gold : {0}", player.gold);
               Console.WriteLine();

               var selecter = OptionSelecter.Create();
               selecter.AddOption("0. 나가기", "0",  () => SceneManager.Instance.LoadScene("LobbyScene"));
               selecter.SetExceptionMessage("\n잘못된 입력입니다.");
               selecter.ShowSelecter();
               selecter.Read("\n원하시는 행동을 입력해주세요.\n>>  ");
          }

          private void ShowInventory()
          {
               Console.Clear();

               var selecter = OptionSelecter.Create();
               selecter.AddOption("1. 장착 관리", "1");
               selecter.AddOption("0. 나가기", "0", () => SceneManager.Instance.LoadScene("LobbyScene"));
               selecter.SetExceptionMessage("\n잘못된 입력입니다.");
               selecter.ShowSelecter();
               selecter.Read("\n원하시는 행동을 입력해주세요.\n>>  ");
          }

          private void ShowShop()
          {
               Console.Clear();
               Console.WriteLine("[상점]");
               Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");

               var selecter = OptionSelecter.Create();
               selecter.AddOption("1. 아이템 구매", "1");
               selecter.AddOption("0. 나가기", "0", () => SceneManager.Instance.LoadScene("LobbyScene"));
               selecter.SetExceptionMessage("\n잘못된 입력입니다.");
               selecter.ShowSelecter();
               selecter.Read("\n원하시는 행동을 입력해주세요.\n>>  ");
          }
     }

     
}
