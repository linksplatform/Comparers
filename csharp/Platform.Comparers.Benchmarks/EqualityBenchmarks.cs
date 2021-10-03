using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Platform.Comparers.Benchmarks
{
    /// <summary>
    /// <para>
    /// Represents the equality benchmarks.
    /// </para>
    /// <para></para>
    /// </summary>
    [SimpleJob]
    [MemoryDiagnoser]
    public class EqualityBenchmarks
    {
        /// <summary>
        /// <para>
        /// Represents the int 64 equality comparer.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <seealso cref="IEqualityComparer{ulong}"/>
        protected class UInt64EqualityComparer : IEqualityComparer<ulong>
        {
            /// <summary>
            /// <para>
            /// Determines whether this instance equals.
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
            /// <para>The bool</para>
            /// <para></para>
            /// </returns>
            public bool Equals(ulong x, ulong y) => x == y;

            /// <summary>
            /// <para>
            /// Gets the hash code using the specified obj.
            /// </para>
            /// <para></para>
            /// </summary>
            /// <param name="obj">
            /// <para>The obj.</para>
            /// <para></para>
            /// </param>
            /// <returns>
            /// <para>The int</para>
            /// <para></para>
            /// </returns>
            public int GetHashCode(ulong obj) => obj.GetHashCode();
        }

        private static readonly int _n = 1000000;
        private static readonly ulong _x = 10UL;
        private static readonly ulong _y = 500UL;

        /// <summary>
        /// <para>
        /// Determines whether this instance generic wrapper around object static equals.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The result.</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public bool GenericWrapperAroundObjectStaticEquals()
        {
            bool result = true;
            for (int i = 0; i < _n; i++)
            {
                result = EqualsStaticMethod(_x, _y);
            }
            return result;
        }

        /// <summary>
        /// <para>
        /// Determines whether this instance generic wrapper around object member equals.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The result.</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public bool GenericWrapperAroundObjectMemberEquals()
        {
            bool result = true;
            for (int i = 0; i < _n; i++)
            {
                result = EqualsMemberMethod(_x, _y);
            }
            return result;
        }

        /// <summary>
        /// <para>
        /// Determines whether this instance static method wrapper around equals operator.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The result.</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public bool StaticMethodWrapperAroundEqualsOperator()
        {
            bool result = true;
            for (int i = 0; i < _n; i++)
            {
                result = EqualsOperator(_x, _y);
            }
            return result;
        }

        /// <summary>
        /// <para>
        /// Determines whether this instance default equality comparer.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The result.</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public bool DefaultEqualityComparer()
        {
            var equalityComparer = EqualityComparer<ulong>.Default;
            bool result = true;
            for (int i = 0; i < _n; i++)
            {
                result = equalityComparer.Equals(_x, _y);
            }
            return result;
        }

        /// <summary>
        /// <para>
        /// Determines whether this instance equals method reference.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The result.</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public bool EqualsMethodReference()
        {
            var equalityComparer = new UInt64EqualityComparer();
            Func<ulong, ulong, bool> equalsReference = equalityComparer.Equals;
            bool result = true;
            for (int i = 0; i < _n; i++)
            {
                result = equalsReference(_x, _y);
            }
            return result;
        }

        /// <summary>
        /// <para>
        /// Determines whether this instance interface implementation as.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The result.</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public bool InterfaceImplementationAsClass()
        {
            var equalityComparer = new UInt64EqualityComparer();
            bool result = true;
            for (int i = 0; i < _n; i++)
            {
                result = equalityComparer.Equals(_x, _y);
            }
            return result;
        }

        /// <summary>
        /// <para>
        /// Determines whether this instance default comparer.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <returns>
        /// <para>The result.</para>
        /// <para></para>
        /// </returns>
        [Benchmark]
        public bool DefaultComparer()
        {
            var comparer = Comparer<ulong>.Default;
            bool result = true;
            for (int i = 0; i < _n; i++)
            {
                result = comparer.Compare(_x, _y) == 0;
            }
            return result;
        }

        private static bool EqualsStaticMethod<T>(T x, T y) => Equals(x, y);

        private static bool EqualsMemberMethod<T>(T x, T y) => x.Equals(y);

        private static bool EqualsOperator(ulong x, ulong y) => x == y;
    }
}
