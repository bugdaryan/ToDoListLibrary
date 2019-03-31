using System;
using System.Collections;
using System.Collections.Generic;

namespace ToDoListLibrary
{
    public class ToDoList:IEnumerable<ToDoItem>
    {
        public IEnumerator<ToDoItem> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
