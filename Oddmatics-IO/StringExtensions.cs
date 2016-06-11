/**
 * Oddmatics.Util.IO.StringExtensions -- String Extension Methods
 *
 * This source-code is part of the Oddmatics IO Utilities library by rozza of Oddmatics:
 * <<http://www.oddmatics.uk>>
 * <<http://roz.world>>
 * <<http://github.com/rozniak/Oddmatics-IO>>
 *
 * Sharing, editing and general licence term information can be found inside of the "LICENCE.MD" file that should be located in the root of this project's directory structure.
 */

using System;

namespace Oddmatics.Util.IO
{
    public static class StringFunction
    {
        /// <summary>
        /// Attempts to split a string by a pattern on its first occurrence.
        /// </summary>
        /// <param name="pattern">The pattern to split the string by.</param>
        /// <param name="text">The string to split.</param>
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