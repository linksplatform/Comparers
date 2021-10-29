using BenchmarkDotNet.Running;

namespace Platform.Comparers.Benchmarks
{
    /// <summary>
    /// <para>
    /// Represents the program.
    /// </para>
    /// <para></para>
    /// </summary>
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
