using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textRPG.Data;

namespace textRPG.CharacterClass
{
     public class CharacterData : ITableData
     {
          public int ID { get; set; }
          public string? Name { get; set; }
          public float Striking { get; set; } = 0f;
          public float Defensive { get; set; } = 0f;
          public int MaxHp { get; set; } = 0;

          public int GetID() => ID;
     }

     public abstract class Character
     {
          public CharacterData? characterData = new();

          public virtual void DataLoad(int id)
          {
               characterData = GameTable.GetElement<CharacterData>(GameTable.characterTableName, id);
          }
     }
}
