using System;
using System.Text;

namespace MyFancyNamespace
{
    public class WordGenerator
    {
        readonly string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        Random random = new Random();

        public WordGenerator(char unknownCharRepresenation) 
        {
            alphabet.Replace(unknownCharRepresenation.ToString(), string.Empty);
        }

        public string GetWord(int wordLength)
        {
            var stringBuilder = new StringBuilder(wordLength);
            for (int i = 0; i < wordLength; ++i)
            {
                stringBuilder.Append(alphabet[random.Next(alphabet.Length)]);
            }
            return stringBuilder.ToString();
        }

        public string GetAlphabet() 
        {
            return alphabet;
        }
    }
}
