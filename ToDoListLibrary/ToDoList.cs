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

        public void PushBack(ToDoItem item)
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

            _todos[Count - 1] = null;
            Count--;
            return true;
        }

        #endregion

        #region Overrides and operators

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
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
            throw new NotImplementedException();
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
