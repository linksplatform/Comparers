using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Platform.Comparers.Benchmarks
{
    /// <summary>
    /// <para>
    /// Represents the comparsion benchmarks.
    /// </para>
    /// <para></para>
    /// </summary>
    [SimpleJob]
    [MemoryDiagnoser]
    public class ComparsionBenchmarks
    {
        private class UInt64Comparer : IComparer<ulong>
        {
            /// <summary>
            /// <para>
            /// Compares the x.
            /// </para>
            /// <para></para>
            /// </summary>
            /// <param name="x">
            /// <para>The .</para>
            /// <para></para>
            /// </param>
            /// <param name="y">
            /// <para>The .</para>
            /// <para></para>
            /// </param>
            /// <returns>
            /// <para>The int</para>
            /// <para></para>
            /// </returns>
            public int Compare(ulong x, ulong y) => x.CompareTo(y);
        }
        private static readonly int _n = 1000000;
        private static readonly ulong _x = 10UL;
        private static readonly ulong _y = 500UL;

        /// <summary>
        /// <para>
        /// Statics the method.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The result.</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public int StaticMethod()
        {
            int result = 0;
            for (int i = 0; i < _n; i++)
            {
                result = Compare(_x, _y);
            }
            return result;
        }

        /// <summary>
        /// <para>
        /// Defaults the comparer.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The result.</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public int DefaultComparer()
        {
            var comparer = Comparer<ulong>.Default;
            int result = 0;
            for (int i = 0; i < _n; i++)
            {
                result = comparer.Compare(_x, _y);
            }
            return result;
        }

        /// <summary>
        /// <para>
        /// Compares the method reference.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The result.</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public int CompareMethodReference()
        {
            var comparer = Comparer<ulong>.Default;
            Func<ulong, ulong, int> compareReference = comparer.Compare;
            int result = 0;
            for (int i = 0; i < _n; i++)
            {
                result = compareReference(_x, _y);
            }
            return result;
        }

        /// <summary>
        /// <para>
        /// Interfaces the implementation as.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The result.</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public int InterfaceImplementationAsClass()
        {
            var comparer = new UInt64Comparer();
            int result = 0;
            for (int i = 0; i < _n; i++)
            {
                result = comparer.Compare(_x, _y);
            }
            return result;
        }
        private static int Compare(ulong x, ulong y) => x.CompareTo(y);
    }
}
