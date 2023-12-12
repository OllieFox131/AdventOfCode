namespace ConsoleApp;

public static class Day11Solution
{
    public static void PartOne()
    {
        string[] data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day11-15\\TextFiles\\Day11Task.txt").ToArray();
        //string[] data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day11-15\\TextFiles\\Day11Demo.txt").ToArray();

        const double multiFactor = 2 - 1;

        char[,] charArray = new char[data.Length, data[0].Length];
        Dictionary<int, (int x, int y)> galaxies = [];

        int count = 1;
        // Convert the string data into a character array
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                charArray[i, j] = data[i][j];

                if (charArray[i, j] == '#')
                {
                    galaxies.Add(count, (i, j));
                    count++;
                }
            }
        }

        List<int> emptyRows = [];
        List<int> emptyCols = [];

        for (int i = 0; i < charArray.GetLength(0); i++)
        {
            char[] rowArray = new char[charArray.GetLength(1)];

            for (int j = 0; j < charArray.GetLength(1); j++)
            {
                rowArray[j] = charArray[i, j];
            }

            if (!rowArray.Contains('#'))
            {
                emptyRows.Add(i);
            }
        }

        for (int j = 0; j < charArray.GetLength(1); j++)
        {
            char[] colArray = new char[charArray.GetLength(0)];

            for (int i = 0; i < charArray.GetLength(0); i++)
            {
                colArray[i] = charArray[i, j];
            }

            if (!colArray.Contains('#'))
            {
                emptyCols.Add(j);
            }
        }

        double distancesTotal = 0;

        foreach (KeyValuePair<int, (int x, int y)> galaxy1 in galaxies)
        {
            double distancesForGalaxies = 0;
            foreach ((int x, int y) in galaxies.Where(g => g.Key > galaxy1.Key).Select(galaxy2 => galaxy2.Value))
            {
                List<int> rowsBetweenGalaxies = [];
                List<int> colsBetweenGalaxies = [];

                if (galaxy1.Value.x > x)
                {
                    for (int i = x; i < galaxy1.Value.x; i++)
                    {
                        rowsBetweenGalaxies.Add(i);
                    }
                }
                else if (galaxy1.Value.x < x)
                {
                    for (int i = galaxy1.Value.x; i < x; i++)
                    {
                        rowsBetweenGalaxies.Add(i);
                    }
                }

                if (galaxy1.Value.y > y)
                {
                    for (int i = y; i < galaxy1.Value.y; i++)
                    {
                        colsBetweenGalaxies.Add(i);
                    }
                }
                else if (galaxy1.Value.y < y)
                {
                    for (int i = galaxy1.Value.y; i < y; i++)
                    {
                        colsBetweenGalaxies.Add(i);
                    }
                }

                double emptyRowsBetweenGalaxies = multiFactor * rowsBetweenGalaxies.Count(emptyRows.Contains);
                double emptyColsBetweenGalaxies = multiFactor * colsBetweenGalaxies.Count(emptyCols.Contains);

                distancesForGalaxies += Math.Abs(galaxy1.Value.x - x) + emptyRowsBetweenGalaxies + Math.Abs(galaxy1.Value.y - y) + emptyColsBetweenGalaxies;
            }

            distancesTotal += distancesForGalaxies;
        }

        // Furtherst distance is half the number of pipes
        Console.WriteLine($"Day 10 Part 1 answer is: {distancesTotal}");
    }

    public static void PartTwo()
    {
        string[] data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day11-15\\TextFiles\\Day11Task.txt").ToArray();
        //string[] data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day11-15\\TextFiles\\Day11Demo.txt").ToArray();

        const double multiFactor = 1000000 - 1;

        char[,] charArray = new char[data.Length, data[0].Length];
        Dictionary<int, (int x, int y)> galaxies = [];

        int count = 1;
        // Convert the string data into a character array
        for (int i = 0; i < data.Length; i++)
        {
            for (int j = 0; j < data[i].Length; j++)
            {
                charArray[i, j] = data[i][j];

                if (charArray[i, j] == '#')
                {
                    galaxies.Add(count, (i, j));
                    count++;
                }
            }
        }

        List<int> emptyRows = [];
        List<int> emptyCols = [];

        for (int i = 0; i < charArray.GetLength(0); i++)
        {
            char[] rowArray = new char[charArray.GetLength(1)];

            for (int j = 0; j < charArray.GetLength(1); j++)
            {
                rowArray[j] = charArray[i, j];
            }

            if (!rowArray.Contains('#'))
            {
                emptyRows.Add(i);
            }
        }

        for (int j = 0; j < charArray.GetLength(1); j++)
        {
            char[] colArray = new char[charArray.GetLength(0)];

            for (int i = 0; i < charArray.GetLength(0); i++)
            {
                colArray[i] = charArray[i, j];
            }

            if (!colArray.Contains('#'))
            {
                emptyCols.Add(j);
            }
        }

        double distancesTotal = 0;

        foreach (KeyValuePair<int, (int x, int y)> galaxy1 in galaxies)
        {
            double distancesForGalaxies = 0;
            foreach ((int x, int y) in galaxies.Where(g => g.Key > galaxy1.Key).Select(galaxy2 => galaxy2.Value))
            {
                List<int> rowsBetweenGalaxies = [];
                List<int> colsBetweenGalaxies = [];

                if (galaxy1.Value.x > x)
                {
                    for (int i = x; i < galaxy1.Value.x; i++)
                    {
                        rowsBetweenGalaxies.Add(i);
                    }
                }
                else if (galaxy1.Value.x < x)
                {
                    for (int i = galaxy1.Value.x; i < x; i++)
                    {
                        rowsBetweenGalaxies.Add(i);
                    }
                }

                if (galaxy1.Value.y > y)
                {
                    for (int i = y; i < galaxy1.Value.y; i++)
                    {
                        colsBetweenGalaxies.Add(i);
                    }
                }
                else if (galaxy1.Value.y < y)
                {
                    for (int i = galaxy1.Value.y; i < y; i++)
                    {
                        colsBetweenGalaxies.Add(i);
                    }
                }

                double emptyRowsBetweenGalaxies = multiFactor * rowsBetweenGalaxies.Count(emptyRows.Contains);
                double emptyColsBetweenGalaxies = multiFactor * colsBetweenGalaxies.Count(emptyCols.Contains);

                distancesForGalaxies += Math.Abs(galaxy1.Value.x - x) + emptyRowsBetweenGalaxies + Math.Abs(galaxy1.Value.y - y) + emptyColsBetweenGalaxies;
            }

            distancesTotal += distancesForGalaxies;
        }

        // Furtherst distance is half the number of pipes
        Console.WriteLine($"Day 10 Part 1 answer is: {distancesTotal}");
    }
}
