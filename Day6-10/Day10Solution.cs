namespace ConsoleApp;

public static class Day10Solution
{
    public static void PartOne()
    {
        string[] data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day10Task.txt").ToArray();
        //string[] data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day10Demo3.txt").ToArray();

        char[,] charArray = new char[data.Length, data[0].Length];

        Dictionary<string, char> pipes = [];

        (char pipeType, int i, int j) firstPipe = ('S', 1, 1);

        // Convert the string data into a character array
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                charArray[i, j] = data[i][j];

                if (data[i][j] == 'S')
                {
                    firstPipe = ('S', i, j);
                    pipes.Add($"({i},{j})", data[i][j]);
                }
            }
        }

        // Record location of first pipe
        (char pipeType, int i, int j) lastPipe = new('S', firstPipe.i, firstPipe.j);

        // Find next pipe
        (char pipeType, int i, int j) nextPipe = Day10SolutionHelpers.NextPipeToStart(charArray, firstPipe.i, firstPipe.j);

        // Add to pipe dictionary
        pipes.Add($"({nextPipe.i},{nextPipe.j})", nextPipe.pipeType);

        bool finished = false;

        while (!finished)
        {
            // store next pipe
            (char pipeType, int i, int j) oldNextPipe = nextPipe;

            // Find new next pipe
            nextPipe = Day10SolutionHelpers.NextPipe(charArray, nextPipe, lastPipe);

            // If next pipe type is S we are finished
            if (nextPipe.pipeType == 'S')
            {
                finished = true;
            }
            // Else add to pipe dictionary and set the old next pipe to be the new last pipe
            else
            {
                pipes.Add($"({nextPipe.i},{nextPipe.j})", nextPipe.pipeType);
                lastPipe = oldNextPipe;
            }
        }

        // Furtherst distance is half the number of pipes
        Console.WriteLine($"Day 10 Part 1 answer is: {pipes.Count / 2}");
    }

    public static void PartTwo()
    {
        string[] data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day10Task.txt").ToArray();
        //string[] data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day10Demo3.txt").ToArray();

        char[,] charArray = new char[data.Length, data[0].Length];

        Dictionary<string, char> pipes = [];

        (char pipeType, int i, int j) firstPipe = ('S', 1, 1);

        // Convert the string data into a character array
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                charArray[i, j] = data[i][j];

                if (data[i][j] == 'S')
                {
                    firstPipe = ('S', i, j);
                    pipes.Add($"({i},{j})", data[i][j]);
                }
            }
        }

        // Record location of first pipe
        (char pipeType, int i, int j) lastPipe = new('S', firstPipe.i, firstPipe.j);

        // Find next pipe
        (char pipeType, int i, int j) nextPipe = Day10SolutionHelpers.NextPipeToStart(charArray, firstPipe.i, firstPipe.j);

        // Add to pipe dictionary
        pipes.Add($"({nextPipe.i},{nextPipe.j})", nextPipe.pipeType);

        bool finished = false;

        while (!finished)
        {
            // store next pipe
            (char pipeType, int i, int j) oldNextPipe = nextPipe;

            // Find new next pipe
            nextPipe = Day10SolutionHelpers.NextPipe(charArray, nextPipe, lastPipe);

            // If next pipe type is S we are finished
            if (nextPipe.pipeType == 'S')
            {
                finished = true;
            }
            // Else add to pipe dictionary and set the old next pipe to be the new last pipe
            else
            {
                pipes.Add($"({nextPipe.i},{nextPipe.j})", nextPipe.pipeType);
                lastPipe = oldNextPipe;
            }
        }

        // Trick answer, all trapped squares are in a central quarter square of original grid
        int count = 0;
        // Look through central square
        for (int i = data.Length / 4; i < 3 * data.Length / 4; i++)
        {
            for (int j = data[i].Length / 4; j < 3 * data[i].Length / 4; j++)
            {
                string coord = $"({i},{j})";

                // If not a pipe, add to count
                if (!pipes.Keys.Contains(coord))
                {
                    count++;
                }
            }
        }

        Console.WriteLine($"Day 10 Part 1 answer is: {count}");
    }
}
