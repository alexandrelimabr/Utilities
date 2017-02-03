using System;
using System.Threading;

public static class Test
{
    public static void Main(String[] args)
    {
        ManualResetEvent evtShutdown = new ManualResetEvent(false);
        long ThrottleTime = 0;
        int lap = 0;
        int maxLaps = 500;
        long startTicks, elapsed;

        if (args.Length > 0)
            int.TryParse(args[0], out maxLaps);

        ThrottleHelper throt = new ThrottleHelper(maxLaps);

        startTicks = DateTime.Now.Ticks;

        while (evtShutdown.WaitOne(1)==false)
        {
            ++lap;
            if ((ThrottleTime = throt.VerifyLaps()) > 0)
            {
                elapsed = (long)(new TimeSpan(DateTime.Now.Ticks - startTicks)).TotalMilliseconds;

                Console.WriteLine(" ThrotteTime={0}/Laps={1} TotalTime={2}", ThrottleTime, lap, elapsed);
                lap = 0;

                startTicks = DateTime.Now.Ticks;
            }
        }
    }
}