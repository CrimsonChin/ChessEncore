using System;

namespace ChessEncore.PerformanceTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const char quitKey = 'q';
            
            var isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("--------- V1 ---------");
                new V1.BoardBenchmarks().Main(1);

                Console.WriteLine();
                Console.WriteLine("--------- V2 ---------");
                new V2.Benchmark().Main(args);
                
                Console.WriteLine(); 
                Console.WriteLine("--------- V3 ---------");
                new V3.Benchmark().Main(args);
     
                Console.WriteLine($"Press any key to repeat or {quitKey} to quit");
                var key = Console.ReadKey();
                isRunning = key.KeyChar != quitKey;
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}