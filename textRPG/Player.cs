using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textRPG.CharacterClass;
using textRPG.Item;

namespace textRPG
{
    public class Player : Singleton<Player>
     {
          public string? userName;
          public Character character;
          public Inventory inventory;
          public int level = 1;
          public float hp;
          public int gold;
     }
}
