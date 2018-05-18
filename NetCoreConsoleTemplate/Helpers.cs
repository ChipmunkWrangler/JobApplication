using System.Collections.Generic;

namespace JobApplication
{
    public static class Helpers
    {
        public static string Stringify(IEnumerable<char> chars)
        {
            return string.Join("", chars);
        }
    }
}
