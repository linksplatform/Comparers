using System;
using System.Collections.Generic;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Comparers
{
    /// <summary>
    /// <para>
    /// Represents the comparer.
    /// </para>
    /// <para></para>
    /// </summary>
    /// <seealso cref="IComparer{T}"/>
    public class Comparer<T> : IComparer<T>
    {
        private readonly Func<T, T, int> _compare;
        /// <summary>
        /// <para>
        /// Initializes a new <see cref="Comparer"/> instance.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="comparer">
        /// <para>A comparer.</para>
        /// <para></para>
        /// </param>
        public Comparer(IComparer<T> comparer) : this(comparer.Compare) { }
        /// <summary>
        /// <para>
        /// Initializes a new <see cref="Comparer"/> instance.
        /// </para>
        /// <para></para>
        /// </summary>
        /// <param name="compare">
        /// <para>A compare.</para>
        /// <para></para>
        /// </param>
        public Comparer(Func<T, T, int> compare) => _compare = compare;
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
        public int Compare(T x, T y) => _compare(x, y);
        public static implicit operator Comparer<T>(Func<T, T, int> compare) => new Comparer<T>(compare);
        public static implicit operator Func<T, T, int>(Comparer<T> comparer) => comparer._compare;
    }
}
