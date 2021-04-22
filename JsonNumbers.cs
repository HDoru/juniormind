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

            return true;
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

        static bool IsValidNumber(string input)
        {
            if (input[0] == '-')
            {
                input = input.Remove(0, 1);
            }

            if (input.Contains('.') && !input.ToLower().Contains('e'))
            {
                return CanBeFractional(input);
            }

            if (input.ToLower().Contains('e') && !input.Contains('.'))
            {
                return Exponential(input);
            }

            if (input.IndexOf('.') < input.ToLower().IndexOf('e'))
            {
                return CanContainFractionalAndExponential(input);
            }

            return IsDigitsOnly(input);
        }

        static bool Exponential(string input)
        {
            string exponentnumber = string.Empty;
            if (CountSpecificCharacter(input.ToLower(), 'e') > 1)
            {
                return false;
            }

            ExponentNumber(input, ref exponentnumber);

            return VerifyExponentNumber(exponentnumber);
        }

        static bool VerifyExponentNumber(string input)
        {
            if (!HasContent(input))
            {
                return false;
            }

            if (input[0] == '-' || input[0] == '+')
            {
                input = input.Remove(0, 1);
            }

            return IsDigitsOnly(input) && HasContent(input);
        }

        static void BreakStringInTwoExponential(string input, ref string firstpartofinput, ref string secondpartofinput)
        {
            int indexofpoint = input.ToLower().IndexOf('e');
            firstpartofinput = input.Substring(0, indexofpoint);
            secondpartofinput = input.Substring(indexofpoint + 1, input.Length - 1 - indexofpoint);
        }

        static bool CanContainFractionalAndExponential(string input)
            {
            if (!input.ToLower().Contains('e') || !input.Contains('.'))
            {
                return true;
            }

            string firstpartofstring = string.Empty;
            string secondpartofstring = string.Empty;
            int indexofexponent = input.ToLower().IndexOf('e');
            int indexofpoint = input.IndexOf('.');
            if (indexofexponent < indexofpoint)
            {
                return false;
            }

            BreakStringInTwoExponential(input, ref firstpartofstring, ref secondpartofstring);
            return IsDigitsOnly(secondpartofstring) && CanBeFractional(firstpartofstring);
        }

        static void ExponentNumber(string input, ref string exponent)
        {
            int indexofpoint = input.ToLower().IndexOf('e');
            exponent = input.Substring(indexofpoint + 1, input.Length - 1 - indexofpoint);
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
