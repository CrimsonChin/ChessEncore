using System;
using System.Collections;
using System.Reflection;

namespace ChessEncore.PerformanceTests.V3
{
    /// <summary>
    /// Adapted code from: https://jonskeet.uk/csharp/benchmark.html
    /// Modified BenchmarkAttribute to take additional "iterate" property.  Then modified to use profiler code.
    /// Very simple benchmarking framework. Looks for all types
    /// in the current assembly which have static parameterless
    /// methods 
    public class Benchmark
    {
        public void Main(string[] args)
        {
            // Save all the benchmark classes from doing a nullity test
            if (args == null)
            {
                args = new string[0];
            }

            const BindingFlags publicStatic = BindingFlags.Public | BindingFlags.Static;

            foreach (var type in Assembly.GetCallingAssembly().GetTypes())
            {
                var initMethod = type.GetMethod("Init", publicStatic, null, new[] {typeof(string[])}, null);
                var resetMethod = type.GetMethod("Reset", publicStatic, null, new Type[0], null);
                var checkMethod = type.GetMethod("Check", publicStatic, null, new Type[0], null);

                var benchmarkMethods = new ArrayList();
                foreach (var method in type.GetMethods(publicStatic))
                {
                    var parameters = method.GetParameters();
                    if (parameters != null && parameters.Length != 0)
                    {
                        continue;
                    }

                    if (method.GetCustomAttributes(typeof(BenchmarkAttribute), false).Length != 0)
                    {
                        benchmarkMethods.Add(method);
                    }
                }

                // Ignore types with no appropriate methods to benchmark
                if (benchmarkMethods.Count == 0)
                {
                    continue;
                }

                Console.WriteLine("Benchmarking type {0}", type.Name);

                try
                {
                    initMethod?.Invoke(null, new object[] {args});
                }
                catch (TargetInvocationException e)
                {
                    var message = e.InnerException?.Message ?? "(No message)";
                    Console.WriteLine("Init failed ({0})", message);
                    continue;
                }

                foreach (MethodInfo method in benchmarkMethods)
                {
                    try
                    {
                        resetMethod?.Invoke(null, null);

                        var attribute = method.GetCustomAttribute<BenchmarkAttribute>();

                        Profiler.Profile(method.Name, attribute.Iterations, () => method.Invoke(null, null));

                        checkMethod?.Invoke(null, null);
                    }
                    catch (TargetInvocationException e)
                    {
                        var message = e.InnerException?.Message ?? "(No message)";
                        Console.WriteLine("  {0}: Failed ({1})", method.Name, message);
                    }
                }
            }

            Console.WriteLine("Benchmarking complete");
        }
    }
}