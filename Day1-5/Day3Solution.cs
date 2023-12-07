namespace ConsoleApp;

public static class Day3Solution
{
    public static void PartOne()
    {
        string[] data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day3Task.txt").ToArray();
        //string[] data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day3Demo.txt").ToArray();

        char[,] charArray = new char[data.Length, data[0].Length];

        List<int> partNumbers = [];

        // Convert the string data into a character array
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                charArray[i, j] = data[i][j];
            }
        }

        // Foreach character in the arrray
        for (int i = 0; i < charArray.GetLength(0); i++)
        {
            for (int j = 0; j < charArray.GetLength(1); j++)
            {
                if (char.IsNumber(charArray[i, j]))
                {
                    // If you can check to the left, check its not a number
                    // If it is then its not the start of the number, ignore and move on to next char
                    if (j - 1 >= 0 && char.IsNumber(charArray[i, j - 1]))
                    {
                        continue;
                    }

                    // If you can check to the right twice and they are both numbers
                    // If there is a symbol around any of the digits, convert the chars into an int and add to the part numbers list, the move on to next char
                    if (j + 1 <= charArray.GetLength(1) - 1 && j + 2 <= charArray.GetLength(1) - 1
                        && char.IsNumber(charArray[i, j + 1]) && char.IsNumber(charArray[i, j + 2])
                        && (Day3SolutionHelpers.SymbolAroundDigit(charArray, i, j)
                        || Day3SolutionHelpers.SymbolAroundDigit(charArray, i, j + 1)
                        || Day3SolutionHelpers.SymbolAroundDigit(charArray, i, j + 2)))
                    {
                        char[] partNunmberChars = [charArray[i, j], charArray[i, j + 1], charArray[i, j + 2]];
                        string partNumberString = new(partNunmberChars);
                        partNumbers.Add(int.Parse(partNumberString));
                        continue;
                    }

                    // If you can check to the right once and it is a number
                    // If there is a symbol around any of the digits, convert the chars into an int and add to the part numbers list, the move on to next char
                    if (j + 1 <= charArray.GetLength(1) - 1
                        && char.IsNumber(charArray[i, j + 1])
                        && (Day3SolutionHelpers.SymbolAroundDigit(charArray, i, j)
                        || Day3SolutionHelpers.SymbolAroundDigit(charArray, i, j + 1)))
                    {
                        char[] partNunmberChars = [charArray[i, j], charArray[i, j + 1]];
                        string partNumberString = new(partNunmberChars);
                        partNumbers.Add(int.Parse(partNumberString));
                        continue;
                    }

                    // If there is a symbol around the digit, convert the char into an int and add to the part numbers list, the move on to next char
                    if (Day3SolutionHelpers.SymbolAroundDigit(charArray, i, j))
                    {
                        char[] partNunmberChars = [charArray[i, j]];
                        string partNumberString = new(partNunmberChars);
                        partNumbers.Add(int.Parse(partNumberString));
                        continue;
                    }
                }
            }
        }

        Console.WriteLine($"Day 3 Part 1 answer is: {partNumbers.Sum()}");
    }

    public static void PartTwo()
    {
        string[] data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day3Task.txt").ToArray();
        //string[] data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day3Demo.txt").ToArray();

        char[,] charArray = new char[data.Length, data[0].Length];

        List<KeyValuePair<int, string>> partsNearAsterisk = [];

        List<int> gearRatios = [];

        // Convert string into char array
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                charArray[i, j] = data[i][j];
            }
        }

        // Foreach character in array
        for (int i = 0; i < charArray.GetLength(0); i++)
        {
            for (int j = 0; j < charArray.GetLength(1); j++)
            {
                if (char.IsNumber(charArray[i, j]))
                {
                    // If you can check to the left, check its not a number
                    // If it is then its not the start of the number, ignore and move on to next char
                    if (j - 1 >= 0 && char.IsNumber(charArray[i, j - 1]))
                    {
                        continue;
                    }

                    // If you can check to the right twice and they are both numbers
                    // If there is a * around any of the digits, convert the chars into an int
                    // Then add the int and the asterisk location to the part near asterisk list
                    // Finally move on to next char
                    if (j + 1 <= charArray.GetLength(1) - 1 && j + 2 <= charArray.GetLength(1) - 1
                        && char.IsNumber(charArray[i, j + 1]) && char.IsNumber(charArray[i, j + 2])
                        && (Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j) != "(0, 0)"
                        || Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j + 1) != "(0, 0)"
                        || Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j + 2) != "(0, 0)"))
                    {
                        string asteriskLocation = "(0,0)";

                        // Figure out where this asterisk detection actually came from and store the location
                        if (Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j) != "(0, 0)")
                        {
                            asteriskLocation = Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j);
                        }
                        else if (Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j + 1) != "(0, 0)")
                        {
                            asteriskLocation = Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j + 1);
                        }
                        else if (Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j + 2) != "(0, 0)")
                        {
                            asteriskLocation = Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j + 2);
                        }

                        char[] partNunmberChars = [charArray[i, j], charArray[i, j + 1], charArray[i, j + 2]];
                        string partNumberString = new(partNunmberChars);
                        partsNearAsterisk.Add(new KeyValuePair<int, string>(int.Parse(partNumberString), asteriskLocation));
                        continue;
                    }

                    // If you can check to the right once and it is a number
                    // If there is a * around any of the digits, convert the chars into an int
                    // Then add the int and the asterisk location to the part near asterisk list
                    // Finally move on to next char
                    if (j + 1 <= charArray.GetLength(1) - 1
                        && char.IsNumber(charArray[i, j + 1])
                        && (Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j) != "(0, 0)"
                        || Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j + 1) != "(0, 0)"))
                    {
                        string asteriskLocation = "(0,0)";

                        // Figure out where this asterisk detection actually came from and store the location
                        if (Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j) != "(0, 0)")
                        {
                            asteriskLocation = Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j);
                        }
                        else if (Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j + 1) != "(0, 0)")
                        {
                            asteriskLocation = Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j + 1);
                        }

                        char[] partNunmberChars = [charArray[i, j], charArray[i, j + 1]];
                        string partNumberString = new(partNunmberChars);
                        partsNearAsterisk.Add(new KeyValuePair<int, string>(int.Parse(partNumberString), asteriskLocation));
                        continue;
                    }

                    // If there is a * around the digit, convert the char into an int
                    // Then add the int and the asterisk location to the part near asterisk list
                    // Finally move on to next char
                    if (Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j) != "(0, 0)")
                    {
                        string asteriskLocation = "(0,0)";

                        // Figure out where this asterisk detection actually came from and store the location
                        if (Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j) != "(0, 0)")
                        {
                            asteriskLocation = Day3SolutionHelpers.AsteriskAroundDigit(charArray, i, j);
                        }

                        char[] partNunmberChars = [charArray[i, j]];
                        string partNumberString = new(partNunmberChars);
                        partsNearAsterisk.Add(new KeyValuePair<int, string>(int.Parse(partNumberString), asteriskLocation));
                        continue;
                    }
                }
            }
        }

        // Check to see if there are multiple registrations of the same asterisk location
        // If so the parts are geared together
        foreach (IGrouping<string, int>? duplicate in partsNearAsterisk.ToLookup(x => x.Value, x => x.Key).Where(x => x.Count() > 1))
        {
            // Find the gears which are paired together, there should only be 2
            IEnumerable<KeyValuePair<int, string>> geared = partsNearAsterisk.Where(x => x.Value == duplicate.Key);

            // Add the product of the gears to the gear ratio array
            gearRatios.Add(geared.First().Key * geared.Last().Key);
        }

        Console.WriteLine($"Day 3 Part 2 answer is: {gearRatios.Sum()}");
    }
}
