# How to use

## Item of the list
Each item of the list is instance `ToDoItem` public class

##### Examples of using
```cs
var toDoItem = new ToDoItem(name:"Math homework",description: "Remember to finish math homework before the asignment ends");

var item2 = new ToDoItem
{
    Name="House work"
};
toDoItem.IsDone=true;
Console.WriteLine($"ToDo #{toDoItem.Id}, name:{toDoItem.Name}, description:{toDoItem.description}, is done:{toDoItem.IsDone}");
```

<aside class="notice">
  
All double or more spaces/whitespaces would be removed from `Name` property of the `ToDoItem` class
  
```cs
"     aaaaa aaa    aaaaa a aaa aaa      " => "aaaaa aaa aaaaa a aaa aaa"
```

</aside>

## List overview

Code example
```cs
// Lets create some ToDoItem objects to insert them in list
var todos = new ToDoItem[] 
{
    new ToDoItem {"Item1"},
    new ToDoItem {"Item2"},
    new ToDoItem {"Item3"},
    new ToDoItem {"Item4"},
}

var list = new ToDoList(10); //Create empty list with capacity of 10, to save some memory
list.AddRange(todos); //Add elements with AddRange function
list.Add("Item5"); //Add item with passing name and description of the item
list[1].IsDone=true; //Activating some items
list[0].IsDone=true;
list[4].IsDone=true;

//Printing them to see
foreach(var item in list.Where(todo => todo.IsDone)
{
    Console.WriteLine($"ToDo #{todo.Id}, name:{todo.Name}, description:{todo.description}, is done:{todo.IsDone}");
}
```
