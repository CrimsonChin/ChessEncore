using System;
using System.Diagnostics;
using System.Threading;

namespace ChessEncore.PerformanceTests
{
    internal static class Profiler
    {
        // Adapted code from: https://stackoverflow.com/a/1048708/874927
        public static Tuple<string, double> Profile(string description, int iterations, Action func)
        {
            //Run at highest priority to minimize fluctuations caused by other processes/threads
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            // warm up 
            func();

            var watch = new Stopwatch();

            // clean up
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            watch.Start();
            for (var i = 0; i < iterations; i++)
            {
                func();
            }
            watch.Stop();
            Console.WriteLine("  {0,-20} {1}", description, watch.Elapsed.TotalMilliseconds);
            return new Tuple<string, double>(description, watch.Elapsed.TotalMilliseconds);
        }
    }
}
