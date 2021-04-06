using System;
using System.Collections.Generic;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return HasContent(input) && IsDoubleQuoted(input) && ContainsControlCharacters(input);
        }

        public static bool IsDoubleQuoted(string input)
        {
            const int atleastchar = 2;
            return input.Length >= atleastchar && input[0] == '"' && input[^1] == '"';
        }

        static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        static bool ContainsControlCharacters(string input)
        {
            const char N = '\\';

            if (input.Contains(N))
            {
                if (ContainAlphabeticCharacters(input))
                {
                    return true;
                }

                return !ContainSpecialCharacters(input);
            }

            return !input.Contains(N);
        }

        static bool ContainAlphabeticCharacters(string input)
        {
            const bool result = true;
            List<char> lista = new List<char>();
            lista.Add('b');
            lista.Add('f');
            lista.Add('n');
            lista.Add('r');
            lista.Add('t');
            int i = input.IndexOf('\\');
            if (i > -1)
            {
                foreach (char c in lista)
                {
                    if (input[i + 1] == c)
                    {
                        return result;
                    }
                }
            }

            return result;
        }

        static bool ContainSpecialCharacters(string input)
        {
            const bool result = false;
            const int SecondPosition = 2;
            int i = input.IndexOf('\\');
            if (i > -1)
            {
                if (input[i + 1] == '"' && input[i + SecondPosition] == '"')
                {
                    return !result;
                }
                else if (input[i + 1] == '/')
                {
                    return result;
                }
                else if (input[i + 1] == '\\')
                {
                    return result;
                }
            }

            return result;
        }
    }
}
