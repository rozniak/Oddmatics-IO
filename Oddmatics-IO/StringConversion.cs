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
        /// <param name="output">Reference to the output variable.</param>
        public static void ToBool(string s, bool maintainValue, ref bool output)
        {
            bool newValue;
            bool conversionSuccess = bool.TryParse(s, out newValue);

            if (conversionSuccess)
                output = newValue;
            else if (!maintainValue)
                output = false;
        }


        /// <summary>
        /// Outputs the converted string value into a byte.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="maintainValue">Whether or not to maintain the original value of the output variable if the conversion fails.</param>
        /// <param name="output">Reference to the output variable.</param>
        public static void ToByte(string s, bool maintainValue, ref byte output)
        {
            byte newValue;
            bool conversionSuccess = byte.TryParse(s, out newValue);

            if (conversionSuccess)
                output = newValue;
            else if (!maintainValue)
                output = 0;
        }


        /// <summary>
        /// Outputs the converted string value into a signed 32-bit integer.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="maintainValue">Whether or not to maintain the original value of the output variable if the conversion fails.</param>
        /// <param name="output">Reference to the output variable.</param>
        public static void ToInt(string s, bool maintainValue, ref int output)
        {
            int newValue;
            bool conversionSuccess = int.TryParse(s, out newValue);

            if (conversionSuccess)
                output = newValue;
            else if (!maintainValue)
                output = 0;
        }


        /// <summary>
        /// Outputs the converted string value into a signed 64-bit integer.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="maintainValue">Whether or not to maintain the original value of the output variable if the conversion fails.</param>
        /// <param name="output">Reference to the output variable.</param>
        public static void ToLong(string s, bool maintainValue, ref long output)
        {
            long newValue;
            bool conversionSuccess = long.TryParse(s, out newValue);

            if (conversionSuccess)
                output = newValue;
            else if (!maintainValue)
                output = 0;
        }


        /// <summary>
        /// Outputs the converted string value into a signed byte.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="maintainValue">Whether or not to maintain the original value of the output variable if the conversion fails.</param>
        /// <param name="output">Reference to the output variable.</param>
        public static void ToSByte(string s, bool maintainValue, ref sbyte output)
        {
            sbyte newValue;
            bool conversionSuccess = sbyte.TryParse(s, out newValue);

            if (conversionSuccess)
                output = newValue;
            else if (!maintainValue)
                output = 0;
        }


        /// <summary>
        /// Outputs the converted string value into a signed 16-bit integer.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="maintainValue">Whether or not to maintain the original value of the output variable if the conversion fails.</param>
        /// <param name="output">Reference to the output variable.</param>
        public static void ToShort(string s, bool maintainValue, ref short output)
        {
            short newValue;
            bool conversionSuccess = short.TryParse(s, out newValue);

            if (conversionSuccess)
                output = newValue;
            else if (!maintainValue)
                output = 0;
        }


        /// <summary>
        /// Outputs the converted string value into an unsigned 32-bit integer.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="maintainValue">Whether or not to maintain the original value of the output variable if the conversion fails.</param>
        /// <param name="output">Reference to the output variable.</param>
        public static void ToUInt(string s, bool maintainValue, ref uint output)
        {
            uint newValue;
            bool conversionSuccess = uint.TryParse(s, out newValue);

            if (conversionSuccess)
                output = newValue;
            else if (!maintainValue)
                output = 0;
        }

        /// <summary>
        /// Outputs the converted string value into an unsigned 64-bit integer.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="maintainValue">Whether or not to maintain the original value of the output variable if the conversion fails.</param>
        /// <param name="output">Reference to the output variable.</param>
        public static void ToULong(string s, bool maintainValue, ref ulong output)
        {
            ulong newValue;
            bool conversionSuccess = ulong.TryParse(s, out newValue);

            if (conversionSuccess)
                output = newValue;
            else if (!maintainValue)
                output = 0;
        }


        /// <summary>
        /// Outputs the converted string value into an unsigned 16-bit integer.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="maintainValue">Whether or not to maintain the original value of the output variable if the conversion fails.</param>
        /// <param name="output">Reference to the output variable.</param>
        public static void ToUShort(string s, bool maintainValue, ref ushort output)
        {
            ushort newValue;
            bool conversionSuccess = ushort.TryParse(s, out newValue);

            if (conversionSuccess)
                output = newValue;
            else if (!maintainValue)
                output = 0;
        }
    }
}
