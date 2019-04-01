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

        public ToDoList(IEnumerable<ToDoItem> todos)
        {
            _todos = todos.ToArray();
        }

        public ToDoList(int count) : this(new ToDoItem[count])
        {
        }

        public ToDoList() : this(1)
        {
        }

        #endregion

        #region Public properties

        public int Count { get; private set; } = 0;

        public int Capacity => _todos.Length;

        #endregion

        #region Public functions

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

        public bool Remove(ToDoItem item)
        {
            int index = -1;
            for (int i = 0; i < _todos.Length; i++)
            {
                if (item != _todos[i]) continue;
                index = i;
                break;
            }

            return Remove(index);
        }

        public bool Remove(int index)
        {
            if (index == -1)
            {
                return false;
            }
            for (int i = index; i < Count - 1; i++)
            {
                _todos[i] = _todos[i + 1];
            }

            if(Count != 0)
            {
                Count--;
                _todos[Count] = null;
                return true;
            }

            return false;
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

        public void CheckIndexBounds(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index is outside of bounds");
            }
        }

        #endregion
    }
}
