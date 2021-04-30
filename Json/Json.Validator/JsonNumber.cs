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

        static bool IsValidNumber(string input)
        {
            string wholeNumber = string.Empty;
            string fractionalNumber = string.Empty;
            string exponentialNumber = string.Empty;
            if (input[0] == '-')
            {
                input = input.Remove(0, 1);
            }

            if (CanBeFractional(input) && CanBeExponential(input))
            {
                if (input.IndexOf('.') > input.ToLower().IndexOf('e'))
                {
                    return false;
                }

                BreakStringInFractional(input, ref wholeNumber, ref fractionalNumber);

                BreakStringInExponential(fractionalNumber, ref fractionalNumber, ref exponentialNumber);
            }
            else if (CanBeFractional(input))
            {
                BreakStringInFractional(input, ref wholeNumber, ref fractionalNumber);
            }
            else if (CanBeExponential(input))
            {
                BreakStringInExponential(input, ref wholeNumber, ref exponentialNumber);
                VerifyExponentMarkNumber(ref exponentialNumber);
            }

            if (fractionalNumber == string.Empty && exponentialNumber == string.Empty)
            {
                return IsDigitsOnly(input);
            }

            return VerifyParts(wholeNumber, fractionalNumber, exponentialNumber);
        }

        static bool CanBeExponential(string input)
        {
            return CountSpecificCharacter(input.ToLower(), 'e') == 1;
        }

        static bool CanBeFractional(string input)
        {
            return CountSpecificCharacter(input, '.') == 1;
        }

        static bool VerifyParts(string wholeNumber, string fractionalNumber, string exponentialNumber)
        {
            if (fractionalNumber != string.Empty && exponentialNumber != string.Empty)
            {
                return IsDigitsOnly(wholeNumber) && IsFractional(fractionalNumber) && IsExponential(exponentialNumber);
            }
            else if (exponentialNumber != string.Empty)
            {
                return IsExponential(exponentialNumber) && IsDigitsOnly(wholeNumber);
            }

            return IsFractional(fractionalNumber) && IsDigitsOnly(wholeNumber);
        }

        static bool IsFractional(string input)
        {
            return input.StartsWith(".") && IsDigitsOnly(input.Substring(1, input.Length - 1));
        }

        static bool IsExponential(string input)
        {
            return input.ToLower().StartsWith("e") && IsDigitsOnly(input.Substring(1, input.Length - 1));
        }

        static void BreakStringInFractional(string input, ref string firstpartofinput, ref string secondpartofinput)
        {
            int indexofpoint = input.IndexOf('.');
            firstpartofinput = input.Substring(0, indexofpoint);
            secondpartofinput = input.Substring(indexofpoint, input.Length - indexofpoint);
        }

        static void BreakStringInExponential(string input, ref string firstpartofinput, ref string secondpartofinput)
        {
            int indexofpoint = input.ToLower().IndexOf('e');
            firstpartofinput = input.Substring(0, indexofpoint);
            secondpartofinput = input.Substring(indexofpoint, input.Length - indexofpoint);
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

        static void VerifyExponentMarkNumber(ref string input)
            {
            if (!input.Contains('+') && !input.Contains('-'))
            {
                return;
            }

            input = input.Remove(1, 1);
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
