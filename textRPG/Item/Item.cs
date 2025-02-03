using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG.Item
{
     public class Item
     {
          protected ItemType itemType;
          public int itemID;
     }

     public class Equipment : Item
     {
          
          public enum EquipmentType
          {
               Weapon,
               Armor,

               Count
          }
     }

     public class Consumable : Item
     {

     }

     public enum ItemType
     {
          Equipment,
          Consumable
     }
}
