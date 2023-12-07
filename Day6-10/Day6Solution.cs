namespace ConsoleApp;

public static class Day6Solution
{
    public static void PartOne()
    {
        List<int> times = [44, 89, 96, 91];
        List<int> records = [277, 1136, 1890, 1768];
        //List<int> times = [7, 15, 30];
        //List<int> records = [9, 40, 200];

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

        Console.WriteLine($"Final answer is: {finalScore}");
    }

    public static void PartTwo()
    {
        List<long> times = [44899691];
        List<long> records = [277113618901768];
        //List<long> times = [71530];
        //List<long> records = [940200];

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

        Console.WriteLine($"Final answer is: {finalScore}");
    }
}
