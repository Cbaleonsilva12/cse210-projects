using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your grade percentage:");
        int gradePercentage = Convert.ToInt32(Console.ReadLine());

        char letter;
        string sign = "";

        if (gradePercentage >= 90)
        {
            letter = 'A';
            if (gradePercentage >= 97)
                sign = "+";
            else if (gradePercentage <= 92)
                sign = "-";
        }
        else if (gradePercentage >= 80)
        {
            letter = 'B';
            if (gradePercentage >= 87)
                sign = "+";
            else if (gradePercentage <= 82)
                sign = "-";
        }
        else if (gradePercentage >= 70)
        {
            letter = 'C';
            if (gradePercentage >= 77)
                sign = "+";
            else if (gradePercentage <= 72)
                sign = "-";
        }
        else if (gradePercentage >= 60)
            letter = 'D';
        else
            letter = 'F';

        Console.Write("Your grade is: ");
        if (letter == 'F')
            Console.WriteLine(letter);
        else
            Console.WriteLine(letter + sign);

        if (letter != 'F' && gradePercentage >= 70)
            Console.WriteLine("Congratulations! You passed the course.");
        else
            Console.WriteLine("Better luck next time!");
    }
}