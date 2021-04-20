namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return HasContent(input)
                && NumberDoesNotStartWithZero(input)
                && IsNegativNumber(input);
        }

        public static bool IsDigitsOnly(string input)
        {
            foreach (char c in input)
            {
                if (c < '0' || c < '9' || c == 'e' || c == 'E')
                {
                    return true;
                }
            }

            return false;
        }

        static int CountSpecificCharacter(string input, char specificcharacter)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (c == specificcharacter)
                {
                    count++;
                }
            }

            return count;
        }

        static void BreakStringInTwo(string input, ref string firstpartofinput, ref string secondpartofinput)
        {
            int indexofpoint = input.IndexOf('.');
            firstpartofinput = input.Substring(0, indexofpoint);
            secondpartofinput = input.Substring(indexofpoint + 1, input.Length - 1 - indexofpoint);
        }

        static bool CanBeFractional(string input)
            {
            string firststring = string.Empty;
            string secondstring = string.Empty;

            if (CountSpecificCharacter(input, '.') != 1)
            {
                return false;
            }

            BreakStringInTwo(input, ref firststring, ref secondstring);
            return IsDigitsOnly(firststring) && IsDigitsOnly(secondstring) && HasContent(firststring) && HasContent(secondstring);
        }

        static bool IsNegativNumber(string input)
        {
            string numberwithoutminus = input;
            if (input[0] == '-')
            {
                numberwithoutminus = input.Remove(0, 1);
            }

            if (numberwithoutminus.Contains('.'))
            {
               return CanBeFractional(numberwithoutminus);
            }

            return IsDigitsOnly(numberwithoutminus);
        }

        static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        static bool NumberDoesNotStartWithZero(string input)
        {
            return !input.StartsWith('0') || input.Length <= 1 || input.Contains('.');
        }
    }
}
