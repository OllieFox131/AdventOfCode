using System.Text.RegularExpressions;
using System.Linq;

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
            MatchCollection matches = GetNumbers().Matches(sequence);

            List<int> numbers = [];
            numbers.AddRange(matches.Select(match => int.Parse(match.Value)));

            List<int> lastNumbersOfSequences = [numbers[^1]];
            bool finished = false;

            while (!finished)
            {
                List<int> differences = numbers.Skip(1).Select((x, i) => x - numbers[i]).ToList();
                lastNumbersOfSequences.Add(differences[^1]);

                if (differences.Distinct().Count() > 1)
                {
                    numbers = differences;
                }
                else
                {
                    finished = true;
                }
            }

            finalNumbers.Add(lastNumbersOfSequences.Sum());
        }

        Console.WriteLine($"Day 9 Part 1 answer is: {finalNumbers.Sum()}");
    }

    public static void PartTwo()
    {
        List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day9Task.txt").ToList();
        //List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day9Demo.txt").ToList();

        List<int> finalNumbers = [];

        foreach (string sequence in data)
        {
            MatchCollection matches = GetNumbers().Matches(sequence);

            List<int> numbers = [];
            numbers.AddRange(matches.Select(match => int.Parse(match.Value)));

            List<int> firstNumbersOfSequences = [numbers[0]];
            bool finished = false;

            while (!finished)
            {
                List<int> differences = numbers.Skip(1).Select((x, i) => x - numbers[i]).ToList();
                firstNumbersOfSequences.Add(differences[0]);

                if (differences.Distinct().Count() > 1)
                {
                    numbers = differences;
                }
                else
                {
                    finished = true;
                }
            }

            int firstNumbersSum = 0;

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

            finalNumbers.Add(firstNumbersSum);
        }

        Console.WriteLine($"Day 9 Part 2 answer is: {finalNumbers.Sum()}");
    }

    [GeneratedRegex(@"-?\d+")]
    private static partial Regex GetNumbers();
}
