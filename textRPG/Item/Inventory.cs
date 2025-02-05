using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textRPG.Data;
using textRPG.Scenes;
using static textRPG.Player;

namespace textRPG.Item
{
     public class Inventory : IConsoleDisplay
     {
          public class InventoryData
          {
               public List<int> Items { get; set; } = new();
               public Dictionary<string, int> EquipDict { get; set; } = new();
               public int Gold { get; set; } = 0;
          }

          public InventoryData? inventoryData = new();
          public ItemData? Armor { get; set; }
          public ItemData? Weapon { get; set; }

          public List<int>? InventoryItems => inventoryData?.Items ?? null;
          public Dictionary<string, int> InventoryEquipment => inventoryData.EquipDict;
          public int InventoryGold => inventoryData?.Gold ?? 0;

          private Inventory() 
          {
          }

          public void GetItem(int id)
          {
               inventoryData.Items.Add(id);
          }

          public void RemoveItem(int id)
          {
               
          }

          public void GetGold(int amount)
          {
               inventoryData.Gold += amount;
          }

          public void PayGold(int amount)
          {
               if (amount > InventoryGold)
               {
                    inventoryData.Gold = 0;
               }
               else
               {
                    inventoryData.Gold -= amount;
               }
          }

          public bool Equipped(ItemData equipment)
          {
               if (equipment != null)
               {
                    //수정하자
                    //장착한 장비 타입이 있을때
                    if (InventoryEquipment.TryGetValue(equipment.EquipType.ToString(), out var value))
                    {
                         var old = GameTable.GetElement<ItemData>(GameTable.itemTableName, value);

                         GameManager.Instance.GetPlayer().StrikingPower[StatType.Equipment] -= old.Striking;
                         GameManager.Instance.GetPlayer().DefensivePower[StatType.Equipment] -= old.Defensive;

                         InventoryEquipment[equipment.EquipType.ToString()] = equipment.GetID();

                         GameManager.Instance.GetPlayer().StrikingPower[StatType.Equipment] += equipment.Striking;
                         GameManager.Instance.GetPlayer().DefensivePower[StatType.Equipment] += equipment.Defensive;

                         return true;
                    }
                    else
                    {
                         InventoryEquipment.Add(equipment.EquipType.ToString(), equipment.GetID());

                         GameManager.Instance.GetPlayer().StrikingPower[StatType.Equipment] += equipment.Striking;
                         GameManager.Instance.GetPlayer().DefensivePower[StatType.Equipment] += equipment.Defensive;

                         return true;
                    }
               }

               return false;
          }

          public bool IsContains(int id) => inventoryData.Items.Contains(id);

          public bool IsEquipped(int itemId)
          {


               return false;
          }


          public void Display()
          {
               Console.Clear();
               Console.WriteLine("[인벤토리]");
               Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
               Console.WriteLine("[아이템 목록]\n");

               for (int i = 0; i < InventoryItems.Count; i++)
               {
                    var item = GameTable.GetElement<ItemData>("ItemTable", InventoryItems[i]);

                    Console.WriteLine(ItemTextFormat(item));
               }

               var selecter = OptionSelecter.Create();
               selecter.AddOption("\n1. 장착 관리", "1", DisplayEquipment);
               selecter.AddOption("0. 나가기", "0", () => SceneManager.Instance.LoadScene("LobbyScene"));
               selecter.SetExceptionMessage("\n잘못된 입력입니다.");
               selecter.Display();
               selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
          }

          public void DisplayEquipment()
          {
               Console.Clear();
               Console.WriteLine("[인벤토리 - 장착 관리]");
               Console.WriteLine("보유 중인 아이템을 장착할 수 있습니다.\n");
               Console.WriteLine("[아이템 목록]\n");

               var selecter = OptionSelecter.Create();

               Action<ItemData> equipLogic = (item) =>
               {

               };

               for (int i = 0; i < InventoryItems.Count; i++)
               {
                    var item = GameTable.GetElement<ItemData>("ItemTable", InventoryItems[i]);
                    selecter.AddOption(ItemTextFormat(item).Replace("-", (i + 1).ToString() + " "), (i + 1).ToString(), () =>
                    {
                         Equipped(item);
                         Display();
                    });
               }
               selecter.AddOption("\n0. 나가기", "0", Display);
               selecter.SetExceptionMessage("\n잘못된 입력입니다.");
               selecter.Display();
               selecter.Select("\n원하는 아이템의 번호를 선택해 주세요.\n>>  ");
          }

          private string ItemTextFormat(ItemData item)
          {
               string temp = $"-{(InventoryEquipment.ContainsValue(item.GetID()) ? "[E]" : string.Empty)}" + item.Name;
               string nameStr = Util.String.PadLeft(24, temp) +"   |";
               string statStr = $"{(item.Striking != 0 ? " 공격력 " + item.Striking.ToString("+#;-#") : "")}{(item.Defensive != 0 ? " 방어력 " + item.Defensive.ToString("+#;-#") : "")}";
               statStr = Util.String.PadLeft(22, statStr) + "   | ";
               string descStr = " " + Util.String.PadLeft(50, item.Desc) + "   |";

               return nameStr + statStr + descStr;
          }

          #region Data Method
          public void SaveData()
          {
               GameData.Save<InventoryData>("InventoryData", inventoryData);
          }

          public void LoadData()
          {
               inventoryData = GameData.Load<InventoryData>("InventoryData");

               foreach (var iter in InventoryEquipment)
               {
                    var equipment = GameTable.GetElement<ItemData>("ItemTable", iter.Value);

                    if (equipment != null)
                    {
                         Equipped(equipment);
                    }
               }
          }

          public static Inventory? CreateInventory()
          {
               Inventory inventory = new Inventory();

               return inventory ?? null;
          }

          public static Inventory? LoadInventory()
          {
               Inventory inventory = new Inventory();
               inventory.LoadData();

               return inventory ?? null;
          }
          #endregion
     }
}
