namespace ConsoleApp;

internal static class Day3SolutionHelpers
{
    public static string AsteriskAroundDigit(char[,] charArray, int i, int j)
    {
        if (i - 1 >= 0)
        {
            if (j - 1 >= 0 && charArray[i - 1, j - 1] == '*')
            {
                return $"({i - 1}, {j - 1})";
            }

            if (charArray[i - 1, j] == '*')
            {
                return $"({i - 1}, {j})";
            }

            if (j + 1 <= charArray.GetLength(1) - 1 && charArray[i - 1, j + 1] == '*')
            {
                return $"({i - 1}, {j + 1})";
            }
        }

        if (i + 1 <= charArray.GetLength(0) - 1)
        {
            if (j - 1 >= 0 && charArray[i + 1, j - 1] == '*')
            {
                return $"({i + 1}, {j - 1})";
            }

            if (charArray[i + 1, j] == '*')
            {
                return $"({i + 1}, {j})";
            }

            if (j + 1 <= charArray.GetLength(1) - 1 && charArray[i + 1, j + 1] == '*')
            {
                return $"({i + 1}, {j + 1})";
            }
        }

        if (j - 1 >= 0 && charArray[i, j - 1] == '*')
        {
            return $"({i}, {j - 1})";
        }

        if (j + 1 <= charArray.GetLength(1) - 1 && charArray[i, j + 1] == '*')
        {
            return $"({i}, {j + 1})";
        }

        return "(0, 0)";
    }

    public static bool SymbolAroundDigit(char[,] charArray, int i, int j)
    {
        // If you can check above
        if (i - 1 >= 0)
        {
            // If you can check to left and its not a letter, digit or . then its a symbol return true
            if (j - 1 >= 0 && !char.IsLetterOrDigit(charArray[i - 1, j - 1]) && charArray[i - 1, j - 1] != '.')
            {
                return true;
            }

            // If its not a letter, digit or . then its a symbol return true
            if (!char.IsLetterOrDigit(charArray[i - 1, j]) && charArray[i - 1, j] != '.')
            {
                return true;
            }

            // If you can check to right and its not a letter, digit or . then its a symbol return true
            if (j + 1 <= charArray.GetLength(1) - 1 && !char.IsLetterOrDigit(charArray[i - 1, j + 1]) && charArray[i - 1, j + 1] != '.')
            {
                return true;
            }
        }

        // If you can check below
        if (i + 1 <= charArray.GetLength(0) - 1)
        {
            // If you can check to left and its not a letter, digit or . then its a symbol return true
            if (j - 1 >= 0 && !char.IsLetterOrDigit(charArray[i + 1, j - 1]) && charArray[i + 1, j - 1] != '.')
            {
                return true;
            }

            // If its not a letter, digit or . then its a symbol return true
            if (!char.IsLetterOrDigit(charArray[i + 1, j]) && charArray[i + 1, j] != '.')
            {
                return true;
            }

            // If you can check to right and its not a letter, digit or . then its a symbol return true
            if (j + 1 <= charArray.GetLength(1) - 1 && !char.IsLetterOrDigit(charArray[i + 1, j + 1]) && charArray[i + 1, j + 1] != '.')
            {
                return true;
            }
        }

        // If you can check to left and its not a letter, digit or . then its a symbol return true
        if (j - 1 >= 0 && !char.IsLetterOrDigit(charArray[i, j - 1]) && charArray[i, j - 1] != '.')
        {
            return true;
        }

        // If you can check to right and its not a letter, digit or . then its a symbol return true
        if (j + 1 <= charArray.GetLength(1) - 1 && !char.IsLetterOrDigit(charArray[i, j + 1]) && charArray[i, j + 1] != '.')
        {
            return true;
        }

        return false;
    }
}