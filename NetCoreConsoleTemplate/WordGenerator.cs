using System;
using System.Text;
using System.Collections.Generic;

namespace JobApplication
{
    public class WordGenerator
    {
        Random random = new Random();

        public string GetWord(int wordLength, string alphabet)
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
