/**
 * Oddmatics.Util.IO.StreamedFile -- Streamed File Reader
 *
 * This source-code is part of the Oddmatics IO Utilities library by rozza of Oddmatics:
 * <<http://www.oddmatics.uk>>
 * <<http://github.com/rozniak/Oddmatics-IO>>
 *
 * Sharing, editing and general licence term information can be found inside of the "LICENCE.MD" file that should be located in the root of this project's directory structure.
 */

using System.IO;
using System.Text;
using System.Net;

namespace Oddmatics.Util.IO
{
    public class StreamedFile
    {
        /// <summary>
        /// The FileStream object encapsulating the file being read, this field is read-only.
        /// </summary>
        private readonly FileStream Stream;

        /// <summary>
        /// The size of the file being read, this field is read-only.
        /// </summary>
        public readonly long Size;


        /// <summary>
        /// Initializes a new instance of the StreamedFile class with the specified path.
        /// </summary>
        /// <param name="filename">A path for the file in which to open a read stream to.</param>
        public StreamedFile(string filename)
        {
            Stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
            Size = Stream.Length;
        }


        /// <summary>
        /// Reads the next byte into a boolean value.
        /// </summary>
        /// <returns>The next byte from the file as a boolean value.</returns>
        public bool NextBool()
        {
            if (Stream.Position < Size)
            {
                var buffer = new byte[1];
                Stream.Read(buffer, 0, 1);

                return buffer[0] == 1;
            }

            return false; // Return false if unable to read
        }

        /// <summary>
        /// Reads the next byte.
        /// </summary>
        /// <returns>The next byte from the file.</returns>
        public byte NextByte()
        {
            if (Stream.Position < Size)
            {
                var buffer = new byte[1];
                Stream.Read(buffer, 0, 1);

                return buffer[0];
            }

            return 0; // Return 0 if unable to read
        }

        /// <summary>
        /// Reads the next 2 bytes into a UTF-16 character value.
        /// </summary>
        /// <returns>The next 2 bytes from the file as a UTF-16 character value.</returns>
        public char NextChar()
        {
            if (Stream.Position + 1 < Size)
            {
                var buffer = new byte[2];
                Stream.Read(buffer, 0, 2);

                return Encoding.Unicode.GetString(buffer)[0];
            }

            return '\0'; // Return NULL character if unable to read
        }

        /// <summary>
        /// Reads the next 4 bytes into an IPv4 address.
        /// </summary>
        /// <returns>The next 4 bytes from the file as an IPv4 address.</returns>
        public IPAddress NextIPv4Address()
        {
            if (Stream.Position + 3 < Size)
            {
                var buffer = new byte[4];
                Stream.Read(buffer, 0, 4);

                try
                {
                    return new IPAddress(buffer);
                }
                finally { }
            }

            return IPAddress.Any;
        }
    }
}
