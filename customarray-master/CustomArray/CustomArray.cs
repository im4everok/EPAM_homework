using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CustomArray
{
    public class CustomArray<T> : IEnumerable<T>
    {
        private readonly T[] array;
        private readonly int first;
        /// <summary>
        /// Should return first index of array
        /// </summary>
        public int First 
        {
            get => first;
        }

        /// <summary>
        /// Should return last index of array
        /// </summary>
        public int Last 
        {
            get => Length + First - 1;
        }

        /// <summary>
        /// Should return length of array
        /// <exception cref="ArgumentException">Thrown when value was smaller than 0</exception>
        /// </summary>
        public int Length 
        {
            get
            {
                return Array.Length;
            }
        }

        /// <summary>
        /// Should return array 
        /// </summary>
        public T[] Array
        { 
            get=>array; 
        }

        /// <summary>
        /// Constructor with first index and length
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="length">Length</param>         
        public CustomArray(int first, int length)
        {
            if (length <= 0) throw new ArgumentException("length");
            array = new T[length];
            this.first = first; 
        }


        /// <summary>
        /// Constructor with first index and collection  
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Collection</param>
        ///  <exception cref="NullReferenceException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when count is smaler than 0</exception>
        public CustomArray(int first, IEnumerable<T> list)
        {
            if (list == null) throw new NullReferenceException("Parameter 'List' is null");
            if (!list.Any()) throw new ArgumentException("List is empty");
            array = list.ToArray();
            this.first = first;
        }

        /// <summary>
        /// Constructor with first index and params
        /// </summary>
        /// <param name="first">First Index</param>
        /// <param name="list">Params</param>
        ///  <exception cref="ArgumentNullException">Thrown when list is null</exception>
        /// <exception cref="ArgumentException">Thrown when list without elements </exception>
        public CustomArray(int first, params T[] list)
        {
            if (list == null) throw new ArgumentNullException("list");
            if (!list.Any()) throw new ArgumentException("List is empty");
            array = list;
            this.first = first;
           
        }

        /// <summary>
        /// Indexer with get and set  
        /// </summary>
        /// <param name="item">Int index</param>        
        /// <returns></returns>
        /// <exception cref="ArgumentException">Thrown when index out of array range</exception> 
        /// <exception cref="ArgumentNullException">Thrown in set  when value passed in indexer is null</exception>
        public T this[int item]
        {
            get
            {
                if (item < first || item > Last) throw new ArgumentException("item (index) is out of array range");
                return Array[item - First];
            }
            set
            {
                if(value == null) throw new ArgumentNullException("item");
                if (item < first || item > Last) throw new ArgumentException("item (index) is out of array range");
                array[item - First] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(var num in Array)
            {
                yield return num;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Array.GetEnumerator();
        }
    }
}
