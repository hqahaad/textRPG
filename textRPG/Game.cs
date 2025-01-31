using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textRPG.Behaviors;

namespace textRPG
{
     public class Game
     {
          public void RenderSelections()
          {
               for (int i = 0; i < Behavior.Behaviors.Count; i++)
               {
                    Console.WriteLine("{0}. {1}", i+1, Behavior.Behaviors[i].BehaviorName);
               }
          }

          public void Start()
          {
               Behavior.CreateBehaviors("상태 보기", new ShowStateBhv());
               Behavior.CreateBehaviors("인벤토리", new ShowInventoryBhv());
               Behavior.CreateBehaviors("상점", new ShopBhv());
               Behavior.CreateBehaviors("던전 입장", new DungeonBhv());
               Behavior.CreateBehaviors("휴식하기", new RestBhv());

               Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.\n" +
                    "이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
               RenderSelections();
               Console.WriteLine("\n원하시는 행동을 입력해주세요");
               Console.Write(">> ");
               Console.ReadLine();
          }

          public bool Update()
          {
               return false;
          }

          public void Exit()
          {

          }
     }
}
