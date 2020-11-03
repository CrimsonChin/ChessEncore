using System;

namespace ChessEncore.PerformanceTests.V3
{
    [AttributeUsage(AttributeTargets.Method)]
    public class BenchmarkAttribute : Attribute
    {
        public BenchmarkAttribute(int iterations = 1)
        {
            Iterations = iterations;
        }

        public int Iterations { get; }
    }
}