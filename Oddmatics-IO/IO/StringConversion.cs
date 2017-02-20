/**
 * Oddmatics.Util.IO.StringConversion -- String Conversion Helper
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
    /// Provides helpful functions for converting strings to different values.
    /// </summary>
    public static class StringConversion
    {
        /// <summary>
        /// Outputs the converted string value into a boolean.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="maintainValue">Whether or not to maintain the original value of the output variable if the conversion fails.</param>
        /// <param name="source">The source value of the variable being set.</param>
        public static bool ToBool(string s, bool maintainValue, bool source = false)
        {
            bool newValue;
            bool conversionSuccess = bool.TryParse(s, out newValue);

            if (conversionSuccess)
                return newValue;
            else if (maintainValue)
                return source;
            else
                return false;
        }


        /// <summary>
        /// Outputs the converted string value into a byte.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="maintainValue">Whether or not to maintain the original value of the output variable if the conversion fails.</param>
        /// <param name="source">The source value of the variable being set.</param>
        public static byte ToByte(string s, bool maintainValue, byte source = 0)
        {
            byte newValue;
            bool conversionSuccess = byte.TryParse(s, out newValue);

            if (conversionSuccess)
                return newValue;
            else if (maintainValue)
                return source;
            else
                return 0;
        }


        /// <summary>
        /// Outputs the converted string value into a signed 32-bit integer.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="maintainValue">Whether or not to maintain the original value of the output variable if the conversion fails.</param>
        /// <param name="source">The source value of the variable being set.</param>
        public static int ToInt(string s, bool maintainValue, int source = 0)
        {
            int newValue;
            bool conversionSuccess = int.TryParse(s, out newValue);

            if (conversionSuccess)
                return newValue;
            else if (maintainValue)
                return source;
            else
                return 0;
        }


        /// <summary>
        /// Outputs the converted string value into a signed 64-bit integer.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="maintainValue">Whether or not to maintain the original value of the output variable if the conversion fails.</param>
        /// <param name="source">The source value of the variable being set.</param>
        public static long ToLong(string s, bool maintainValue, long source = 0)
        {
            long newValue;
            bool conversionSuccess = long.TryParse(s, out newValue);

            if (conversionSuccess)
                return newValue;
            else if (maintainValue)
                return source;
            else
                return 0;
        }


        /// <summary>
        /// Outputs the converted string value into a signed byte.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="maintainValue">Whether or not to maintain the original value of the output variable if the conversion fails.</param>
        /// <param name="source">The source value of the variable being set.</param>
        public static sbyte ToSByte(string s, bool maintainValue, sbyte source = 0)
        {
            sbyte newValue;
            bool conversionSuccess = sbyte.TryParse(s, out newValue);

            if (conversionSuccess)
                return newValue;
            else if (maintainValue)
                return source;
            else
                return 0;
        }


        /// <summary>
        /// Outputs the converted string value into a signed 16-bit integer.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="maintainValue">Whether or not to maintain the original value of the output variable if the conversion fails.</param>
        /// <param name="source">The source value of the variable being set.</param>
        public static short ToShort(string s, bool maintainValue, short source = 0)
        {
            short newValue;
            bool conversionSuccess = short.TryParse(s, out newValue);

            if (conversionSuccess)
                return newValue;
            else if (maintainValue)
                return source;
            else
                return 0;
        }


        /// <summary>
        /// Outputs the converted string value into an unsigned 32-bit integer.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="maintainValue">Whether or not to maintain the original value of the output variable if the conversion fails.</param>
        /// <param name="source">The source value of the variable being set.</param>
        public static uint ToUInt(string s, bool maintainValue, uint source = 0)
        {
            uint newValue;
            bool conversionSuccess = uint.TryParse(s, out newValue);

            if (conversionSuccess)
                return newValue;
            else if (maintainValue)
                return source;
            else
                return 0;
        }

        /// <summary>
        /// Outputs the converted string value into an unsigned 64-bit integer.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="maintainValue">Whether or not to maintain the original value of the output variable if the conversion fails.</param>
        /// <param name="source">The source value of the variable being set.</param>
        public static ulong ToULong(string s, bool maintainValue, ulong source = 0)
        {
            ulong newValue;
            bool conversionSuccess = ulong.TryParse(s, out newValue);

            if (conversionSuccess)
                return newValue;
            else if (maintainValue)
                return source;
            else
                return 0;
        }


        /// <summary>
        /// Outputs the converted string value into an unsigned 16-bit integer.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="maintainValue">Whether or not to maintain the original value of the output variable if the conversion fails.</param>
        /// <param name="source">The source value of the variable being set.</param>
        public static ushort ToUShort(string s, bool maintainValue, ushort source = 0)
        {
            ushort newValue;
            bool conversionSuccess = ushort.TryParse(s, out newValue);

            if (conversionSuccess)
                return newValue;
            else if (maintainValue)
                return source;
            else
                return 0;
        }
    }
}
