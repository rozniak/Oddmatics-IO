/**
 * Oddmatics.Util.Collections.KeyValueEventCollection -- Key-Value Collection with Event
 *
 * This source-code is part of the Oddmatics IO Utilities library by rozza of Oddmatics:
 * <<http://www.oddmatics.uk>>
 * <<http://github.com/rozniak/Oddmatics-IO>>
 *
 * Sharing, editing and general licence term information can be found inside of the "LICENCE.MD" file that should be located in the root of this project's directory structure.
 */

using Oddmatics.Util.Events;
using System;
using System.Collections.Generic;

namespace Oddmatics.Util.Collections
{
    /// <summary>
    /// Represents a collection for handling configurations by firing events on changes.
    /// </summary>
    public class KeyValueEventCollection
    {
        /// <summary>
        /// Gets or sets the internal settings collection.
        /// </summary>
        private Dictionary<string, string> Settings { get; set; }


        /// <summary>
        /// Occurs when a value in the collection is changed.
        /// </summary>
        public event ValueChangedEventHandler ValueChanged;


        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get or set.</param>
        /// <returns>The value associated with the specified key. If the specified key is not found, a get operation will return null, and a set operation creates a new element with the specifed key.</returns>
        public string this[string key]
        {
            get
            {
                string lowKey = key.ToLower();

                if (Settings.ContainsKey(lowKey))
                    return Settings[lowKey];

                return null;
            }

            set
            {
                if (value == null)
                    throw new InvalidOperationException("ConfigurationCollection[key].set: Not allowed to set a value to null. If your aim was to remove a key, use Unset(key) instead.");

                string lowKey = key.ToLower();

                if (Settings.ContainsKey(lowKey))
                {
                    Settings[lowKey] = value;
                    ValueChanged?.Invoke(this, new ValueChangedEventArgs(lowKey, value));
                }
                else
                    Settings.Add(lowKey, value);
            }
        }


        /// <summary>
        /// Ensures that the specified key is set. If it does not exist, it will be created and assigned a default String.Empty value.
        /// </summary>
        /// <param name="key">The key to ensure is set.</param>
        public void EnsureSet(string key)
        {
            string lowKey = key.ToLower();

            if (!Settings.ContainsKey(lowKey))
                Settings.Add(lowKey, String.Empty);
        }

        /// <summary>
        /// Removes the specified key if it exists in the collection.
        /// </summary>
        /// <param name="key">The key to unset.</param>
        public void Unset(string key)
        {
            string lowKey = key.ToLower();

            if (Settings.ContainsKey(lowKey))
            {
                Settings.Remove(lowKey);
                ValueChanged?.Invoke(this, new ValueChangedEventArgs(lowKey, null));
            }
        }
    }
}
