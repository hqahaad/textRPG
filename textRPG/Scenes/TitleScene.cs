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

               Console.WriteLine("1. 새로운 게임");
               Console.WriteLine("2. 불러오기");
               Console.WriteLine("3. 종료");
               Console.WriteLine();
               Console.Write(">>  ");

               while (true)
               {
                    bool isInt = int.TryParse(Console.ReadLine(), out int select);


               }
          }

          private void NewGame()
          {

          }

          private void LoadData()
          {

          }

          private void ExitGame()
          {

          }

     }
}
