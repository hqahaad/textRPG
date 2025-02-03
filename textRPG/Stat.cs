using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace textRPG
{
     public class Stat<T> where T : INumber<T>
     {
          private List<T> values;

          public static implicit operator T(Stat<T> statValue)
          {
               T sum = T.Zero;
               statValue.values.ForEach(v => sum += v);

               return sum;
          }

          public T this[StatType type]
          {
               get
               {
                    return values[(int)type];
               }

               set
               {
                    values[(int)type] = value;
               }
          }

          public Stat()
          {
               values = new List<T>();

               for (int i = 0; i < (int)StatType.Count; i++)
               {
                    values.Add(T.Zero);
               }
          }
     }

     public enum StatType
     {
          Origin,
          Equipment,

          Count = 2
     }
}
