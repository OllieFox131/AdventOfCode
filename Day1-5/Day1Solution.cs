namespace ConsoleApp;

public static class Day1Solution
{
    public static void PartOne()
    {
        List<string> words = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day1Task.txt").ToList();
        //List<string> words = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day1Demo.txt").ToList();

        List<int> sums = [];

        foreach (string word in words)
        {
            List<char> numbers = [];

            // Go through word and check if each character is a number if so add it to the number list
            for (int i = 0; i < word.Length; i++)
            {
                if (char.IsDigit(word[i]))
                {
                    numbers.Add(word[i]);
                }
            }

            // Get the first and last number in the list, convert into an int and add to the sum list
            char[] firstAndLast = [numbers[0], numbers[^1]];
            string firstAndLastString = new(firstAndLast);
            _ = int.TryParse(firstAndLastString, out int firstAndLastInt);
            sums.Add(firstAndLastInt);
        }

        Console.WriteLine($"Day 1 Part 1 is: {sums.Sum()}");
    }

    public static void PartTwo()
    {
        List<string> words = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day1Task.txt").ToList();
        //List<string> words = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day1Demo2.txt").ToList();

        List<int> sums = [];

        foreach (string word in words)
        {
            List<char> numbers = [];

            // Go through each character in the word
            for (int i = 0; i < word.Length; i++)
            {
                // If theres more than 3 characters left in the word, check for 1, 2, 6
                // If so add to number list
                if (word.Length >= i + 3)
                {
                    if (word.Substring(i, 3) == "one")
                    {
                        numbers.Add('1');
                    }

                    if (word.Substring(i, 3) == "two")
                    {
                        numbers.Add('2');
                    }

                    if (word.Substring(i, 3) == "six")
                    {
                        numbers.Add('6');
                    }
                }

                // If theres more than 4 characters left in the word, check for 4, 5, 9
                // If so add to number list
                if (word.Length >= i + 4)
                {
                    if (word.Substring(i, 4) == "four")
                    {
                        numbers.Add('4');
                    }

                    if (word.Substring(i, 4) == "five")
                    {
                        numbers.Add('5');
                    }

                    if (word.Substring(i, 4) == "nine")
                    {
                        numbers.Add('9');
                    }
                }

                // If theres more than 5 characters left in the word, check for 3, 7, 8
                // If so add to number list
                if (word.Length >= i + 5)
                {
                    if (word.Substring(i, 5) == "three")
                    {
                        numbers.Add('3');
                    }

                    if (word.Substring(i, 5) == "seven")
                    {
                        numbers.Add('7');
                    }

                    if (word.Substring(i, 5) == "eight")
                    {
                        numbers.Add('8');
                    }
                }

                // Check the character itself is a digit
                // If so add to number list
                if (char.IsDigit(word[i]))
                {
                    numbers.Add(word[i]);
                }
            }

            // Get the first and last number in the list, convert into an int and add to the sum list
            char[] firstAndLast = [numbers[0], numbers[^1]];
            string firstAndLastString = new(firstAndLast);
            _ = int.TryParse(firstAndLastString, out int firstAndLastInt);
            sums.Add(firstAndLastInt);
        }

        Console.WriteLine($"Day 1 Part 2 answer is: {sums.Sum()}");
    }
}
