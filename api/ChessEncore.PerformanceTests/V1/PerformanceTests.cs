using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessEncore.PerformanceTests.V1
{
    public class BoardBenchmarks
    {
        public static string NewGameFen { get; } = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

        public void Main(int iterations)
        {

            var results = new List<Tuple<string, double>>
            {
                Profiler.Profile("BoardBenchmarks V1", iterations, V1),
                Profiler.Profile("BoardBenchmarks V1", iterations, V1),
                Profiler.Profile("BoardBenchmarks V2", iterations, V2),
                Profiler.Profile("BoardBenchmarks V3", iterations, V3),
                Profiler.Profile("BoardBenchmarks V4", iterations, V4),
                Profiler.Profile("BoardBenchmarks V5", iterations, V5)
            };

            var (description, time) = results.OrderByDescending(x => x.Item1).First();
            Console.WriteLine($"Fastest Profile: {description} - {time} ms");
        }

        private static void V1()
        {
            var chess = new Engine.V1.Chess(NewGameFen);
            chess.Fen();
        }

        private static void V2()
        {
            var chess = new Engine.V2.Board(NewGameFen);
            chess.Fen();
        }

        private static void V3()
        {
            var chess = new Engine.V3.Board(NewGameFen);
            chess.Fen();
        }

        private static void V4()
        {
            var chess = new Engine.V4.Board(NewGameFen);
            chess.Fen();
        }

        private static void V5()
        {
            var chess = new Engine.V5.Board(NewGameFen);
            chess.Fen();
        }
    }
}

