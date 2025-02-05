using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textRPG
{
     public class GameEvents : Singleton<GameEvents>
     {
          
     }

     public interface IEventProvider
     {
          void OnEvent(IEventProvider provider);
     }

     public enum GameEvent
     {
          None = 0,
          GameStart,
          GameEnd,
          GetItem,
     }
}
