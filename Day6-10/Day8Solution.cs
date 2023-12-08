using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace ConsoleApp;

public static partial class Day8Solution
{
    public static void PartOne()
    {
        List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day8Task.txt").ToList();
        //List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day8Demo.txt").ToList();

        List<char> instructions = [.. data[0]];
        List<string> nodes = data.Skip(2).ToList();

        Dictionary<string, string> deconstructedNodes = [];

        foreach (string node in nodes)
        {
            MatchCollection matches = ThreeAlpha().Matches(node);
            deconstructedNodes.Add($"{matches[0].Value}L", matches[1].Value);
            deconstructedNodes.Add($"{matches[0].Value}R", matches[2].Value);
        }

        bool finished = false;
        string location = "AAA";
        int count = 0;
        int stepsTaken = 0;

        while (!finished)
        {
            if (count == instructions.Count)
            {
                count = 0;
            }

            location = deconstructedNodes[$"{location}{instructions[count]}"];

            if (location == "ZZZ")
            {
                finished = true;
            }

            count++;
            stepsTaken++;
        }

        Console.WriteLine($"Day 8 Part 1 answer is: {stepsTaken}");
    }

    public static void PartTwo()
    {
        List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day8Task.txt").ToList();
        //List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day8Demo3.txt").ToList();

        List<char> instructions = [.. data[0]];
        List<string> nodes = data.Skip(2).ToList();

        Dictionary<string, string> deconstructedNodes = [];
        List<string> locations = [];

        foreach (string node in nodes)
        {
            MatchCollection matches = ThreeAlphaNumeric().Matches(node);
            deconstructedNodes.Add($"{matches[0].Value}L", matches[1].Value);
            deconstructedNodes.Add($"{matches[0].Value}R", matches[2].Value);

            if (matches[0].Value.EndsWith('A'))
            {
                locations.Add(matches[0].Value);
            }
        }

        List<int> minSteps = [];

        foreach (string location in locations)
        {
            bool finished = false;
            int count = 0;
            int stepsTaken = 0;
            string calculatedLocation = location;

            while (!finished)
            {
                if (count == instructions.Count)
                {
                    count = 0;
                }

                calculatedLocation = deconstructedNodes[$"{calculatedLocation}{instructions[count]}"];

                if (calculatedLocation.EndsWith('Z'))
                {
                    finished = true;
                }

                count++;
                stepsTaken++;
            }

            minSteps.Add(stepsTaken);
        }

        Console.WriteLine($"Day 8 Part 2 answer is: {Day8SolutionHelpers.FindLCMOfArray([.. minSteps])}");
    }

    [GeneratedRegex("[A-Za-z]{3}")]
    private static partial Regex ThreeAlpha();
    [GeneratedRegex("[A-Za-z1-9]{3}")]
    private static partial Regex ThreeAlphaNumeric();
}
