using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return HasContent(input) && IsDoubleQuoted(input) && !ContainsControlCharacters(input);
        }

        static bool ContainsControlCharacters(string input)
        {
            const char N = '\\';
            if (input.Contains(N))
            {
                return CountControlCharacters(input) > 1;
            }

            return !input.Contains(N);
        }

        static int CountControlCharacters(string input)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (char.IsControl(c))
                {
                    count++;
                }
            }

            return count;
        }



        static bool IsDoubleQuoted(string input)
        {
            const int atleastchar = 2;
            return input.Length >= atleastchar && input[0] == '"' && input[^1] == '"';
        }

        static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input);
        }
    }
}
