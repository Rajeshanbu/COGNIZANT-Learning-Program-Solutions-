using System;

public class Task
{
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public string Status { get; set; }

    public Task(int id, string name, string status)
    {
        TaskId = id;
        TaskName = name;
        Status = status;
    }

    public override string ToString()
    {
        return $"ID: {TaskId}, Name: {TaskName}, Status: {Status}";
    }
}

public class TaskNode
{
    public Task Data;
    public TaskNode Next;

    public TaskNode(Task task)
    {
        Data = task;
        Next = null;
    }
}

public class TaskLinkedList
{
    private TaskNode head;

    // Add task at end
    public void AddTask(Task task)
    {
        TaskNode newNode = new TaskNode(task);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            TaskNode temp = head;
            while (temp.Next != null)
                temp = temp.Next;
            temp.Next = newNode;
        }
        Console.WriteLine("Task added.");
    }

    // Search task by ID
    public void SearchTask(int id)
    {
        TaskNode temp = head;
        while (temp != null)
        {
            if (temp.Data.TaskId == id)
            {
                Console.WriteLine("Found: " + temp.Data);
                return;
            }
            temp = temp.Next;
        }
        Console.WriteLine("Task not found.");
    }

    // Traverse all tasks
    public void DisplayTasks()
    {
        Console.WriteLine("\nAll Tasks:");
        TaskNode temp = head;
        while (temp != null)
        {
            Console.WriteLine(temp.Data);
            temp = temp.Next;
        }
    }

    // Delete task by ID
    public void DeleteTask(int id)
    {
        TaskNode temp = head, prev = null;

        if (temp != null && temp.Data.TaskId == id)
        {
            head = temp.Next;
            Console.WriteLine("Task deleted.");
            return;
        }

        while (temp != null && temp.Data.TaskId != id)
        {
            prev = temp;
            temp = temp.Next;
        }

        if (temp == null)
        {
            Console.WriteLine("Task not found.");
            return;
        }

        prev.Next = temp.Next;
        Console.WriteLine("Task deleted.");
    }
}

// Main
class Program
{
    static void Main(string[] args)
    {
        TaskLinkedList taskList = new TaskLinkedList();

        taskList.AddTask(new Task(1, "Design UI", "Pending"));
        taskList.AddTask(new Task(2, "Write Code", "In Progress"));
        taskList.AddTask(new Task(3, "Test Features", "Pending"));

        taskList.DisplayTasks();

        Console.WriteLine("\nSearching Task ID 2:");
        taskList.SearchTask(2);

        Console.WriteLine("\nDeleting Task ID 2:");
        taskList.DeleteTask(2);

        taskList.DisplayTasks();
    }
}
