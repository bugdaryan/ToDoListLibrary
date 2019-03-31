using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ToDoListLibrary
{
    public class ToDoList : IEnumerable<ToDoItem>
    {
        #region Public properties

        public int Count => _count;
        public int Capacity => _todos.Length;

        #endregion

        #region Public functions

        public void PushBack(ToDoItem item)
        {
            if (_todos.Length == _count)
            {
                ToDoItem[] arr = new ToDoItem[_count * 2];
                for (int i = 0; i < _todos.Length; i++)
                {
                    arr[i] = _todos[i];
                }

                _todos = arr;
            }

            _todos[_count] = item;
            
            _count++;
        }

        public bool Remove(ToDoItem item)
        {
            int index = -1;
            for (int i = 0; i < _todos.Length; i++)
            {
                if (item == _todos[i])
                {
                    index = i;
                    break;
                }
            }

            return Remove(index);
        }

        public bool Remove(int index)
        {
            if (index == -1)
            {
                return false;
            }
            for (int i = index; i < _count - 1; i++)
            {
                _todos[i] = _todos[i + 1];
            }

            _todos[_count - 1] = null;
            _count--;
            return true;
        }

        #endregion

        #region Private members

        private ToDoItem[] _todos;
        private int _count = 0;

        #endregion

        #region Constructors
        public ToDoList(IEnumerable<ToDoItem> todos)
        {
            _todos = todos.ToArray();
        }

        public ToDoList(int count)
        {
            _todos = new ToDoItem[count];
        }

        public ToDoList() : this(1)
        {
        }
        #endregion

        #region Overrides

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

        #region Private functions

        public void CheckIndexBounds(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException("Index is outside of bounds");
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
    }
}
