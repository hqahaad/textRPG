using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textRPG.Item;

namespace textRPG
{
     public class GameManager : Singleton<GameManager>
     {
          private Player? gamePlayer = null;
          private Inventory? gameInventory = null;

          public void SetPlayer(Player? player) => gamePlayer = player;
          public void SetInventory(Inventory? inventory) => gameInventory = inventory;

          public Player? GetPlayer() => gamePlayer;
          public Inventory? GetInventory() => gameInventory;

          public void LoadGame()
          {
               gamePlayer?.LoadData();
               gameInventory?.LoadData();
          }
     }
}
