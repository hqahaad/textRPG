using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using textRPG.CharacterClass;
using textRPG.Data;
using textRPG.Item;
using textRPG.Scenes;

namespace textRPG
{
    public class Player : IConsoleDisplay
     {
          public class PlayerData
          {
               public string? UserName { get; set; }
               public int Level { get; set; } = 1;
               public int Hp { get; set; }
               public string? ClassName { get; set; }
               public float Striking { get; set; }
               public float Defensive { get; set; }
          }

          public PlayerData? playerData = new();

          public string UserName => playerData.UserName ?? string.Empty;
          public int Level => playerData.Level;
          public int Hp => playerData.Hp;
          public string ClassName => playerData.ClassName;
          public float Striking => playerData.Striking;
          public float Defensive => playerData.Defensive;

          private ModifierStat<float> strikingPower = new();
          private ModifierStat<float> defensivePower = new();

          public ModifierStat<float> StrikingPower
          {
               get
               {
                    strikingPower[StatType.Origin] = Striking;
                    return strikingPower;
               }
          }
          public ModifierStat<float> DefensivePower
          {
               get
               {
                    defensivePower[StatType.Origin] = Defensive;
                    return defensivePower;
               }
          }

          private Player() { }

          public void Display()
          {
               Console.Clear();
               Console.WriteLine("[상태 보기]");
               Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

               Console.WriteLine("Lv. {0}", Level.ToString("D2"));
               Console.WriteLine("{0} ({1})", UserName, ClassName);
               Console.WriteLine($"공격력 : {Striking} {(StrikingPower[StatType.Equipment] != 0f ? StrikingPower[StatType.Equipment].ToString("+#;-#") : "")}");
               Console.WriteLine($"방어력 : {Defensive} {(DefensivePower[StatType.Equipment] != 0f ? DefensivePower[StatType.Equipment].ToString("+#;-#") : "")}");
               Console.WriteLine("체력 : {0}", Hp);
               Console.WriteLine("Gold : {0}G", GameManager.Instance.GetInventory().InventoryGold);
               Console.WriteLine();

               var selecter = OptionSelecter.Create();
               selecter.AddOption("0. 나가기", "0", () => SceneManager.Instance.LoadScene("LobbyScene"));
               selecter.SetExceptionMessage("\n잘못된 입력입니다.");
               selecter.Display();
               selecter.Select("\n원하시는 행동을 입력해주세요.\n>>  ");
          }

          #region
          public void SaveData()
          {
               GameData.Save<PlayerData>("PlayerData", playerData);
          }

          public void LoadData()
          {
               playerData = GameData.Load<PlayerData>("PlayerData");

               strikingPower[StatType.Origin] = Striking;
               defensivePower[StatType.Origin] = defensivePower;
          }

          public static Player? CreatePlayer(string? userName, int classID)
          {
               Player player = new Player();

               player.playerData.UserName = userName;
               player.playerData.Level = 1;

               var data = GameTable.GetElement<CharacterData>(GameTable.characterTableName, classID);
               player.playerData.ClassName = data.Name;
               player.playerData.Striking = data.Striking;
               player.playerData.Defensive = data.Defensive;
               player.playerData.Hp = data.MaxHp;

               return player ?? null;
          }

          public static Player? LoadPlayer()
          {
               Player player = new Player();
               player.LoadData();

               return player ?? null;
          }
          #endregion
     }
}
