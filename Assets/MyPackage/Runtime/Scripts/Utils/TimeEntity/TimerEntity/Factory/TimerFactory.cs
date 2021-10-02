using UnityEngine.MyPackage.Runtime.Scripts.Utils.TimeEntity.TimerEntity.Controller;

namespace UnityEngine.MyPackage.Runtime.Scripts.Utils.TimeEntity.TimerEntity.Factory
{
   public class TimerFactory 
   {
      public static ITimer CreateTimer(float delay = 0)
      {
         return new TimerController(delay);
      }
   }
}