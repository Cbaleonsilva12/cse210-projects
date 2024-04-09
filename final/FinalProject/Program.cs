using System;
using System.Collections.Generic;
using System.Diagnostics;

class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }
    public DateTime DueDate { get; set; }
    public bool Status { get; set; }

    public void DisplayTaskDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Priority: {Priority}");
        Console.WriteLine($"Due Date: {DueDate}");
        Console.WriteLine($"Status: {(Status ? "Completed" : "Pending")}");
    }
}

class TaskManager
{
    public List<Task> Tasks { get; }

    public TaskManager()
    {
        Tasks = new List<Task>();
    }

    public void AddTask(Task task)
    {
        Tasks.Add(task);
    }

    public void RemoveTask(Task task)
    {
        Tasks.Remove(task);
    }

    public List<Task> GetAllTasks()
    {
        return Tasks;
    }

    public List<Task> GetTasksByPriority(int priority)
    {
        return Tasks.FindAll(task => task.Priority == priority);
    }
}

class TaskViewer
{
    public void DisplayTaskList(List<Task> tasks)
    {
        foreach (var task in tasks)
        {
            Console.WriteLine($"- {task.Title}");
        }
    }
}

class TaskReporter
{
    public void GenerateTaskReport(List<Task> tasks)
    {
        Console.WriteLine("Task Report:");
        foreach (var task in tasks)
        {
            task.DisplayTaskDetails();
            Console.WriteLine();
        }
    }
}

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
class Program
{
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();
        TaskViewer taskViewer = new TaskViewer();
        TaskReporter taskReporter = new TaskReporter();

        while (true)
        {
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Remove Task");
            Console.WriteLine("3. View All Tasks");
            Console.WriteLine("4. Generate Task Report");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter task title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter task description: ");
                    string description = Console.ReadLine();
                    Console.Write("Enter task priority: ");
                    int priority = int.Parse(Console.ReadLine());
                    Console.Write("Enter task due date (yyyy-mm-dd): ");
                    DateTime dueDate = DateTime.Parse(Console.ReadLine());

                    Task newTask = new Task
                    {
                        Title = title,
                        Description = description,
                        Priority = priority,
                        DueDate = dueDate
                    };

                    taskManager.AddTask(newTask);
                    Console.WriteLine("Task added successfully!");
                    break;

                case 2:
                    Console.WriteLine("Enter the title of the task to remove: ");
                    string titleToRemove = Console.ReadLine();
                    Task taskToRemove = taskManager.Tasks.Find(task => task.Title == titleToRemove);
                    if (taskToRemove != null)
                    {
                        taskManager.RemoveTask(taskToRemove);
                        Console.WriteLine("Task removed successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Task not found!");
                    }
                    break;

                case 3:
                    Console.WriteLine("All Tasks:");
                    taskViewer.DisplayTaskList(taskManager.GetAllTasks());
                    break;

                case 4:
                    taskReporter.GenerateTaskReport(taskManager.GetAllTasks());
                    break;

                case 5:
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            Console.WriteLine();
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
