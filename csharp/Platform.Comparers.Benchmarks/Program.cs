using BenchmarkDotNet.Running;

namespace Platform.Comparers.Benchmarks
{
    private Program
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
