namespace ConsoleApp;

public static class Day2Solution
{
    public static void PartOne()
    {
        List<string> gameData = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day2Task.txt").ToList();
        //List<string> gameData = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day2Demo.txt").ToList();

        List<int> validGameIds = [];

        foreach (string game in gameData)
        {
            List<int> blueResults = [];
            List<int> redResults = [];
            List<int> greenResults = [];

            // Get the game id from the first part of the string
            string gameIdString = game.Split(": ")[0];
            string gameOnlyIdString = gameIdString.Replace("Game ", "");
            _ = int.TryParse(gameOnlyIdString, out int gameId);

            // Get the actual game data from the second part of the string and split into rounds
            string actualGame = game.Split(": ")[1];
            foreach (string round in (List<string>)([.. actualGame.Split("; ")]))
            {
                // Get each result from a game round
                foreach (string result in (List<string>)([.. round.Split(", ")]))
                {
                    // Check if a red result, if so convert to int and add to red results list
                    if (result.EndsWith("red"))
                    {
                        string resultVal = result.Replace(" red", "");
                        _ = int.TryParse(resultVal, out int resultInt);
                        redResults.Add(resultInt);
                    }

                    // Check if a green result, if so convert to int and add to green results list
                    if (result.EndsWith("green"))
                    {
                        string resultVal = result.Replace(" green", "");
                        _ = int.TryParse(resultVal, out int resultInt);
                        greenResults.Add(resultInt);
                    }

                    // Check if a blue result, if so convert to int and add to blue results list
                    if (result.EndsWith("blue"))
                    {
                        string resultVal = result.Replace(" blue", "");
                        _ = int.TryParse(resultVal, out int resultInt);
                        blueResults.Add(resultInt);
                    }
                }
            }

            // Check results dont break any rules, if not add game id to valid game id list
            if (redResults.Max() <= 12 && greenResults.Max() <= 13 && blueResults.Max() <= 14)
            {
                validGameIds.Add(gameId);
            }
        }

        Console.WriteLine($"Day 2 Part 1 answer is: {validGameIds.Sum()}");
    }

    public static void PartTwo()
    {
        List<string> gameData = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day2Task.txt").ToList();
        //List<string> gameData = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day2Demo.txt").ToList();

        List<int> powers = [];

        foreach (string game in gameData)
        {
            List<int> blueResults = [];
            List<int> redResults = [];
            List<int> greenResults = [];

            // Get the actual game data from the second part of the string and split into rounds
            string actualGame = game.Split(": ")[1];
            foreach (string round in (List<string>)([.. actualGame.Split("; ")]))
            {
                // Get each result from a game round
                foreach (string result in (List<string>)([.. round.Split(", ")]))
                {
                    // Check if a red result, if so convert to int and add to red results list
                    if (result.EndsWith("red"))
                    {
                        string resultVal = result.Replace(" red", "");
                        _ = int.TryParse(resultVal, out int resultInt);
                        redResults.Add(resultInt);
                    }

                    // Check if a green result, if so convert to int and add to green results list
                    if (result.EndsWith("green"))
                    {
                        string resultVal = result.Replace(" green", "");
                        _ = int.TryParse(resultVal, out int resultInt);
                        greenResults.Add(resultInt);
                    }

                    // Check if a blue result, if so convert to int and add to blue results list
                    if (result.EndsWith("blue"))
                    {
                        string resultVal = result.Replace(" blue", "");
                        _ = int.TryParse(resultVal, out int resultInt);
                        blueResults.Add(resultInt);
                    }
                }
            }

            // Multiply all the max results and add to the powers list
            powers.Add(redResults.Max() * greenResults.Max() * blueResults.Max());
        }

        Console.WriteLine($"Day 2 Part 2 answer is: {powers.Sum()}");
    }
}
