using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG.Item
{
     public class Inventory
     {
          public List<Equipment> equipped;
          public List<Item> itemList;

          public Inventory()
          {
               equipped = new List<Equipment>();
               itemList = new List<Item>();

               for (int i = 0; i < (int)Equipment.EquipmentType.Count; i++) 
               {
                    equipped.Add(null);
               }
          }

          public void Equipped(Equipment.EquipmentType equipmentType, Equipment equipment)
          {
               equipped[(int)equipmentType] = equipment;
          }
    }
}
