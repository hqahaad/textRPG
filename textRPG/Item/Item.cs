using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textRPG.Data;

namespace textRPG.Item
{
     public class ItemData : ITableData
     {
          public int ID { get; set; }
          public string? ItemType { get; set; }
          public string? EquipType { get; set; }
          public string? Name { get; set; }
          public string? Desc { get; set; }
          public int Price { get; set; } = 0;
          public float Striking { get; set; } = 0;
          public float Defensive { get; set; } = 0;

          public int GetID() => ID;
     }

     public enum EquipmentType
     {
          Weapon,
          Armor,
     }
}
