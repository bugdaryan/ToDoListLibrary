using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ToDoListLibrary
{
    public class ToDoList : IEnumerable<ToDoItem>
    {
        #region Constructors
        /// <summary>
        /// Constructor with IEnumerable argument
        /// </summary>
        /// <param name="todos"></param>
        public ToDoList(IEnumerable<ToDoItem> todos)
        {
            _todos = todos.ToArray();
        }
        /// <summary>
        /// Constructor with one integer argument
        /// </summary>
        /// <param name="count">Will create an empty list with given capacity</param>
        public ToDoList(int count) : this(new ToDoItem[count])
        {
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public ToDoList() : this(1)
        {
        }

        #endregion

        #region Public properties
        /// <summary>
        /// Number of elements of the list
        /// </summary>
        public int Count { get; private set; } = 0;

        /// <summary>
        /// Number of elements that can be added without resizing initial list 
        /// </summary>
        public int Capacity => _todos.Length;

        #endregion

        #region Public functions
        /// <summary>
        /// Swaps to elements of the list
        /// </summary>
        /// <param name="i">First element</param>
        /// <param name="j">Second Element</param>
        /// <exception cref="IndexOutOfRangeException">If i or j is outside of bounds</exception>
        public void Swap(int i, int j)
        {
            CheckIndexBounds(i);
            CheckIndexBounds(j);
            if (i != j)
            {
                var tmp = _todos[i];
                _todos[i] = _todos[j];
                _todos[j] = tmp;
            }
        }

        /// <summary>
        /// Adds an ToDoItem to the end of the list
        /// </summary>
        /// <param name="item">The ToDoItem to be added to the end of the list. The value can be null</param>
        public void Add(ToDoItem item)
        {
            if (_todos.Length == Count)
            {
                ToDoItem[] arr = new ToDoItem[Count * 2];
                for (int i = 0; i < _todos.Length; i++)
                {
                    arr[i] = _todos[i];
                }

                _todos = arr;
            }

            _todos[Count] = item;
            
            Count++;
        }

        /// <summary>
        /// Removes the first occurrence of a specific ToDoItem from the list
        /// </summary>
        /// <param name="item">The ToDoItem to remove from the list. The value can be null</param>
        /// <returns>Returns false if list does not contain the item</returns>
        public bool Remove(ToDoItem item)
        {
            int index = -1;
            for (int i = 0; i < _todos.Length; i++)
            {
                if (item != _todos[i]) continue;
                index = i;
                break;
            }

            RemoveAt(index);
            return true;
        }

        /// <summary>
        /// Removes the element at the specified index of the list
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove</param>
        public void RemoveAt(int index)
        {
            if (index <= 0 || index >= Count)
            {
                return;
            }
            for (int i = index; i < Count - 1; i++)
            {
                _todos[i] = _todos[i + 1];
            }

            if(Count != 0)
            {
                Count--;
                _todos[Count] = null;
            }
        }

        #endregion

        #region Overrides and operators

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals(obj as ToDoList);
        }

        protected bool Equals(ToDoList other)
        {
            if (Count != other.Count) return false;
            for (int i = 0; i < Count; i++)
            {
                if (this[i] != other[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_todos != null ? _todos.GetHashCode() : 0) * 397) ^ Count;
            }
        }

        /// <summary>
        /// Gets or sets the element at the specified index
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set</param>
        /// <returns>Returns element at the specified index</returns>
        public ToDoItem this[int index]
        {
            get
            {
                CheckIndexBounds(index);
                return _todos[index];
            }
            set
            {
                CheckIndexBounds(index);
                _todos[index] = value;
            }
        }

        #endregion
        
        #region IEnumerable

        public IEnumerator<ToDoItem> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        #endregion

        #region Private members

        private ToDoItem[] _todos;

        #endregion

        #region Private functions
        /// <summary>
        /// Checks if index is valid
        /// </summary>
        /// <param name="index">The zero-based index to check</param>
        private void CheckIndexBounds(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index is outside of bounds");
            }
        }

        #endregion
    }
}
