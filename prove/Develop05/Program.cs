using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

abstract class Goal
{
    public string Name { get; }
    public int Value { get; }
    public bool Completed { get; set; }

    public Goal(string name, int value)
    {
        Name = name;
        Value = value;
        Completed = false;
    }

    public abstract int MarkComplete();
    public abstract string DisplayStatus();
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value) { }

    public override int MarkComplete()
    {
        Completed = true;
        return Value;
    }

    public override string DisplayStatus()
    {
        string status = Completed ? "[X]" : "[ ]";
        return $"{status} {Name}";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value) { }

    public override int MarkComplete()
    {
        return Value;
    }

    public override string DisplayStatus()
    {
        string status = Completed ? "[X]" : "[ ]";
        return $"{status} {Name}";
    }
}

class ChecklistGoal : Goal
{
    private int completedTimes;
    private readonly int target;

    public ChecklistGoal(string name, int value, int target) : base(name, value)
    {
        this.target = target;
        completedTimes = 0;
    }

    public override int MarkComplete()
    {
        completedTimes++;
        if (completedTimes == target)
        {
            Completed = true;
            return Value + 500;
        }
        else
        {
            return Value;
        }
    }

    public override string DisplayStatus()
    {
        string status = Completed ? $"[X] Completed {completedTimes}/{target} times" : $"[ ] Completed {completedTimes}/{target} times";
        return $"{status} {Name}";
    }
}

class User
{
    public List<Goal> Goals { get; }
    public int Score { get; set; }

    public User()
    {
        Goals = new List<Goal>();
        Score = 0;
    }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        Goal goal = Goals[goalIndex];
        if (!goal.Completed)
        {
            Score += goal.MarkComplete();
        }
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < Goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Goals[i].DisplayStatus()}");
        }
    }

    public void SaveUserData()
    {
        string json = JsonSerializer.Serialize(this);
        File.WriteAllText("user_data.json", json);
    }

    public static User LoadUserData()
    {
        if (File.Exists("user_data.json"))
        {
            string json = File.ReadAllText("user_data.json");
            return JsonSerializer.Deserialize<User>(json);
        }
        else
        {
            return new User();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        User user = User.LoadUserData();

        while (true)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save and Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter the type of goal (simple/eternal/checklist): ");
                    string goalType = Console.ReadLine().ToLower();
                    Console.Write("Enter the name of the goal: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter the value of the goal: ");
                    int value = int.Parse(Console.ReadLine());
                    if (goalType == "simple")
                    {
                        user.AddGoal(new SimpleGoal(name, value));
                    }
                    else if (goalType == "eternal")
                    {
                        user.AddGoal(new EternalGoal(name, value));
                    }
                    else if (goalType == "checklist")
                    {
                        Console.Write("Enter the target completion count: ");
                        int target = int.Parse(Console.ReadLine());
                        user.AddGoal(new ChecklistGoal(name, value, target));
                    }
                    else
                    {
                        Console.WriteLine("Invalid goal type.");
                    }
                    break;
                case "2":
                    user.DisplayGoals();
                    Console.Write("Enter the index of the goal to mark as complete: ");
                    int goalIndex = int.Parse(Console.ReadLine()) - 1;
                    if (goalIndex >= 0 && goalIndex < user.Goals.Count)
                    {
                        user.RecordEvent(goalIndex);
                    }
                    else
                    {
                        Console.WriteLine("Invalid goal index.");
                    }
                    break;
                case "3":
                    user.DisplayGoals();
                    break;
                case "4":
                    Console.WriteLine($"Current Score: {user.Score}");
                    break;
                case "5":
                    user.SaveUserData();
                    Console.WriteLine("User data saved. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
