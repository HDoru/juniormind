using System;

namespace Json
{
    public static class JsonString
    {
        const int QuotationNumber = 2;
        const int UnicodeNumbers = 4;

        public static bool IsJsonString(string input)
        {
            return HasContent(input)
               && IsDoubleQuoted(input)
               && !ContainsControlCharacters(input)
               && !ContainsUnrecognizedEscapeCharacters(input);
        }

        static bool ContainsControlCharacters(string input)
        {
            foreach (char character in input)
            {
                if (char.IsControl(character))
                {
                    return true;
                }
            }

            return input[input.Length - QuotationNumber] == '\\' || input[input.Length - QuotationNumber] == 'u';
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

        static bool ContainsUnrecognizedEscapeCharacters(string input)
        {
            bool valid = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\')
                {
                    valid = CheckValidEscapeCharacters(input, ref i);
                }

                if (!valid)
                {
                    return !valid;
                }
            }

            return !valid;
        }

        static bool IsValidHex(char input)
        {
            return input >= 'a' && input <= 'f' || input >= '0' && input <= '9';
        }

        static bool CheckValidHexNumbers(string input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (!IsValidHex(input.ToLower()[i]))
                {
                    return false;
                }
            }

            return true;
        }

        static bool CheckValidEscapeCharacters(string input, ref int i)
        {
            const string validEscapeCharacters = @"bntrf\/\""";
            i++;

            if (input[i] == 'u' && input.Length - QuotationNumber - i >= UnicodeNumbers && CheckValidHexNumbers(input.Substring(i, UnicodeNumbers)))
            {
                i += UnicodeNumbers;
                return true;
            }
            else if (validEscapeCharacters.Contains(input.Substring(i, 1)))
            {
                i++;
                return true;
            }

            return false;
        }
    }
}
