/**
 * Oddmatics.Util.Events.ICancellable -- Cancellable Event
 *
 * This source-code is part of the Oddmatics IO Utilities library by rozza of Oddmatics:
 * <<http://www.oddmatics.uk>>
 * <<http://github.com/rozniak/Oddmatics-IO>>
 *
 * Sharing, editing and general licence term information can be found inside of the "LICENCE.MD" file that should be located in the root of this project's directory structure.
 */

namespace Oddmatics.Util.Events
{
    /// <summary>
    /// Represents a cancellable event.
    /// </summary>
    public interface ICancellable
    {
        /// <summary>
        /// Gets or sets a value indicating whether the event should be cancelled.
        /// </summary>
        bool Cancel { get; set; }
    }
}
