using CodeFramework.Runtime.Controllers.Utils.TimeEntity.TimerEntity.Controller;

namespace CodeFramework.Runtime.Controllers.Utils.TimeEntity.TimerEntity.Factory
{
   public class TimerFactory 
   {
      public static ITimer CreateTimer(float delay = 0)
      {
         return new TimerController(delay);
      }
   }
}