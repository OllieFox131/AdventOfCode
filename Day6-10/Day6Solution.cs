using System.Text.RegularExpressions;

namespace ConsoleApp;

public static partial class Day6Solution
{
    public static void PartOne()
    {
        List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day6Task.txt").ToList();
        //List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day6Demo.txt").ToList();

        Regex regex = MyRegex();

        List<int> times = [];
        List<int> records = [];

        foreach (Match match in regex.Matches(data[0]).Cast<Match>())
        {
            if (int.TryParse(match.Value, out int number))
            {
                times.Add(number);
            }
        }

        foreach (Match match in regex.Matches(data[1]).Cast<Match>())
        {
            if (int.TryParse(match.Value, out int number))
            {
                records.Add(number);
            }
        }

        Dictionary<int, Dictionary<int, int>> results = [];
        List<int> timesRecordBeaten = [];

        foreach (int time in times)
        {
            Dictionary<int, int> roundResult = [];

            // For every hold time up to the time
            // Calculate the distance travel
            // Add a log of the round results
            for (int holdTime = 1; holdTime < time; holdTime++)
            {
                int distance = holdTime * (time - holdTime);
                roundResult.Add(holdTime, distance);
            }
            // Add the round results to a full results list with the index of the time
            results.Add(times.IndexOf(time), roundResult);
        }

        foreach (KeyValuePair<int, Dictionary<int, int>> result in results)
        {
            // Get the record and set a count of how many times the record has been beaten
            int record = records[result.Key];
            int recordBeaten = 0;

            // Foreach race result, if record was beaten add to count
            foreach (KeyValuePair<int, int> raceResult in result.Value)
            {
                if (raceResult.Value > record)
                {
                    recordBeaten++;
                }
            }

            // Add the final record beaten count to the times record beaten list
            timesRecordBeaten.Add(recordBeaten);
        }

        // Create a final score count
        int finalScore = 1;

        // Foreach value of times record beaten, multiple the final score
        foreach (int timesRecordBeat in timesRecordBeaten)
        {
            finalScore *= timesRecordBeat;
        }

        Console.WriteLine($"Day 6 Part 1 answer is: {finalScore}");
    }

    public static void PartTwo()
    {
        List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day6Task.txt").ToList();
        //List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day6Demo.txt").ToList();

        List<long> times = [];
        List<long> records = [];

        times.Add(long.Parse(string.Concat(data[0].ToCharArray().Where(char.IsDigit))));
        records.Add(long.Parse(string.Concat(data[1].ToCharArray().Where(char.IsDigit))));

        Dictionary<int, Dictionary<int, long>> results = [];
        List<long> timesRecordBeaten = [];

        foreach (long time in times)
        {
            Dictionary<int, long> roundResult = [];

            // For every hold time up to the time
            // Calculate the distance travel
            // Add a log of the round results
            for (int holdTime = 1; holdTime < time; holdTime++)
            {
                long distance = holdTime * (time - holdTime);
                roundResult.Add(holdTime, distance);
            }
            // Add the round results to a full results list with the index of the time
            results.Add(times.IndexOf(time), roundResult);
        }

        foreach (KeyValuePair<int, Dictionary<int, long>> result in results)
        {
            // Get the record and set a count of how many times the record has been beaten
            long record = records[result.Key];
            int recordBeaten = 0;

            // Foreach race result, if record was beaten add to count
            foreach (KeyValuePair<int, long> raceResult in result.Value)
            {
                if (raceResult.Value > record)
                {
                    recordBeaten++;
                }
            }

            // Add the final record beaten count to the times record beaten list
            timesRecordBeaten.Add(recordBeaten);
        }

        // Create a final score count
        long finalScore = 1;

        // Foreach value of times record beaten, multiple the final score
        foreach (long timeRecordBeat in timesRecordBeaten)
        {
            finalScore *= timeRecordBeat;
        }

        Console.WriteLine($"Day 6 Part 2 answer is: {finalScore}");
    }

    [GeneratedRegex(@"\b\d+\b")]
    private static partial Regex MyRegex();
}
