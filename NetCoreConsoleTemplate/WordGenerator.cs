using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace JobApplication
{
    public class WordGenerator
    {
        Random random = new Random();

        public string GetWordCheat(char unknownCharRepresentation, string guess, string bestGuess, string alphabet, string mustInclude)
        { // TODO Refactor
            var word = new StringBuilder(bestGuess);
            var unguessedAlphabet = alphabet.Except(guess);
            bool allowCorrectLetters = unguessedAlphabet.Count() <= word.Length * 2;
            if (allowCorrectLetters) {
                mustInclude = Helpers.Stringify(mustInclude.Union(unguessedAlphabet));
            }
            for (int i = 0; i < word.Length; ++i)
            {
                Console.WriteLine(word);
                Console.WriteLine(mustInclude);
                if (word[i] == unknownCharRepresentation)
                {
                    if (mustInclude.Length > 0)
                    {
                        if (mustInclude[0] == guess[i] && mustInclude.Length > 1)
                        {
                            word[i] = mustInclude[1];
                            mustInclude = mustInclude.Remove(1, 1);
                        }
                        else
                        {
                            word[i] = mustInclude[0];
                            mustInclude = mustInclude.Remove(0, 1);
                        }
                    }
                    else
                    {
                        word[i] = allowCorrectLetters ? alphabet[random.Next(alphabet.Length)] : unguessedAlphabet.First();
                    }
                }
            }
            Console.WriteLine(word);
            return word.ToString();
        }
    }
}
