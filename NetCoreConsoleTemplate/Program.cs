using System;

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
            while(!game.Guess(GetNewGuess()))
            {
                Console.WriteLine(game.bestCompositeGuess + " untried = " + Helpers.Stringify(game.untriedLetters) + "  to be included = " + Helpers.Stringify(game.wronglyPositionedLetters));
            };
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
            }
            return newGuess.ToUpper();
        }
    }
}