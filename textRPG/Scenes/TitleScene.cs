using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using textRPG.CharacterClass;
using textRPG.Data;
using textRPG.Item;
using static textRPG.Player;

namespace textRPG.Scenes
{
    public class TitleScene : Scene
     {
          public override void Start()
          {
               base.Start();

               var selecter = OptionSelecter.Create();
               selecter.AddOption("1. 새로운 게임", "1", NewGame);
               selecter.AddOption("2. 불러오기", "2", LoadData);
               selecter.AddOption("3. 종료", "3", ExitGame);
               selecter.SetExceptionMessage("\n잘못된 입력입니다.");
               selecter.Display();
               selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");

          }

          private void NewGame()
          {
               Console.Clear();
               Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
               Console.Write("\n원하시는 이름을 설정해주세요.\n>>  ");

               string input = Console.ReadLine() ?? string.Empty;

               Console.WriteLine("\n입력하신 이름은 {0} 입니다.", input);
               Console.WriteLine("\n원하시는 직업을 선택해주세요.");

               Character? character = null;
               int loadID = 0;

               var selecter = OptionSelecter.Create();
               selecter.AddOption("1. 전사", "1", () => { character = new Warrior(); loadID = 0; }) ;
               selecter.AddOption("2. 기사", "2", () => { character = new Knight(); loadID = 1; });
               selecter.AddOption("3. 도적", "3", () => { character = new Thief(); loadID = 2; });
               selecter.AddOption("4. 마법사", "4", () => { character = new Wizard(); loadID = 3; });
               selecter.SetExceptionMessage("\n잘못된 입력입니다.");
               selecter.Display();
               selecter.Select("\n>>  ");

               Player? player = Player.CreatePlayer(input, loadID);
               GameManager.Instance.SetPlayer(player);
               
               Inventory? inventory = Inventory.CreateInventory();
               inventory.GetGold(1500);
               GameManager.Instance.SetInventory(inventory);
               SceneManager.Instance.LoadScene("LobbyScene");
          }

          private void LoadData()
          {
               if (GameData.Load<PlayerData>("PlayerData") == default)
               {
                    //수정하자
                    SceneManager.Instance.LoadScene("TitleScene");
               }

               Player? player = Player.LoadPlayer();
               GameManager.Instance.SetPlayer(player);

               Inventory? inventory = Inventory.LoadInventory();
               GameManager.Instance.SetInventory(inventory);

               SceneManager.Instance.LoadScene("LobbyScene");
          }

          private void ExitGame()
          {
               Console.Beep();
          }
     }
}
