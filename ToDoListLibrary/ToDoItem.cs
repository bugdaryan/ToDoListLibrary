namespace ToDoListLibrary
{
    public class ToDoItem
    {
        #region Constructors

        public ToDoItem(string name, string description, bool isDone)
        {
            Id = _lastId + 1;
            _lastId++;
            Name = name;
            Description = description;
            IsDone = isDone;
        }

        public ToDoItem():this("No name","No description", false)
        {
        }

        #endregion

        #region Public properties

        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public bool IsDone { get; }

        #endregion

        #region Private members

        private static int _lastId = -1;

        #endregion

        #region Operator overloads

        public static bool operator ==(ToDoItem item1, ToDoItem item2)
        {
            return item1?.Id == item2?.Id
                    && item1?.Name == item2?.Name
                    && item1?.Description == item2?.Description
                    && item1?.IsDone == item2?.IsDone;
        }
        public static bool operator !=(ToDoItem item1, ToDoItem item2) => !(item1 == item2);

        #endregion

        #region Helper methods

        protected bool Equals(ToDoItem other)
        {
            return GetHashCode() == other.GetHashCode();
        }

        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals(obj as ToDoItem);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsDone.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{Name}: \n{'{'}\n{Description}\n{'}'}\n";
        }

        #endregion
    }
}