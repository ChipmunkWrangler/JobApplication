using System;
using System.Linq;
using System.Collections.Generic;

namespace JobApplication
{
    public class Program
    {
        const int wordLength = 5;
        const char unknownChar = '_';

        public static void Main()
        {
            //PlayOnConsole();
            PlayPrototype();
        }

        //private static void PlayOnConsole()
        //{
        //    var game = new Game(wordLength, unknownChar);
        //    Console.WriteLine("Welcome!");
        //    while(!game.Guess(GetNewGuess()))
        //    {
        //        Console.WriteLine(game.bestCompositeGuess + " untried = " + Helpers.Stringify(game.untriedLetters) + "  to be included = " + Helpers.Stringify(game.wronglyPositionedLetters));
        //    };
        //    Console.WriteLine("Right!");
        //}

        //private static string GetNewGuess()
        //{
        //    Console.Write("Enter " + wordLength + "-letter guess: ");
        //    string newGuess = Console.ReadLine();
        //    while (newGuess.Length != wordLength)
        //    {
        //        Console.Write("Guess has wrong length. Please try again: ");
        //        newGuess = Console.ReadLine();
        //    }
        //    return newGuess.ToUpper();
        //}

        private static void PlayPrototype()
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string wordToGuess = GetWordToGuess(alphabet);
            List<char> wordInProgress = new List<char>(new string(unknownChar, wordLength));
            string triedLetters = "";
            string lastGuess = new string(unknownChar, wordLength);
            //Console.WriteLine(wordToGuess);
            while (lastGuess != wordToGuess)
            {
                string missingLetters = "";
                for (int i = 0; i < wordLength; ++i)
                {
                    triedLetters += lastGuess[i];
                    if (wordToGuess[i] == lastGuess[i])
                    {
                        wordInProgress[i] = wordToGuess[i];
                    }
                    if (wordInProgress[i] == unknownChar)
                    {
                        missingLetters += wordToGuess[i];
                    }
                }
                //Console.WriteLine(triedLetters);
                //Console.WriteLine(missingLetters);
                Console.WriteLine(Stringify(wordInProgress) + " requiredLetters = " + Stringify(missingLetters.Intersect(triedLetters)) + " untriedLetters = " + Stringify(alphabet.Except(triedLetters)));
                lastGuess = GetPlayerGuess();
            }
            Console.WriteLine("Right!");
        }

        private static string Stringify(IEnumerable<char> enumerable)
        {
            return string.Join("", enumerable);
        }

        private static string GetPlayerGuess()
        {
            string guess = "";
            while (guess.Length != wordLength)
            {
                Console.Write("Pick a " + wordLength + " letter word: ");
                guess = Console.ReadLine().ToUpper();
            }
            return guess;
        }

        private static string GetWordToGuess(string alphabet)
        {
            Random random = new Random();
            string wordToGuess = "";
            for (int i = 0; i < wordLength; ++i)
            {
                wordToGuess = wordToGuess + alphabet[random.Next(alphabet.Length)];
            }
            return wordToGuess;
        }
    }
}