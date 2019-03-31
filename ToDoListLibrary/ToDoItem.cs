namespace ToDoListLibrary
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }

        public static bool operator ==(ToDoItem item1, ToDoItem item2)
        {
            return item1?.Id == item2?.Id
                    && item1?.Name == item2?.Name
                    && item1?.Description == item2?.Description
                    && item1?.IsDone == item2?.IsDone;
        }
        public static bool operator !=(ToDoItem item1, ToDoItem item2) => !(item1 == item2);
    }
}