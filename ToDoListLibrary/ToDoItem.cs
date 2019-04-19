namespace ToDoListLibrary
{
    public class ToDoItem
    {
        #region Constructors
        /// <summary>
        /// Constructor with given name, description
        /// </summary>
        /// <param name="name">Title of the item</param>
        /// <param name="description">Description of the item</param>
        public ToDoItem(string name, string description)
        {
            Id = _lastId + 1;
            _lastId++;
            Name = name;
            Description = description;
            IsDone = false;

        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public ToDoItem() : this("No name", "No description")
        {
        }

        #endregion

        #region Public properties

        /// <summary>
        /// The unique id for each item
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Title of the item
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = System.Text.RegularExpressions.Regex.Replace(value, @"\s+", " ").Trim();
        }

        /// <summary>
        /// Description of the item
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Boolean property to activate and deactivate item
        /// </summary>
        public bool IsDone { get; set; }

        /// <summary>
        /// Priority of the item
        /// </summary>
        public Priority Priority { get; set; }

        #endregion

        #region Private members

        /// <summary>
        /// Id of the last created instance
        /// </summary>
        private static int _lastId = -1;

        private string _name;

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
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

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
            return $"{Name}: \n{'{'}\nDescription:{Description},\nIsActive:{IsDone}\n{'}'}\n";
        }

        #endregion
    }
}