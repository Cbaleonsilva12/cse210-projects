using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        do
        {
            int magicNumber = random.Next(1, 101);
            int guess;
            int guessCount = 0;

            Console.WriteLine("Welcome to Guess My Number Game!");
            Console.WriteLine("I've chosen a magic number between 1 and 100. Try to guess it!");

            do
            {
                Console.Write("\nEnter your guess: ");
                guess = Convert.ToInt32(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            } while (guess != magicNumber);

            Console.WriteLine($"It took you {guessCount} guesses.");

            Console.Write("\nDo you want to play again? (yes/no): ");
        } while (Console.ReadLine().ToLower() == "yes");
    }
}
