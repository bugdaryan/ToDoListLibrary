using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ToDoListLibrary
{
    public class ToDoList:IEnumerable<ToDoItem>
    {
        #region Public properties

        public int Count => _count;
        

        #endregion


        #region Private members

        private readonly ToDoItem[] _todos;
        private int _count;

        #endregion

        #region Constructors
        public ToDoList(IEnumerable<ToDoItem> todos)
        {
            _todos = todos.ToArray();
        }

        public ToDoList(int count)
        {
            _todos = new ToDoItem[count];
            _count = count;
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
