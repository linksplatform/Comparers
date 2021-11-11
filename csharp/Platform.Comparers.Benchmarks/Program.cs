using BenchmarkDotNet.Running;

namespace Platform.Comparers.Benchmarks
{
    class Program
    {
        /// <summary>
        /// <para>
        /// Main.
        /// </para>
        /// <para></para>
        /// </summary>
        static void Main()
        {
            BenchmarkRunner.Run<ComparsionBenchmarks>();
            BenchmarkRunner.Run<EqualityBenchmarks>();
        }
    }
}
