using System;
using System.Text;

namespace MyFancyNamespace
{
    public class WordGenerator
    {
        public string alphabet { get; private set; } = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

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
    }
}
