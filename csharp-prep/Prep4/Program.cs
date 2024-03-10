using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            if (num == 0)
                break;

            numbers.Add(num);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers entered.");
            return;
        }

        // Core Requirements
        int sum = numbers.Sum();
        double average = numbers.Average();
        int max = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge
        List<int> positiveNumbers = numbers.Where(n => n > 0).ToList();
        int minPositive = positiveNumbers.Count > 0 ? positiveNumbers.Min() : 0;

        Console.WriteLine($"The smallest positive number is: {minPositive}");

        Console.WriteLine("The sorted list is:");
        numbers.Sort();
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}