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
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsNegativNumber(string input)
        {
            string numberwithoutminus = input;
            if (input[0] == '-')
            {
                numberwithoutminus = input.Remove(0, 1);
            }

            return IsDigitsOnly(numberwithoutminus);
        }

        static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        static bool NumberDoesNotStartWithZero(string input)
        {
            return !input.StartsWith('0') || input.Length <= 1;
        }
    }
}
