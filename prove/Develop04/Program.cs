using System;
using System.Threading;
using System.Collections.Generic;

abstract class Activity
{
    protected int duration;

    public abstract void StartActivity();
    public abstract void EndActivity();
    protected abstract void DisplayPrompt();
    protected abstract void Countdown();
}

class BreathingActivity : Activity
{
    public override void StartActivity()
    {
        Console.WriteLine("Breathing Activity");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Console.Write("Enter duration in seconds: ");
        duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Countdown();
        PerformBreathing();
    }

    public override void EndActivity()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed the Breathing Activity in {duration} seconds.");
    }

    protected override void DisplayPrompt()
    {
        // Breathing activity does not have prompts
    }

    protected override void Countdown()
    {
        Console.WriteLine("Countdown:");
        for (int i = duration; i > 0; i--)
        {
            Console.WriteLine($"Time left: {i} seconds");
            Thread.Sleep(1000); // Pause for 1 second
        }
    }

    private void PerformBreathing()
    {
        Console.WriteLine("Start breathing...");
        for (int i = 0; i < duration; i += 2)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(2000); // Pause for 2 seconds
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000); // Pause for 2 seconds
        }
    }
}

class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public override void StartActivity()
    {
        Console.WriteLine("Reflection Activity");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Console.Write("Enter duration in seconds: ");
        duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Countdown();
        Reflect();
    }

    public override void EndActivity()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed the Reflection Activity in {duration} seconds.");
    }

    protected override void DisplayPrompt()
    {
        Random random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Count)]);
    }

    protected override void Countdown()
    {
        Console.WriteLine("Countdown:");
        for (int i = duration; i > 0; i--)
        {
            Console.WriteLine($"Time left: {i} seconds");
            Thread.Sleep(1000); // Pause for 1 second
        }
    }

    private void Reflect()
    {
        while (duration > 0)
        {
            DisplayPrompt();
            foreach (string question in questions)
            {
                Console.WriteLine(question);
                // Display spinner animation
                Thread.Sleep(2000); // Pause for 2 seconds
            }
            duration -= questions.Count;
        }
    }
}

class ListingActivity : Activity
{
    private List<string> itemsList = new List<string>();

    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public override void StartActivity()
    {
        Console.WriteLine("Listing Activity");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.Write("Enter duration in seconds: ");
        duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Countdown();
        ListItems();
    }

    public override void EndActivity()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have listed {itemsList.Count} items.");
        Console.WriteLine($"You have completed the Listing Activity in {duration} seconds.");
    }

    protected override void DisplayPrompt()
    {
        Random random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Count)]);
    }

    protected override void Countdown()
    {
        Console.WriteLine("Countdown:");
        for (int i = duration; i > 0; i--)
        {
            Console.WriteLine($"Time left: {i} seconds");
            Thread.Sleep(1000); // Pause for 1 second
        }
    }

    private void ListItems()
    {
        while (duration > 0)
        {
            DisplayPrompt();
            Console.WriteLine("Start listing items...");
            // Allow user to input items for duration seconds
            Thread.Sleep(duration * 1000); // Pause for duration seconds
            // Calculate items listed
            duration = 0;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Activity activity = null;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please enter a valid option.");
                    break;
            }

            if (activity != null)
            {
                activity.StartActivity();
                activity.EndActivity();
            }
        }
    }
}
