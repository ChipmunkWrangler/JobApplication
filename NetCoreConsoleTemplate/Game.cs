using System;
using System.Linq;
using System.Diagnostics; // wanted to use Code Contracts, but that requires additional setup I don't have time for
using System.Text;


namespace MyFancyNamespace
{
    // Represents the internal state of a single game
    class Game
    {
        // hard-code configuration that we would expect the game designer to supply, such as what kind of WordGenerator to use (no dependency injection for now)
        readonly WordGenerator wordGenerator;
        readonly char unknownChar;

        string wordToGuess;
        string bestGuess;

        // take configuration parameters that we would expect the user or some metagame system to supply
        public Game(int wordLength, char unknownCharRepresentation) 
        {
            wordGenerator = new WordGenerator(unknownCharRepresentation);
            wordToGuess = wordGenerator.GetWord(wordLength);
            unknownChar = unknownCharRepresentation;
            bestGuess = new string(unknownCharRepresentation, wordLength);
            Console.WriteLine(wordToGuess);
        }

        public bool IsGuessCorrect(string guess)
        {
            Debug.Assert(guess.Length == wordToGuess.Length);
            return guess == wordToGuess;
        }

        public string GetCorrectAndUnknownChars(string guess)
        {
            Debug.Assert(guess.Length == wordToGuess.Length);
            Debug.Assert(guess.Length == bestGuess.Length);
            var newBestGuessBuilder = new StringBuilder(bestGuess.Length);
            for (int i = 0; i < guess.Length; ++i)
            {
                newBestGuessBuilder.Append((wordToGuess[i] == guess[i]) ? guess[i] : bestGuess[i]);
            }
            bestGuess = newBestGuessBuilder.ToString();
            return bestGuess;
        }

        public string GetWronglyPositionedChars(string guess)
        {
            Debug.Assert(guess.Length == wordToGuess.Length);
            string leftoverCharsToGuess = "";
            for (int i = 0; i < guess.Length; ++i ) 
            {
                if (wordToGuess[i] != guess[i])   
                {
                    leftoverCharsToGuess += wordToGuess[i];
                }
            }
            return string.Join("", guess.Intersect(leftoverCharsToGuess));
        }
    }
}


