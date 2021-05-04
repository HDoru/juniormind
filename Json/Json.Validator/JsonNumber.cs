namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return HasContent(input)
                && NumberDoesNotStartWithZero(input)
                && IsValidNumber(input);
        }

        static bool IsValidFractional(string input)
        {
            if (input == string.Empty)
            {
                return true;
            }

            return input.StartsWith(".") && IsDigitsOnly(input.Substring(1, input.Length - 1));
        }

        static bool IsValidExponential(string input)
        {
            if (input == string.Empty)
            {
                return true;
            }

            VerifyExponentMarkNumber(ref input);
            return input.ToLower().StartsWith("e") && IsDigitsOnly(input.Substring(1, input.Length - 1));
        }

        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }

            return HasContent(str);
        }

        static bool HasContent(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        static bool CanBeFractional(string input)
        {
            return CountSpecificCharacter(input, '.') == 1;
        }

        static bool CanBeExponential(string input)
        {
            return CountSpecificCharacter(input.ToLower(), 'e') == 1;
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

        static string IntegerPart(string input, int indexofDot, int indexOfExponent)
        {
            if (CanBeFractional(input))
            {
                return input.Substring(0, indexofDot);
            }
            else if (CanBeExponential(input))
            {
                return input.Substring(0, indexOfExponent);
            }

            return input;
        }

        static string FractionPart(string input, int indexofDot, int indexOfExponent)
        {
            if (CanBeFractional(input) && CanBeExponential(input) && indexofDot < indexOfExponent)
            {
                return input.Substring(indexofDot, indexOfExponent - indexofDot);
            }
            else if (CanBeFractional(input))
            {
                return input.Substring(indexofDot, input.Length - indexofDot);
            }

            return string.Empty;
        }

        static string ExponentPart(string input, int indexOfExponent)
        {
            if (CanBeExponential(input))
            {
                return input.Substring(indexOfExponent, input.Length - indexOfExponent);
            }

            return string.Empty;
        }

        static bool IsValidNumber(string input)
        {
            int indexOfDot = input.IndexOf('.');
            int indexOfExponent = input.IndexOfAny("eE".ToCharArray());

            string wholeNumber = IntegerPart(input, indexOfDot, indexOfExponent);
            string fractionalNumber = FractionPart(input, indexOfDot, indexOfExponent);
            string exponentialNumber = ExponentPart(input, indexOfExponent);

            return IsValidInteger(wholeNumber)
                && IsValidFractional(fractionalNumber)
                && IsValidExponential(exponentialNumber);
        }

        static bool IsValidInteger(string wholeNumber)
        {
            if (!NumberDoesNotStartWithZero(wholeNumber))
            {
                return false;
            }

            if (wholeNumber[0] == '-')
            {
                wholeNumber = wholeNumber.Remove(0, 1);
            }

            return IsDigitsOnly(wholeNumber);
        }

        static void VerifyExponentMarkNumber(ref string input)
        {
            if (!input.Contains('+') && !input.Contains('-'))
            {
                return;
            }

            input = input.Remove(1, 1);
        }

        static bool NumberDoesNotStartWithZero(string input)
        {
            return !input.StartsWith('0') || input.Length <= 1 || input.Contains('.');
        }
    }
}
