using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using textRPG.Data;
using textRPG.Scenes;

namespace textRPG.Item
{
    public class Shop : IConsoleDisplay
     {
          private List<ItemData> itemDatas = new List<ItemData>();
          private Inventory? target = null;

          public Shop(Inventory inventory, params int[] items)
          {
               target = inventory;

               foreach (var iter in items.Distinct())
               {
                    ItemData instance = GameTable.GetElement<ItemData>(GameTable.itemTableName, iter);

                    if (instance != default)
                    {
                         itemDatas.Add(instance);
                    }
               }
          }

          public void BuyItem(int index)
          {
               if (index > itemDatas.Count - 1)
               {
                    return;
               }

               target.inventoryData.Gold -= itemDatas[index].Price;
               target.GetItem(itemDatas[index].ID);
          }

          public void Display()
          {
               Console.Clear();
               Console.WriteLine("[상점]");
               Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
               Console.WriteLine("[보유 골드]\n{0}G\n", target.InventoryGold);
               Console.WriteLine("[아이템 목록]");

               foreach (var iter in itemDatas)
               {
                    Console.WriteLine(ItemTextFormat(iter) + $"  {(target.IsContains(iter.ID) ? "구매완료" : iter.Price + " G")}");
               }

               var selecter = OptionSelecter.Create();
               selecter.AddOption("\n1. 아이템 구매", "1", DisplayBuyer);
               selecter.AddOption("2. 아이템 판매", "2", DisplaySeller);
               selecter.AddOption("0. 나가기", "0", () => SceneManager.Instance.LoadScene("LobbyScene"));
               selecter.SetExceptionMessage("\n잘못된 입력입니다.");
               selecter.Display();
               selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
          }

          public void DisplayBuyer()
          {
               Console.Clear();
               Console.WriteLine("[상점 - 아이템 구매]");
               Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
               Console.WriteLine("[보유 골드]\n{0}G\n", target.InventoryGold);
               Console.WriteLine("[아이템 목록]");

               var selecter = OptionSelecter.Create();

               Action<ItemData> buyLogic = (item) =>
               {
                    if (target.IsContains(item.ID))
                    {
                         Console.WriteLine("이미 구매한 아이템입니다");
                         selecter.Select("\n원하는 아이템의 번호를 선택해 주세요.\n>>  ");
                    }
                    else if (target.InventoryGold < item.Price)
                    {
                         Console.WriteLine("Gold가 부족합니다.");
                         selecter.Select("\n원하는 아이템의 번호를 선택해 주세요.\n>>  ");
                    }
                    else
                    {
                         target.PayGold(item.Price);
                         target.GetItem(item.ID);
                         DisplayBuyer();
                    }
               };

               for (int i = 0; i < itemDatas.Count; i++)
               {
                    ItemData actData = itemDatas[i];

                    selecter.AddOption(ItemTextFormat(itemDatas[i]).Replace("-", (i+1).ToString() + " ") +$"  {(target.IsContains(itemDatas[i].ID) ? "구매완료" : itemDatas[i].Price + " G")}", (i+1).ToString(), () => buyLogic(actData));
               }

               selecter.AddOption("\n0. 나가기", "0", Display);
               selecter.SetExceptionMessage("\n잘못된 입력입니다.");
               selecter.Display();
               selecter.Select("\n원하는 아이템의 번호를 선택해 주세요.\n>>  ");
          }

          public void DisplaySeller()
          {
               Console.Clear();
          }

          private string ItemTextFormat(ItemData item)
          {
               string nameStr = $"-{Util.String.PadLeft(16, item.Name)}    | ";
               string statStr = $"{(item.Striking != 0 ? " 공격력 " + item.Striking.ToString("+#;-#") : "")}{(item.Defensive != 0 ? " 방어력 " + item.Defensive.ToString("+#;-#") : "")}";
               statStr = Util.String.PadLeft(22, statStr) + "   | ";
               string descStr = " " + Util.String.PadLeft(50, item.Desc) + "   |";

               return nameStr + statStr + descStr;
          }
     }
}
