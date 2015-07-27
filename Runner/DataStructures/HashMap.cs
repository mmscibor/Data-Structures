
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    /// <summary>
    /// Collection which allows you to store keys associated with values. Insertions and lookups are both O(c) time on average.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class HashMap<TKey, TValue> : IEnumerable
    {
        // Core information about the Hash Map.
        private LinkedList<KeyValuePair>[] _coreArray;
        private Int32 _coreArraySize;

        // Meta information about the Hash Map.
        public Int32 Count { get; set; }

        /// <summary>
        /// Initialization. This means the underlying array of linked lists needs to be properly initialized. 
        /// Initialization is for this reason quite costly. 
        /// </summary>
        public HashMap()
        {
            Count = 0;

            _coreArraySize = 100;
            _coreArray = new LinkedList<KeyValuePair>[_coreArraySize];

            for (int i = 0; i < _coreArraySize; i++)
            {
                _coreArray[i] = new LinkedList<KeyValuePair>();
            }
        }

        public void Put(TKey key, TValue value)
        {
            int hashedKey = key.GetHashCode() % _coreArraySize;

            var keyValuePair = new KeyValuePair()
            {
                Key = key,
                Value = value
            };

            foreach (KeyValuePair keyValueEntry in _coreArray[hashedKey])
            {
                // If the key is found, update its value and exit.
                if (keyValueEntry.Key.Equals(key))
                {
                    keyValueEntry.Value = value;
                    return;
                }
            }

            // If the key is not found, append it to the end of the underlying linked list.
            _coreArray[hashedKey].Add(keyValuePair);
            Count++;

            if (Count == _coreArraySize) ResizeCore();
        }

        /// <summary>
        /// Attempt to retrieve the value associated with a particular key.
        /// </summary>
        /// <param name="key">Key whose value the method attempts to find.</param>
        /// <returns>Returns the value associated with the key. Null if the key is not found.</returns>
        public object GetValue(TKey key)
        {
            int hashedKey = key.GetHashCode() % _coreArraySize;

            // Go the to linked list where this key is potentially stored and try to find it.
            foreach (KeyValuePair keyValueEntry in _coreArray[hashedKey])
            {
                if (keyValueEntry.Key.Equals(key)) return keyValueEntry.Value;
            }

            // If the key is not found, return null.
            return null;
        }

        /// <summary>
        /// On occasion the Hash Map's core array gets too dense, so we expand it.
        /// This means occasionally insertion is O(c) but we double the core size
        /// so that we can accommodate rapid growth of the Hash Map.
        /// </summary>
        private void ResizeCore()
        {
            _coreArraySize *= 2;
            var newCore = new LinkedList<KeyValuePair>[_coreArraySize];

            for (int i = 0; i < _coreArraySize; i++) newCore[i] = new LinkedList<KeyValuePair>();

            foreach (var container in _coreArray)
            {
                foreach (KeyValuePair keyValueEntry in container)
                {
                    int hashedValue = keyValueEntry.Key.GetHashCode() % _coreArraySize;

                    newCore[hashedValue].Add(keyValueEntry);
                }
            }

            _coreArray = newCore;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class KeyValuePair
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }

        private class HashMapEnumerator : IEnumerator
        {


            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public object Current { get; private set; }
        }
    }
}
