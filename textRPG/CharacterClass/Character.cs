using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG.CharacterClass
{
     public abstract class Character
     {
          public string? className { get; set; }
          public string? classDesc { get; set; }

          public Stat<int> maxHp;
          public Stat<float> strikingPower;
          public Stat<float> defensivePower;

          public Character()
          {
               maxHp = new Stat<int>();
               strikingPower = new Stat<float>();
               defensivePower = new Stat<float>();
          }
     }
}
