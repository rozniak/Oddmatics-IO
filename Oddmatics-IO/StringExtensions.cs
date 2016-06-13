/**
 * Oddmatics.Util.IO.StringExtensions -- String Extension Methods
 *
 * This source-code is part of the Oddmatics IO Utilities library by rozza of Oddmatics:
 * <<http://www.oddmatics.uk>>
 * <<http://github.com/rozniak/Oddmatics-IO>>
 *
 * Sharing, editing and general licence term information can be found inside of the "LICENCE.MD" file that should be located in the root of this project's directory structure.
 */

using System;

namespace Oddmatics.Util.IO
{
    /// <summary>
    /// Provides various extension methods for strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Checks whether strings equal each other, ignoring varying case.
        /// </summary>
        /// <param name="text">The subject string.</param>
        /// <param name="comparison">The string to compare to.</param>
        /// <returns>Whether or not the strings match, ignoring case.</returns>
        public static bool EqualsIgnoreCase(this string text, string comparison)
        {
            return text.Equals(comparison, StringComparison.InvariantCultureIgnoreCase);
        }


        /// <summary>
        /// Attempts to split a string by a pattern on its first occurrence.
        /// </summary>
        /// <param name="text">The string to split.</param>
        /// <param name="pattern">The pattern to split the string by.</param>
        /// <returns>The split string at the first occurrence of the pattern, if pattern doesn't exit, returns two empty strings.</returns>
        public static string[] SplitFirstInstance(this string text, string pattern)
        {
            string[] resultingSplit = new string[] { "", "" };

            if (text.Contains(pattern))
            {
                int splitIndex = text.IndexOf(pattern, 0, text.Length, StringComparison.CurrentCulture);

                resultingSplit[0] = text.Substring(0, splitIndex);
                resultingSplit[1] = text.Substring(splitIndex + pattern.Length, text.Length - (pattern.Length + splitIndex));
            }

            return resultingSplit;
        }
    }
}