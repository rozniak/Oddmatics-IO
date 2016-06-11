/**
 * Oddmatics.Util.IO.Files -- File/File System Management
 *
 * This source-code is part of the Oddmatics IO Utilities library by rozza of Oddmatics:
 * <<http://www.oddmatics.uk>>
 * <<http://roz.world>>
 * <<http://github.com/rozniak/Oddmatics-IO>>
 *
 * Sharing, editing and general licence term information can be found inside of the "LICENCE.MD" file that should be located in the root of this project's directory structure.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace Oddmatics.Util.IO
{
    /// <summary>
    /// Provides general file system functions.
    /// </summary>
    public static class FileSystem
    {
        /// <summary>
        /// Gets a binary file with the specified filename from the disk.
        /// </summary>
        /// <param name="filename">The filename of the file to get.</param>
        /// <returns>The file contents if it exists.</returns>
        public static IList<byte> GetBinaryFile(string filename)
        {
            if (File.Exists(filename))
                return File.ReadAllBytes(filename);

            return null;
        }

        /// <summary>
        /// Gets all the file names from a given directory which start with the specified prefix.
        /// </summary>
        /// <param name="directory">The directory to search.</param>
        /// <param name="prefix">The prefix to match.</param>
        /// <param name="fileType">The filetype to restrict to.</param>
        /// <returns>All the files discovered from the specified directory that matched the given prefix.</returns>
        public static IList<string> GetFilesByPrefix(string directory, string prefix, string fileType = "")
        {
            var matchedFiles = new List<string>();

            if (Directory.Exists(directory))
            {
                string[] filesDiscovered = Directory.GetFiles(directory);

                foreach (string file in filesDiscovered)
                {
                    string fileName = Path.GetFileName(file);

                    if (fileName.StartsWith(prefix) &&
                        (fileType == "" || Path.GetExtension(file) == fileType))
                        matchedFiles.Add(file);
                }
            }

            return matchedFiles.AsReadOnly();
        }

        /// <summary>
        /// Gets the MD5 hash of a file with the specified filename from the disk.
        /// </summary>
        /// <param name="filename">The filename of the file to get the MD5 hash from.</param>
        /// <returns>The MD5 hash of the file, if it exists.</returns>
        public static string GetMD5Hash(string filename)
        {
            if (File.Exists(filename))
            {
                using (var md5 = MD5.Create())
                using (var stream = File.OpenRead(filename))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "");
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets a text file with the specified filename from the disk.
        /// </summary>
        /// <param name="filename">The filename of the file to get.</param>
        /// <returns>The file contents if it exists.</returns>
        public static IList<string> GetTextFile(string filename)
        {
            List<string> fileContents = new List<string>();

            if (File.Exists(filename))
            {
                using (StreamReader r = new StreamReader(filename))
                {
                    do
                    {
                        fileContents.Add(r.ReadLine());
                    } while (r.Peek() > -1);
                }

                return fileContents.AsReadOnly();
            }

            return null;
        }

        /// <summary>
        /// Makes a directory if it doesn't already exist.
        /// </summary>
        /// <param name="directory">The directory to create.</param>
        public static void MakeDirectory(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        /// <summary>
        /// Writes a binary file with the specified filename to the disk.
        /// </summary>
        /// <param name="filename">The filename of the file to write.</param>
        /// <param name="contents">The contents of the file to write.</param>
        /// <returns>Whether the file was successfully written or not.</returns>
        public static bool PutBinaryFile(string filename, byte[] contents)
        {
            try
            {
                using (FileStream w = new FileStream(filename, FileMode.Create, FileAccess.Write))
                {
                    w.Write(contents, 0, contents.Length);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Writes a text file with the specified filename to the disk.
        /// </summary>
        /// <param name="filename">The filename of the file to write.</param>
        /// <param name="contents">The contents of the file to write.</param>
        /// <returns>Whether the file was successfully written or not.</returns>
        public static bool PutTextFile(string filename, string[] contents)
        {
            try
            {
                using (StreamWriter w = new StreamWriter(filename))
                {
                    for (int i = 0; i <= contents.Length - 1; i++)
                    {
                        w.WriteLine(contents[i]);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Reads an INI file into a dictionary for easy reading
        /// </summary>
        /// <param name="filepath">The file path of the INI file to read.</param>
        /// <returns>A dictionary containing the variable names as keys, alongside their values.</returns>
        public static Dictionary<string, string> ReadINIToDictionary(string filepath)
        {
            IList<string> iniFile = GetTextFile(filepath);

            if (iniFile != null)
            {
                var finalDictionary = new Dictionary<string, string>();

                foreach (string line in iniFile)
                {
                    if (!line.StartsWith("#")) // Ignore comments
                    {
                        string[] resultingSplit = StringFunction.SplitFirstInstance(":", line);

                        if (resultingSplit[0] != "" && resultingSplit[1] != "") // Check that this line is a valid property
                        {
                            if (finalDictionary.ContainsKey(resultingSplit[0]))
                                finalDictionary[resultingSplit[0]] = resultingSplit[1];
                            else
                                finalDictionary.Add(resultingSplit[0], resultingSplit[1]);
                        }
                    }
                }

                return finalDictionary;
            }

            return null;
        }
    }
}