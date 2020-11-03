using System;

namespace ChessEncore.PerformanceTests.V2
{
    [AttributeUsage(AttributeTargets.Method)]
    public class BenchmarkAttribute : Attribute
    {
    }
}