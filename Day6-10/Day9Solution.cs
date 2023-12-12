using System.Text.RegularExpressions;

namespace ConsoleApp;

public static partial class Day9Solution
{
    public static void PartOne()
    {
        List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day9Task.txt").ToList();
        //List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day9Demo.txt").ToList();

        List<int> finalNumbers = [];

        foreach (string sequence in data)
        {
            // Get all numbers
            MatchCollection matches = GetNumbers().Matches(sequence);

            // Make a list of all numbers found
            List<int> numbers = [];
            numbers.AddRange(matches.Select(match => int.Parse(match.Value)));

            // Get last number, we will add all these together to find the next
            List<int> lastNumbersOfSequences = [numbers[^1]];
            bool finished = false;

            // For each set of numbers till all differences are constant
            while (!finished)
            {
                // Get differences
                List<int> differences = numbers.Skip(1).Select((x, i) => x - numbers[i]).ToList();
                // Note last number in sequence
                lastNumbersOfSequences.Add(differences[^1]);

                // If differences arent all constant, set differences to next number set
                if (differences.Distinct().Count() > 1)
                {
                    numbers = differences;
                }
                // Else we are finished
                else
                {
                    finished = true;
                }
            }

            // Add last numbers to get final number for sequence
            finalNumbers.Add(lastNumbersOfSequences.Sum());
        }

        // Add all final numbers of sequences
        Console.WriteLine($"Day 9 Part 1 answer is: {finalNumbers.Sum()}");
    }

    public static void PartTwo()
    {
        List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day9Task.txt").ToList();
        //List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day9Demo.txt").ToList();

        List<int> firstNumbers = [];

        foreach (string sequence in data)
        {
            // Get numbers
            MatchCollection matches = GetNumbers().Matches(sequence);

            // Make list of all numbers found
            List<int> numbers = [];
            numbers.AddRange(matches.Select(match => int.Parse(match.Value)));

            // Get first number, we will use these to create previous number
            List<int> firstNumbersOfSequences = [numbers[0]];
            bool finished = false;

            while (!finished)
            {
                // Get differences
                List<int> differences = numbers.Skip(1).Select((x, i) => x - numbers[i]).ToList();
                // Note first difference in sequence
                firstNumbersOfSequences.Add(differences[0]);

                // If differences arent all constant, set differences to next number set
                if (differences.Distinct().Count() > 1)
                {
                    numbers = differences;
                }
                // Else we are finished
                else
                {
                    finished = true;
                }
            }

            // Make a sum to get the first number
            int firstNumbersSum = 0;

            // If from an odd nth row, subtract, else add
            for (int i = 0; i < firstNumbersOfSequences.Count; i++)
            {
                if (i % 2 == 0)
                {
                    firstNumbersSum += firstNumbersOfSequences[i];
                }
                else
                {
                    firstNumbersSum -= firstNumbersOfSequences[i];
                }
            }

            // Add first numbers sum for the final number for sequence
            firstNumbers.Add(firstNumbersSum);
        }

        // Add all our first numbers of sequences
        Console.WriteLine($"Day 9 Part 2 answer is: {firstNumbers.Sum()}");
    }

    [GeneratedRegex(@"-?\d+")]
    private static partial Regex GetNumbers();
}
