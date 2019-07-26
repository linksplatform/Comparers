using System;
using System.Collections.Generic;

namespace Platform.Comparers
{
    public class Comparer<T> : IComparer<T>
    {
        private readonly Func<T, T, int> _compare;

        public Comparer(IComparer<T> comparer)
            : this(comparer.Compare)
        {
        }

        public Comparer(Func<T, T, int> compare) => _compare = compare;

        public int Compare(T x, T y) => _compare(x, y);

        public static implicit operator Comparer<T>(Func<T, T, int> compare) => new Comparer<T>(compare);

        public static implicit operator Func<T, T, int>(Comparer<T> comparer) => comparer._compare;
    }
}
