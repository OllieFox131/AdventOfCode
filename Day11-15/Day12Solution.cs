using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp;

public static partial class Day12Solution
{
    public static void PartOne()
    {
        string[] data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day11-15\\TextFiles\\Day12Task.txt").ToArray();
        //string[] data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day11-15\\TextFiles\\Day12Demo.txt").ToArray();

        List<(string sequence, string arragement)> lines = [];

        foreach (string line in data)
        {
            string[] split = line.Split(" ");
            lines.Add((split[0], split[1]));
        }

        int finalCount = 0;

        foreach ((string sequence, string arragement) line in lines)
        {
            List<string> sequences = [];
            List<string> newSequences = [];

            for (int i = 0; i < line.sequence.Length; i++)
            {
                if (sequences.Count == 0)
                {
                    if (line.sequence[i] == '?')
                    {
                        newSequences.Add("#");
                        newSequences.Add(".");
                    }
                    else
                    {
                        newSequences.Add(line.sequence[i].ToString());
                    }
                }
                else
                {
                    foreach (string sequence in sequences)
                    {
                        if (line.sequence[i] == '?')
                        {
                            newSequences.Add(sequence + "#");
                            newSequences.Add(sequence + ".");
                        }
                        else
                        {
                            newSequences.Add(sequence + line.sequence[i].ToString());
                        }
                    }
                }

                sequences = [];

                foreach (string sequence in newSequences)
                {
                    StringBuilder sequenceArrangement = new();

                    foreach (Match match in Hashes().Matches(sequence).Cast<Match>())
                    {
                        sequenceArrangement.Append(match.Value.ToCharArray().Count(c => c == '#')).Append(',');
                    }

                    string finalSequenceArrangement = sequenceArrangement.ToString();

                    if (finalSequenceArrangement.Length > 2)
                    {
                        if (line.arragement.StartsWith(finalSequenceArrangement[..^2]))
                        {
                            sequences.Add(sequence);
                        }
                    }
                    else
                    {
                        sequences.Add(sequence);
                    }
                }

                newSequences = [];
            }

            int count = 0;
            foreach (string sequence in sequences)
            {
                StringBuilder sequenceArrangement = new();

                foreach (Match match in Hashes().Matches(sequence).Cast<Match>())
                {
                    sequenceArrangement.Append(match.Value.ToCharArray().Count(c => c == '#')).Append(',');
                }

                if (sequenceArrangement.ToString() == line.arragement + ",")
                {
                    count++;
                }
            }

            finalCount += count;
        }

        Console.WriteLine($"Day 12 Part 1 answer is: {finalCount}");
    }

    public static void PartTwo()
    {
        string[] data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day11-15\\TextFiles\\Day12Task.txt").ToArray();
        //string[] data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day11-15\\TextFiles\\Day12Demo.txt").ToArray();

        List<(string sequence, string arragement)> lines = [];

        var part2 = 0L;
        var cache = new Dictionary<string, long>();

        foreach (string line in data)
        {
            string[] split = line.Split(" ");

            string springs = split[0];
            List<int> groups = split[1].Split(',').Select(int.Parse).ToList();

            springs = string.Join('?', Enumerable.Repeat(springs, 5));
            groups = Enumerable.Repeat(groups, 5).SelectMany(g => g).ToList();

            part2 += Calculate(springs, groups);
        }

        long Calculate(string springs, List<int> groups)
        {
            var key = $"{springs},{string.Join(',', groups)}";  // Cache key: spring pattern + group lengths

            if (cache.TryGetValue(key, out var value))
            {
                return value;
            }

            value = GetCount(springs, groups);
            cache[key] = value;

            return value;
        }

        long GetCount(string springs, List<int> groups)
        {
            while (true)
            {
                if (groups.Count == 0)
                {
                    return springs.Contains('#') ? 0 : 1; // No more groups to match: if there are no springs left, we have a match
                }

                if (string.IsNullOrEmpty(springs))
                {
                    return 0; // No more springs to match, although we still have groups to match
                }

                if (springs.StartsWith('.'))
                {
                    springs = springs.Trim('.'); // Remove all dots from the beginning
                    continue;
                }

                if (springs.StartsWith('?'))
                {
                    return Calculate("." + springs[1..], groups) + Calculate("#" + springs[1..], groups); // Try both options recursively
                }

                if (springs.StartsWith('#')) // Start of a group
                {
                    if (groups.Count == 0)
                    {
                        return 0; // No more groups to match, although we still have a spring in the input
                    }

                    if (springs.Length < groups[0])
                    {
                        return 0; // Not enough characters to match the group
                    }

                    if (springs[..groups[0]].Contains('.'))
                    {
                        return 0; // Group cannot contain dots for the given length
                    }

                    if (groups.Count > 1)
                    {
                        if (springs.Length < groups[0] + 1 || springs[groups[0]] == '#')
                        {
                            return 0; // Group cannot be followed by a spring, and there must be enough characters left
                        }

                        springs = springs[(groups[0] + 1)..]; // Skip the character after the group - it's either a dot or a question mark
                        groups = groups[1..];
                        continue;
                    }

                    springs = springs[groups[0]..]; // Last group, no need to check the character after the group
                    groups = groups[1..];
                    continue;
                }

                throw new Exception("Invalid input");
            }
        }

        Console.WriteLine($"Day 12 Part 2 answer is: {part2}");
    }

    [GeneratedRegex(@"#+")]
    private static partial Regex Hashes();
}
