using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create a scripture object
        var scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        // Display the complete scripture
        scripture.Display();

        // Prompt the user to press enter or type quit
        while (true)
        {
            Console.WriteLine("\nPress ENTER to continue or type 'quit' to exit:");
            var input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;

            // Hide a few random words and display the scripture again
            scripture.HideRandomWords();
            scripture.Display();
        }
    }
}

// Class representing a scripture
class Scripture
{
    private readonly string reference;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"Scripture: {reference}\n");

        foreach (var word in words)
        {
            Console.Write(word.IsHidden ? "***** " : $"{word.Text} ");
        }
    }

    public void HideRandomWords()
    {
        var random = new Random();
        var numberOfWordsToHide = random.Next(1, words.Count / 2); // Hide up to half of the words

        var wordsToHide = new HashSet<int>();
        while (wordsToHide.Count < numberOfWordsToHide)
        {
            var index = random.Next(words.Count);
            wordsToHide.Add(index);
        }

        foreach (var index in wordsToHide)
        {
            words[index].Hide();
        }
    }
}

// Class representing a word
class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }
}
