using System;
using System.Collections.Generic;

namespace JobApplication
{
    public class Program
    {
        const int wordLength = 5;
        const char unknownChar = '_';

        public static void Main()
        {
            PlayOnConsole();
        }

        private static void PlayOnConsole()
        {
            var game = new Game(wordLength, unknownChar);
            Console.WriteLine("Welcome!");
            string guess = "";
            do
            {
                guess = GetNewGuess();
                game.Guess(guess);
                Console.WriteLine(game.bestCompositeGuess + " untried = " + Stringify(game.untriedLetters) + "  to be included = " + Stringify(game.wronglyPositionedLetters));
            } while (game.wordToGuess != guess);
            Console.WriteLine("Right!");
        }

        private static string GetNewGuess()
        {
            Console.Write("Enter " + wordLength + "-letter guess: ");
            string newGuess = Console.ReadLine();
            while (newGuess.Length != wordLength)
            {
                Console.Write("Guess has wrong length. Please try again: ");
                newGuess = Console.ReadLine();
            };
            return newGuess.ToUpper();
        }

        private static string Stringify(IEnumerable<char> chars)
        {
            return string.Join("", chars);
        }
    }
}