/**
 * Oddmatics.Util.Events.ValueChangedEvent -- Key-Value Collection Value Changed Event
 *
 * This source-code is part of the Oddmatics IO Utilities library by rozza of Oddmatics:
 * <<http://www.oddmatics.uk>>
 * <<http://github.com/rozniak/Oddmatics-IO>>
 *
 * Sharing, editing and general licence term information can be found inside of the "LICENCE.MD" file that should be located in the root of this project's directory structure.
 */

using System;

namespace Oddmatics.Util.Events
{
    /// <summary>
    /// Represents the method that will handle the ValueChanged event of a KeyValueEventCollection.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">A ValueChangedEventArgs object that contains event data.</param>
    public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);


    /// <summary>
    /// Provides data for the KeyValueEventCollection.ValueChanged event.
    /// </summary>
    public class ValueChangedEventArgs : EventArgs, ICancellable
    {
        /// <summary>
        /// Gets or sets a value indicating whether the event should be cancelled.
        /// </summary>
        public bool Cancel
        {
            get { return this._Cancel; }
            set
            {
                if (!value)
                    throw new InvalidOperationException("ValueChangedEventArgs.Cancel: Cannot set cancel to false.");

                this._Cancel = value;
            }
        }
        private bool _Cancel;

        /// <summary>
        /// Gets the key of the associated changed value.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Gets the new value that was assigned.
        /// </summary>
        public string Value { get; private set; }

        
        /// <summary>
        /// Initializes a new instance of the ValueChangedEventArgs class.
        /// </summary>
        /// <param name="key">The key associated with the event.</param>
        /// <param name="value">The new value assigned.</param>
        public ValueChangedEventArgs(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
