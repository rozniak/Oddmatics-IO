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
        /// Gets the amount of items inside the stack.
        /// </summary>
        public int Count { get { return InternalList.Count; } }

        /// <summary>
        /// Gets the max capacity of this CappedStack.
        /// </summary>
        public int Size { get; private set; }


        /// <summary>
        /// Gets or sets the List object used internally.
        /// </summary>
        private List<T> InternalList;


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
        /// Gets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get.</param>
        /// <returns>The element at the specified index.</returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Size - 1)
                    throw new IndexOutOfRangeException();
                else
                {
                    if (index > InternalList.Count - 1)
                        return default(T);

                    return InternalList[index];
                }
            }
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
