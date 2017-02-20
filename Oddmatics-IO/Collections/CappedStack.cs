/**
 * Oddmatics.Util.Collections.CappedStack -- Capped Stack Data Structure
 *
 * This source-code is part of the Oddmatics IO Utilities library by rozza of Oddmatics:
 * <<http://www.oddmatics.uk>>
 * <<http://github.com/rozniak/Oddmatics-IO>>
 *
 * Sharing, editing and general licence term information can be found inside of the "LICENCE.MD" file that should be located in the root of this project's directory structure.
 */

using System;
using System.Collections.Generic;

namespace Oddmatics.Util.Collections
{
    /// <summary>
    /// Represents a stack data structure with a capped size.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CappedStack<T>
    {
        /// <summary>
        /// Gets or sets the List object used internally.
        /// </summary>
        private List<T> InternalList;

        /// <summary>
        /// Gets the max capacity of this CappedStack.
        /// </summary>
        public int Size { get; private set; }


        /// <summary>
        /// Initialises a new instance of the CappedStack class with a max capacity.
        /// </summary>
        /// <param name="size">The maximum capacity of this CappedStack.</param>
        public CappedStack(int size)
        {
            if (size < 1)
                throw new ArgumentException("CappedStack.New: Invalid size specified.");

            Size = size;
            InternalList = new List<T>();
        }


        /// <summary>
        /// Retrieves the top item without popping it from the stack.
        /// </summary>
        /// <returns>The top item on the stack.</returns>
        public T Peek()
        {
            return InternalList[InternalList.Count - 1];
        }

        /// <summary>
        /// Retrieves the top item and pops it from the stack.
        /// </summary>
        /// <returns>The top item on the stack.</returns>
        public T Pop()
        {
            T item = InternalList[InternalList.Count - 1];
            InternalList.RemoveAt(InternalList.Count - 1);

            return item;
        }

        /// <summary>
        /// Pushes an item to the top of the stack.
        /// </summary>
        /// <param name="item">The item to push to the top of the stack.</param>
        public void Push(T item)
        {
            InternalList.Add(item);

            if (InternalList.Count > Size)
                InternalList.RemoveAt(0);
        }
    }
}
