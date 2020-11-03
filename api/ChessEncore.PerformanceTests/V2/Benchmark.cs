using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace ChessEncore.PerformanceTests.V2
{
    /// <summary>
    /// Adapted code from: https://jonskeet.uk/csharp/benchmark.html
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

            var publicStatic = BindingFlags.Public | BindingFlags.Static;

            foreach (var type in Assembly.GetCallingAssembly().GetTypes())
            {
                var initMethod = type.GetMethod("Init", publicStatic, null, new[] { typeof(string[]) }, null);
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

                    if (method.GetCustomAttributes<BenchmarkAttribute>().Count() != 0)
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

                // If we've got an Init method, call it once
                try
                {
                    if (initMethod != null)
                        initMethod.Invoke(null, new object[] { args });
                }
                catch (TargetInvocationException e)
                {
                    var inner = e.InnerException;
                    var message = inner?.Message ?? "(No message)";
                    Console.WriteLine("Init failed ({0})", message);
                    continue;
                }

                foreach (MethodInfo method in benchmarkMethods)
                {
                    try
                    {
                        // Reset (if appropriate)
                        if (resetMethod != null)
                            resetMethod.Invoke(null, null);

                        // Give the test as good a chance as possible
                        // of avoiding garbage collection
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        GC.Collect();

                        // Now run the test itself
                        var start = DateTime.Now;
                        method.Invoke(null, null);
                        var end = DateTime.Now;
                        Console.WriteLine("  {0,-20} {1}", method.Name, (end - start).TotalMilliseconds);

                        // Check the results (if appropriate)
                        // Note that this doesn't affect the timing
                        if (checkMethod != null)
                        {
                            checkMethod.Invoke(null, null);
                        }
                    }
                    catch (TargetInvocationException e)
                    {
                        var inner = e.InnerException;
                        var message = inner?.Message ?? "(No message)";
                        Console.WriteLine("  {0}: Failed ({1})", method.Name, message);
                    }
                }
            }

            Console.WriteLine("Benchmarking complete");
        }
    }
}