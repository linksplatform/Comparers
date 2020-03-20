using BenchmarkDotNet.Running;

namespace Platform.Comparers.Benchmarks
{
    class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run<ComparsionBenchmarks>();
            BenchmarkRunner.Run<EqualityBenchmarks>();
        }
    }
}
