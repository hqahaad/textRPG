using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG.Scenes
{
     public class TitleScene : Scene
     {
          public override void View()
          {
               base.View();

               OptionSelecter.AddOption("1. 새로운 게임", "1", NewGame);
               OptionSelecter.AddOption("2. 불러오기", "2", LoadData);
               OptionSelecter.AddOption("3. 종료", "3", ExitGame);
               OptionSelecter.SetExceptionMessage("\n다시 입력해주세요");
               OptionSelecter.ShowAll();
               OptionSelecter.Choice("\n>>  ");
          }

          private void NewGame()
          {
               Console.WriteLine("New Game");
          }

          private void LoadData()
          {
               Console.WriteLine("Load Data");
          }

          private void ExitGame()
          {
               Console.WriteLine("ExitGame");
               
          }

     }
}
