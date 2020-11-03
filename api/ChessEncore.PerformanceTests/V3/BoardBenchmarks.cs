namespace ChessEncore.PerformanceTests.V3
{
    public class BoardBenchmarks
    {
        private const string NewGameFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

        private const int Iterations = 100000;

        [Benchmark(Iterations)]
        public static void V1()
        {
            var chess = new Engine.V1.Chess(NewGameFen);
            chess.Fen();
        }

        [Benchmark(Iterations)]
        public static void V2()
        {
            var chess = new Engine.V2.Board(NewGameFen);
            chess.Fen();
        }

        [Benchmark(Iterations)]
        public static void V3()
        {
            var chess = new Engine.V3.Board(NewGameFen);
            chess.Fen();
        }

        [Benchmark(Iterations)]
        public static void V4()
        {
            var chess = new Engine.V4.Board(NewGameFen);
            chess.Fen();
        }

        [Benchmark(Iterations)]
        public static void V5()
        {
            var chess = new Engine.V5.Board(NewGameFen);
            chess.Fen();
        }
    }
}
