/**
 * Oddmatics.Util.IO.ByteParse -- Byte Based Data Parsing Functions
 *
 * This source-code is part of the Oddmatics IO Utilities library by rozza of Oddmatics:
 * <<http://www.oddmatics.uk>>
 * <<http://github.com/rozniak/Oddmatics-IO>>
 *
 * Sharing, editing and general licence term information can be found inside of the "LICENCE.MD" file that should be located in the root of this project's directory structure.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Oddmatics.Util.IO
{
    /// <summary>
    /// Provides functions for reading binary files.
    /// </summary>
    public static class ByteParse
    {
        /// <summary>
        /// Reads the next byte into a boolean value.
        /// </summary>
        /// <param name="data">The byte data to read from.</param>
        /// <param name="currentIndex">The current index pointer.</param>
        /// <returns>Returns the next byte in the data as a boolean value.</returns>
        public static bool NextBool(IList<byte> data, ref int currentIndex)
        {
            if (currentIndex <= data.Count - 1 &&
                data[currentIndex++] == 1) return true;

            return false; // Assume that it's 0, because if it isn't, then that's just silly
        }


        /// <summary>
        /// (For stability) Reads the next byte into a byte value.
        /// </summary>
        /// <param name="data">The byte data to read from.</param>
        /// <param name="currentIndex">The current index pointer.</param>
        /// <returns>Returns the next byte in the data as a byte value.</returns>
        public static byte NextByte(IList<byte> data, ref int currentIndex)
        {
            byte conversion = 0;

            if (currentIndex <= data.Count - 1)
                conversion = data[currentIndex++];

            return conversion;
        }


        /// <summary>
        /// Reads the next 2 bytes into a Unicode character value.
        /// </summary>
        /// <param name="data">The byte data to read from.</param>
        /// <param name="currentIndex">The current index pointer.</param>
        /// <returns>Returns the next 2 bytes in the data as a character value.</returns>
        public static char NextChar(IList<byte> data, ref int currentIndex)
        {
            char conversion = '\0';

            if (currentIndex <= data.Count - 2)
            {
                conversion = UnicodeEncoding.Unicode.GetString(new byte[] { data[currentIndex], data[currentIndex + 1] })[0];
                currentIndex += 2;
            }

            return conversion;
        }


        /// <summary>
        /// Reads the next 4 bytes into an IPv4 address.
        /// </summary>
        /// <param name="data">The byte data to read from.</param>
        /// <param name="currentIndex">The current index pointer.</param>
        /// <returns>Returns the next 4 bytes in the data as an IPv4 address.</returns>
        public static IPAddress NextIPv4Address(IList<byte> data, ref int currentIndex)
        {
            IPAddress ip = IPAddress.Any;

            if (currentIndex <= data.Count - 4)
            {
                try
                {
                    ip = new IPAddress(data.Skip(currentIndex).Take(4).ToArray());
                }
                finally
                {
                    currentIndex += 4;
                }
            }

            return ip;
        }


        /// <summary>
        /// Reads the next 4 bytes into a signed 32-bit integer value.
        /// </summary>
        /// <param name="data">The byte data to read from.</param>
        /// <param name="currentIndex">The current index pointer.</param>
        /// <returns>Returns the next 4 bytes in the data as a signed 32-bit integer value.</returns>
        public static int NextInt(IList<byte> data, ref int currentIndex)
        {
            int conversion = 0;

            if (currentIndex <= data.Count - 4)
            {
                conversion = BitConverter.ToInt32(data.ToArray(), currentIndex);
                currentIndex += 4;
            }

            return conversion;
        }


        /// <summary>
        /// Reads the next 8 bytes into a signed 64-bit integer value.
        /// </summary>
        /// <param name="data">The byte data to read from.</param>
        /// <param name="currentIndex">The current index pointer.</param>
        /// <returns>Returns the next 8 bytes in the data as a signed 64-bit integer value.</returns>
        public static long NextLong(IList<byte> data, ref int currentIndex)
        {
            long conversion = 0;

            if (currentIndex <= data.Count - 8)
            {
                conversion = BitConverter.ToInt64(data.ToArray(), currentIndex);
                currentIndex += 8;
            }

            return conversion;
        }


        /// <summary>
        /// Reads the next byte into a signed byte value.
        /// </summary>
        /// <param name="data">The byte data to read from.</param>
        /// <param name="currentIndex">The current index pointer.</param>
        /// <returns>Returns the next byte in the data as a signed byte value.</returns>
        public static sbyte NextSByte(IList<byte> data, ref int currentIndex)
        {
            sbyte conversion = 0;

            if (currentIndex <= data.Count - 1)
                conversion = (sbyte)data[currentIndex++];

            return conversion;
        }


        /// <summary>
        /// Reads the next 2 bytes into a signed 16-bit integer value.
        /// </summary>
        /// <param name="data">The byte data to read from.</param>
        /// <param name="currentIndex">The current index pointer.</param>
        /// <returns>Returns the next 2 bytes in the data as a signed 16-bit integer value.</returns>
        public static short NextShort(IList<byte> data, ref int currentIndex)
        {
            short conversion = 0;

            if (currentIndex <= data.Count - 2)
            {
                conversion = BitConverter.ToInt16(data.ToArray(), currentIndex);
                currentIndex += 2;
            }

            return conversion;
        }


        /// <summary>
        /// Reads the next set of bytes into a string.
        /// </summary>
        /// <param name="data">The byte data to read from.</param>
        /// <param name="currentIndex">The current index pointer.</param>
        /// <param name="encoding">The Encoding to use.</param>
        /// <param name="includeNullCharacter">Whether to include the terminating null character in the converted string or not.</param>
        /// <returns>Returns the next set of bytes in the data as a string, terminated by a null character or end of data.</returns>
        public static string NextString(IList<byte> data, ref int currentIndex, Encoding encoding, bool includeNullCharacter = false)
        {
            if (encoding == Encoding.UTF32 || encoding == Encoding.UTF7)
                throw new ArgumentException("ByteParse.NextString: Unsupported encoding.");

            int charSize = encoding == Encoding.Unicode ? 2 : 1;
            string conversion = String.Empty;
            bool endOfString = false; // Set this to true when a null character is discovered

            do
            {
                char nextChar = '\0';

                if (charSize == 1)
                    nextChar = encoding.GetString(new byte[] { data[currentIndex] })[0];
                else
                    nextChar = encoding.GetString(new byte[] { data[currentIndex], data[currentIndex + 1] })[0];

                if (nextChar == '\0')
                {
                    if (includeNullCharacter)
                        conversion += nextChar;

                    endOfString = true;
                }
                else
                    conversion += nextChar;

                currentIndex += 2;
            } while (currentIndex < data.Count - charSize && !endOfString);

            return conversion;
        }


        /// <summary>
        /// Reads the next set of bytes into a string, using data that starts with the string's length.
        /// </summary>
        /// <param name="data">The byte data to read from.</param>
        /// <param name="currentIndex">The current index pointer.</param>
        /// <param name="bytesForLength">Set to 1 if the length of the string is recorded as a byte, 2 if it's recorded as a ushort.</param>
        /// <param name="encoding">The Encoding to use.</param>
        /// <returns>Returns the next set of bytes in the data as a string, determined by the length.</returns>
        public static string NextStringByLength(IList<byte> data, ref int currentIndex, byte bytesForLength, Encoding encoding)
        {
            if (bytesForLength != 1 && bytesForLength != 2)
                throw new ArgumentException("ByteParse.NextStringByLength: bytesForLength must be either 1 or 2.");

            if (encoding == Encoding.UTF32 || encoding == Encoding.UTF7)
                throw new ArgumentException("ByteParse.NextStringByLength: Unsupported encoding.");

            ushort length = bytesForLength == 1 ? NextByte(data, ref currentIndex) : NextUShort(data, ref currentIndex);
            var toConvert = new List<byte>();
            int endIndex = currentIndex + length;

            try
            {
                while (currentIndex < endIndex)
                {
                    toConvert.Add(data[currentIndex]);
                    currentIndex++;
                }

                return encoding.GetString(toConvert.ToArray());
            }
            catch (IndexOutOfRangeException indexEx)
            {
                return String.Empty;
            }
        }


        /// <summary>
        /// Reads the next 4 bytes into an unsigned 32-bit integer value.
        /// </summary>
        /// <param name="data">The byte data to read from.</param>
        /// <param name="currentIndex">The current index pointer.</param>
        /// <returns>Returns the next 4 bytes in the data as an unsigned 32-bit integer value.</returns>
        public static uint NextUInt(IList<byte> data, ref int currentIndex)
        {
            uint conversion = 0;

            if (currentIndex <= data.Count - 4)
            {
                conversion = BitConverter.ToUInt32(data.ToArray(), currentIndex);
                currentIndex += 4;
            }

            return conversion;
        }


        /// <summary>
        /// Reads the next 8 bytes into an unsigned 64-bit integer value.
        /// </summary>
        /// <param name="data">The byte data to read from.</param>
        /// <param name="currentIndex">The current index pointer.</param>
        /// <returns>Returns the next 8 bytes in the data as an unsigned 64-bit integer value.</returns>
        public static ulong NextULong(IList<byte> data, ref int currentIndex)
        {
            ulong conversion = 0;

            if (currentIndex <= data.Count - 8)
            {
                conversion = BitConverter.ToUInt64(data.ToArray(), currentIndex);
                currentIndex += 8;
            }

            return conversion;
        }


        /// <summary>
        /// Reads the next 2 bytes into an unsigned 16-bit integer value.
        /// </summary>
        /// <param name="data">The byte data to read from.</param>
        /// <param name="currentIndex">The current index pointer.</param>
        /// <returns>Returns the next 2 bytes in the data as an unsigned 16-bit integer value.</returns>
        public static ushort NextUShort(IList<byte> data, ref int currentIndex)
        {
            ushort conversion = 0;

            if (currentIndex <= data.Count - 2)
            {
                conversion = BitConverter.ToUInt16(data.ToArray(), currentIndex);
                currentIndex += 2;
            }

            return conversion;
        }
    }
}