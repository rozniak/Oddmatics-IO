/**
 * Oddmatics.Util.Collections.IListExtensions -- IList Extension Methods
 *
 * This source-code is part of the Oddmatics IO Utilities library by rozza of Oddmatics:
 * <<http://www.oddmatics.uk>>
 * <<http://github.com/rozniak/Oddmatics-IO>>
 *
 * Sharing, editing and general licence term information can be found inside of the "LICENCE.MD" file that should be located in the root of this project's directory structure.
 */

using System.Collections.Generic;
using System.Linq;

namespace Oddmatics.Util.Collections
{
    /// <summary>
    /// Provides extension methods for the IList&lt;T&gt; interface.
    /// </summary>
    public static class IListExtensions
    {
        /// <summary>
        /// Compares the contents of two IList&lt;T&gt; objects.
        /// </summary>
        /// <typeparam name="T">The generic type used by the lists.</typeparam>
        /// <param name="list1">The first list.</param>
        /// <param name="list2">The second list.</param>
        /// <returns>True if the contents of both ILists match.</returns>
        public static bool Match<T>(this IList<T> list1, IList<T> list2)
        {
            var source = new Dictionary<T, int>();

            foreach (T item in list1)
            {
                if (source.ContainsKey(item))
                    source[item]++;
                else
                    source.Add(item, 1);
            }

            foreach (T item in list2)
            {
                if (source.ContainsKey(item))
                    source[item]--;
                else
                    return false;
            }

            return source.Values.All(leftover => leftover == 0);
        }
    }
}
