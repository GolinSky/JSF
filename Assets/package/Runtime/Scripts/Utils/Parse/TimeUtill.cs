#pragma warning disable 0649
namespace UnityEngine.Package.Runtime.Scripts.Utils.Parse
{
    public static class TimeUtils
    {
        private static int result;
        public static int TimeRemain(string serverTime, string worldTime)
        {
            var firstClearWorld = worldTime.Remove(0, 3);
            var secondClearWorld = worldTime.Remove(2);
            var intTimeFirstWorld = int.Parse(firstClearWorld);
            var intTimeSecondWorld = int.Parse(secondClearWorld);
            var hourInMinuteWorld =  intTimeSecondWorld * 60;
            var sumWorld = hourInMinuteWorld + intTimeFirstWorld;
           
            var firstClearServer = serverTime.Remove(13);
            firstClearServer = firstClearServer.Remove(0, 11);
            var secondClearServer  = serverTime.Remove(0, 14);
            secondClearServer = secondClearServer.Remove(2);
            var intTimeFirstServer = int.Parse(firstClearServer);
            var intTimeSecondServer = int.Parse(secondClearServer);
            var hourInMinutServer =  intTimeFirstServer * 60;
            var sumServer = hourInMinutServer + intTimeSecondServer;
            result = sumServer - sumWorld;
            return result;
        }

        public static void Reset()
        {
            result = 0;
        } 
        public static bool TimeActual()
        {
            if (result > 0)
            {
                return true;
            }

            return false;
        }
    }
}
