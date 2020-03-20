using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Platform.Comparers.Benchmarks
{
    [SimpleJob]
    [MemoryDiagnoser]
    public class EqualityBenchmarks
    {
        protected class UInt64EqualityComparer : IEqualityComparer<ulong>
        {
            public bool Equals(ulong x, ulong y) => x == y;

            public int GetHashCode(ulong obj) => obj.GetHashCode();
        }

        private static readonly int _n = 1000000;
        private static readonly ulong _x = 10UL;
        private static readonly ulong _y = 500UL;

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
