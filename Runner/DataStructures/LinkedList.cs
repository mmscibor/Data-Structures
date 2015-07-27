
using System;
using System.Collections;

namespace DataStructures
{
    /// <summary>
    /// Linked List has O(N) look up time and O(c) insertion time. 
    /// </summary>
    /// <typeparam name="T">Type of object this linked list will hold.</typeparam>
    public class LinkedList<T> : IEnumerable
    {
        // Meta information about the linked list.
        public Int32 Count { get; set; }

        // Core information about the linked list. 
        private readonly Node _rootNode;
        private Node _head;

        public LinkedList()
        {
            Count = 0;

            _rootNode = new Node {NextNode = null};
            _head = _rootNode;
        }

        /// <summary>
        /// Adds a new entry to the linked list.
        /// </summary>
        /// <param name="value">Value associated with the newly added node.</param>
        public void Add(T value)
        {
            var newNode = new Node()
            {
                NextNode = null,
                Value = value
            };

            _head.NextNode = newNode;
            _head = newNode;

            Count++;
        }

        /// <summary>
        /// Removes an entry from the linked list.
        /// </summary>
        /// <param name="value">Value associated with the node to be removed.</param>
        public void Remove(T value)
        {
            var iterator = _rootNode.NextNode;

            while (iterator != null)
            {
                if (iterator.NextNode.Value.Equals(value))
                {
                    var temporaryNode = iterator.NextNode;
                    iterator.NextNode = temporaryNode.NextNode;

                    temporaryNode = null; // This will be removed when the GC runs.
                    Count--;

                    return;
                }

                iterator = iterator.NextNode;
            }
        }

        /// <summary>
        /// Checks if the particular value exists within the linked list.
        /// </summary>
        /// <param name="value">Value which method attempts to find.</param>
        /// <returns>True if value is contained in the list. False otherwise.</returns>
        public bool Contains(T value)
        {
            var iterator = _rootNode.NextNode;

            while (iterator != null)
            {
                if (iterator.Value.Equals(value)) return true;

                iterator = iterator.NextNode;
            }

            return false;
        }

        public IEnumerator GetEnumerator()
        {
            return new LinkedListEnumerator(Count, _rootNode);
        }

        /// <summary>
        /// Building block of linked list. The list is composed of many of these nodes.
        /// </summary>
        private class Node
        {
            public T Value { get; set; }
            public Node NextNode { get; set; }
        }

        /// <summary>
        /// Allows the linked list to be treated as a C# collection and iterated.
        /// </summary>
        private class LinkedListEnumerator : IEnumerator
        {
            private readonly Int32 _count;
            private readonly Node _root;
            private Node _iterator;
            private int _position;

            public LinkedListEnumerator(Int32 count, Node root)
            {
                _count = count;
                _root = root;
                _iterator = _root;
                _position = -1;
            }

            public bool MoveNext()
            {
                _iterator = _iterator.NextNode;
                _position++;
                return _position < _count;
            }

            public void Reset()
            {
                _iterator = _root;
                _position = -1;
            }

            public object Current
            {
                get { return _iterator.Value; }
            }
        }
    }
}
