using System;
using System.Linq;
using System.Diagnostics; // wanted to use Code Contracts, but that requires additional setup I don't have time for
using System.Text;
using System.Collections.Generic;

namespace JobApplication
{
    // Represents the internal state of a single game
    class Game
    {
        public string wordToGuess { get; private set; }
        public string bestCompositeGuess { get; private set; }
        public HashSet<char> untriedLetters { get; private set; } = new HashSet<char>("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        public HashSet<char> eliminatedLetters { get; private set; } = new HashSet<char>();
        public HashSet<char> wronglyPositionedLetters { get; private set; } = new HashSet<char>();

        readonly WordGenerator wordGenerator;
        readonly char unknownChar;

        // take configuration parameters that we would expect the user or some metagame system to supply
        public Game(int wordLength, char unknownCharRepresentation) 
        {
            unknownChar = unknownCharRepresentation;
            untriedLetters.Remove(unknownCharRepresentation);
            wordGenerator = new WordGenerator();
            wordToGuess = wordGenerator.GetWord(wordLength, Helpers.Stringify(untriedLetters));
            bestCompositeGuess = new string(unknownCharRepresentation, wordLength);
            Console.WriteLine(wordToGuess);
        }

        public void Guess(string guess)
        {
            Debug.Assert(guess.Length == wordToGuess.Length);
            bestCompositeGuess = GetNewCompositeGuess(guess);
            var wrongLetters = guess.Except(wordToGuess);
            eliminatedLetters = eliminatedLetters.Union(wrongLetters).ToHashSet<char>();
            untriedLetters = untriedLetters.Except(guess).ToHashSet<char>();
            wronglyPositionedLetters = GetWronglyPositionedLetters(guess);
        }

        public HashSet<char> GetWronglyPositionedLetters(string guess)
        {
            var rightLettersThisGuess = guess.Intersect(wordToGuess);
            var rightLettersEverGuessed = wronglyPositionedLetters.Union(rightLettersThisGuess);
            string lettersLeftToGuess = GetLettersLeftToGuess(guess); // non-unique but unordered, e.g. eaec
            return rightLettersEverGuessed.Intersect(lettersLeftToGuess).ToHashSet<char>();
        }


        private string GetLettersLeftToGuess(string guess)
        {
            Debug.Assert(bestCompositeGuess.Length == wordToGuess.Length);
            var sb = new StringBuilder();
            for (int i = 0; i < wordToGuess.Length; ++i)
            {
                if (bestCompositeGuess[i] == unknownChar)
                {
                    sb.Append(wordToGuess[i]);
                }
            }
            return sb.ToString();
        }


        private string GetNewCompositeGuess(string guess)
        {
            Debug.Assert(guess.Length == bestCompositeGuess.Length);
            Debug.Assert(guess.Length == wordToGuess.Length);
            var newBestGuessBuilder = new StringBuilder(bestCompositeGuess.Length);
            for (int i = 0; i < guess.Length; ++i)
            {
                newBestGuessBuilder.Append((wordToGuess[i] == guess[i]) ? guess[i] : bestCompositeGuess[i]);
            }
            return newBestGuessBuilder.ToString();
        }
    }
}



