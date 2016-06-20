/**
 * Oddmatics.Util.IO.GetBytesExtensions -- GetBytes() Extension Methods
 *
 * This source-code is part of the Oddmatics IO Utilities library by rozza of Oddmatics:
 * <<http://www.oddmatics.uk>>
 * <<http://github.com/rozniak/Oddmatics-IO>>
 *
 * Sharing, editing and general licence term information can be found inside of the "LICENCE.MD" file that should be located in the root of this project's directory structure.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Oddmatics.Util.IO
{
    /// <summary>
    /// Provides GetBytes() extension methods for fundamental types.
    /// </summary>
    public static class GetBytesExtensions
    {
        /// <summary>
        /// Gets the subject bool as a byte array.
        /// </summary>
        /// <param name="subject">The subject bool.</param>
        /// <returns>A byte array representing the subject bool.</returns>
        public static byte[] GetBytes(this bool subject)
        {
            return new byte[] { Convert.ToByte(subject) };
        }


        /// <summary>
        /// Gets the subject int as a byte array.
        /// </summary>
        /// <param name="subject">The subject int.</param>
        /// <returns>A byte array representing the subject int.</returns>
        public static byte[] GetBytes(this int subject)
        {
            var data = new List<byte>();

            for (int i = 0; i <= 3; i++)
            {
                data.Add((byte)(subject >> (24 - i * 8)));
            }

            return data.ToArray();
        }


        /// <summary>
        /// Gets the subject long as a byte array.
        /// </summary>
        /// <param name="subject">The subject long.</param>
        /// <returns>A byte array representing the subject long.</returns>
        public static byte[] GetBytes(this long subject)
        {
            var data = new List<byte>();

            for (int i = 0; i <= 7; i++)
            {
                data.Add((byte)(subject >> (56 - i * 8)));
            }

            return data.ToArray();
        }


        /// <summary>
        /// Gets the subject short as a byte array.
        /// </summary>
        /// <param name="subject">The subject short.</param>
        /// <returns>A byte array representing the subject short.</returns>
        public static byte[] GetBytes(this short subject)
        {
            return new byte[] { (byte)(subject >> 8),
                (byte)(subject & 255) };
        }


        /// <summary>
        /// Gets the subject string (UTF16 format) as a byte array with a terminating character.
        /// </summary>
        /// <param name="subject">The subject string.</param>
        /// <returns>A byte array containing the results of encoding the specified string with a null terminator appended.</returns>
        public static byte[] GetBytesNullTerminated(this string subject)
        {
            return UnicodeEncoding.Unicode.GetBytes(subject + '\0');
        }


        /// <summary>
        /// Gets the subject string (UTF16 format) as a byte array starting with the string's length.
        /// </summary>
        /// <param name="subject">The subject string.</param>
        /// <param name="bytesForLength">Set to 1 if the length of the string is to be recorded as a byte, 2 to record as a ushort.</param>
        /// <returns>A byte array containing the results of encoding the specified string with a null terminator appended.</returns>
        public static byte[] GetBytesByLength(this string subject, byte bytesForLength)
        {
            if (bytesForLength != 1 && bytesForLength != 2)
                throw new ArgumentException("GetBytesExtensions.GetBytesByLength: bytesForLength must be either 1 or 2.");

            if (subject.Length == 0)
                return new byte[] { 0 };

            var data = new List<byte>();

            if (bytesForLength == 1 && subject.Length < 256)
                data.Add((byte)subject.Length);
            else if (bytesForLength == 2 && subject.Length < ushort.MaxValue)
                data.AddRange(((ushort)subject.Length).GetBytes());
            else
                throw new ArgumentException("GetBytesExtensions.GetBytesByLength: subject too long for length encoding.");

            data.AddRange(UnicodeEncoding.Unicode.GetBytes(subject));

            return data.ToArray();
        }


        /// <summary>
        /// Gets the subject uint as a byte array.
        /// </summary>
        /// <param name="subject">The subject uint.</param>
        /// <returns>A byte array representing the subject uint.</returns>
        public static byte[] GetBytes(this uint subject)
        {
            var data = new List<byte>();

            for (int i = 0; i <= 3; i++)
            {
                data.Add((byte)(subject >> (24 - i * 8)));
            }

            return data.ToArray();
        }


        /// <summary>
        /// Gets the subject ulong as a byte array.
        /// </summary>
        /// <param name="subject">The subject ulong.</param>
        /// <returns>A byte array representing the subject ulong.</returns>
        public static byte[] GetBytes(this ulong subject)
        {
            var data = new List<byte>();

            for (int i = 0; i <= 7; i++)
            {
                data.Add((byte)(subject >> (56 - i * 8)));
            }

            return data.ToArray();
        }


        /// <summary>
        /// Gets the subject ushort as a byte array.
        /// </summary>
        /// <param name="subject">The subject ushort.</param>
        /// <returns>A byte array representing the subject ushort.</returns>
        public static byte[] GetBytes(this ushort subject)
        {
            return new byte[] { (byte)(subject >> 8),
                (byte)(subject & 255) };
        }
    }
}
