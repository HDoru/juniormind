using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return HasContent(input) && IsDoubleQuoted(input);
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
    }
    asddaad
}
