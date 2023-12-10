namespace ConsoleApp;

public static class Day5Solution
{
    public static void PartOne()
    {
        List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day5Task.txt").ToList();
        //List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day5Demo.txt").ToList();

        List<string> seeds = [.. data[0].Split(": ")[1].Split(" ")];

        List<string> seedSoils = data.GetRange(data.IndexOf("seed-to-soil map:") + 1,
            data.IndexOf("soil-to-fertilizer map:") - data.IndexOf("seed-to-soil map:") - 2);

        List<string> soilFerts = data.GetRange(data.IndexOf("soil-to-fertilizer map:") + 1,
            data.IndexOf("fertilizer-to-water map:") - data.IndexOf("soil-to-fertilizer map:") - 2);

        List<string> fertWatrs = data.GetRange(data.IndexOf("fertilizer-to-water map:") + 1,
            data.IndexOf("water-to-light map:") - data.IndexOf("fertilizer-to-water map:") - 2);

        List<string> watrLghts = data.GetRange(data.IndexOf("water-to-light map:") + 1,
            data.IndexOf("light-to-temperature map:") - data.IndexOf("water-to-light map:") - 2);

        List<string> lghtTemps = data.GetRange(data.IndexOf("light-to-temperature map:") + 1,
            data.IndexOf("temperature-to-humidity map:") - data.IndexOf("light-to-temperature map:") - 2);

        List<string> tempHumds = data.GetRange(data.IndexOf("temperature-to-humidity map:") + 1,
            data.IndexOf("humidity-to-location map:") - data.IndexOf("temperature-to-humidity map:") - 2);

        List<string> humdLocts = data.GetRange(data.IndexOf("humidity-to-location map:") + 1,
            data.Count - data.IndexOf("humidity-to-location map:") - 1);

        List<long> finalLocts = [];

        foreach (string seed in seeds)
        {
            long seedlong = long.Parse(seed);

            long destinationRange = 0;
            long sourceRange = 0;
            long rangeLength = 0;

            // Set the soil to be the seed value
            long soil = seedlong;

            // Check the seed doesn't pass through any of the maps
            // If does calculate, and set the value of the soil, and break out of the loop, we have found the map!
            foreach (string seedSoil in seedSoils)
            {
                destinationRange = long.Parse(seedSoil.Split(" ")[0]);
                sourceRange = long.Parse(seedSoil.Split(" ")[1]);
                rangeLength = long.Parse(seedSoil.Split(" ")[2]);

                if (seedlong >= sourceRange && seedlong <= sourceRange + rangeLength)
                {
                    soil = seedlong - sourceRange + destinationRange;
                    break;
                }
            }

            // Set the fert to be the soil value
            long fert = soil;

            // Check the soil doesn't pass through any of the maps
            // If does calculate, and set the value of the fert, and break out of the loop, we have found the map!
            foreach (string soilFert in soilFerts)
            {
                destinationRange = long.Parse(soilFert.Split(" ")[0]);
                sourceRange = long.Parse(soilFert.Split(" ")[1]);
                rangeLength = long.Parse(soilFert.Split(" ")[2]);

                if (soil >= sourceRange && soil <= sourceRange + rangeLength)
                {
                    fert = soil - sourceRange + destinationRange;
                    break;
                }
            }

            // Set the watr to be the fert value
            long watr = fert;

            // Check the fert doesn't pass through any of the maps
            // If does calculate, and set the value of the watr, and break out of the loop, we have found the map!
            foreach (string fertWatr in fertWatrs)
            {
                destinationRange = long.Parse(fertWatr.Split(" ")[0]);
                sourceRange = long.Parse(fertWatr.Split(" ")[1]);
                rangeLength = long.Parse(fertWatr.Split(" ")[2]);

                if (fert >= sourceRange && fert <= sourceRange + rangeLength)
                {
                    watr = fert - sourceRange + destinationRange;
                    break;
                }
            }

            // Set the lght to be the watr value
            long lght = watr;

            // Check the watr doesn't pass through any of the maps
            // If does calculate, and set the value of the lght, and break out of the loop, we have found the map!
            foreach (string watrLght in watrLghts)
            {
                destinationRange = long.Parse(watrLght.Split(" ")[0]);
                sourceRange = long.Parse(watrLght.Split(" ")[1]);
                rangeLength = long.Parse(watrLght.Split(" ")[2]);

                if (watr >= sourceRange && watr <= sourceRange + rangeLength)
                {
                    lght = watr - sourceRange + destinationRange;
                    break;
                }
            }

            // Set the temp to be the lght value
            long temp = lght;

            // Check the lght doesn't pass through any of the maps
            // If does calculate, and set the value of the temp, and break out of the loop, we have found the map!
            foreach (string lghtTemp in lghtTemps)
            {
                destinationRange = long.Parse(lghtTemp.Split(" ")[0]);
                sourceRange = long.Parse(lghtTemp.Split(" ")[1]);
                rangeLength = long.Parse(lghtTemp.Split(" ")[2]);

                if (lght >= sourceRange && lght <= sourceRange + rangeLength)
                {
                    temp = lght - sourceRange + destinationRange;
                    break;
                }
            }

            // Set the humd to be the temp value
            long humd = temp;

            // Check the temp doesn't pass through any of the maps
            // If does calculate, and set the value of the humd, and break out of the loop, we have found the map!
            foreach (string tempHumd in tempHumds)
            {
                destinationRange = long.Parse(tempHumd.Split(" ")[0]);
                sourceRange = long.Parse(tempHumd.Split(" ")[1]);
                rangeLength = long.Parse(tempHumd.Split(" ")[2]);

                if (temp >= sourceRange && temp <= sourceRange + rangeLength)
                {
                    humd = temp - sourceRange + destinationRange;
                    break;
                }
            }

            // Set the loct to be the humd value
            long loct = humd;

            // Check the humd doesn't pass through any of the maps
            // If does calculate, and set the value of the loct, and break out of the loop, we have found the map!
            foreach (string humdLoct in humdLocts)
            {
                destinationRange = long.Parse(humdLoct.Split(" ")[0]);
                sourceRange = long.Parse(humdLoct.Split(" ")[1]);
                rangeLength = long.Parse(humdLoct.Split(" ")[2]);

                if (humd >= sourceRange && humd <= sourceRange + rangeLength)
                {
                    loct = humd - sourceRange + destinationRange;
                    break;
                }
            }

            // Add the loct to the final loct list
            finalLocts.Add(loct);
        }

        Console.WriteLine($"Day 5 Part 1 answer is: {finalLocts.Min()}");
    }

    public static void PartTwo()
    {
        //List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day5Task.txt").ToList();
        List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day5Demo.txt").ToList();

        List<string> seeds = [.. data[0].Split(": ")[1].Split(" ")];

        List<string> seedSoils = data.GetRange(data.IndexOf("seed-to-soil map:") + 1,
            data.IndexOf("soil-to-fertilizer map:") - data.IndexOf("seed-to-soil map:") - 2);

        List<string> soilFerts = data.GetRange(data.IndexOf("soil-to-fertilizer map:") + 1,
            data.IndexOf("fertilizer-to-water map:") - data.IndexOf("soil-to-fertilizer map:") - 2);

        List<string> fertWatrs = data.GetRange(data.IndexOf("fertilizer-to-water map:") + 1,
            data.IndexOf("water-to-light map:") - data.IndexOf("fertilizer-to-water map:") - 2);

        List<string> watrLghts = data.GetRange(data.IndexOf("water-to-light map:") + 1,
            data.IndexOf("light-to-temperature map:") - data.IndexOf("water-to-light map:") - 2);

        List<string> lghtTemps = data.GetRange(data.IndexOf("light-to-temperature map:") + 1,
            data.IndexOf("temperature-to-humidity map:") - data.IndexOf("light-to-temperature map:") - 2);

        List<string> tempHumds = data.GetRange(data.IndexOf("temperature-to-humidity map:") + 1,
            data.IndexOf("humidity-to-location map:") - data.IndexOf("temperature-to-humidity map:") - 2);

        List<string> humdLocts = data.GetRange(data.IndexOf("humidity-to-location map:") + 1,
            data.Count - data.IndexOf("humidity-to-location map:") - 1);

        long loct = 0;
        long destinationRange = 0;
        long sourceRange = 0;
        long rangeLength = 0;
        bool finished = false;

        while (!finished)
        {
            // Set the humd to be the loct value
            long humd = loct;

            // Check the loct doesn't pass through any of the maps
            // If does calculate, and set the value of the humd, and break out of the loop, we have found the map!
            foreach (string humdLoct in humdLocts)
            {
                destinationRange = long.Parse(humdLoct.Split(" ")[0]);
                sourceRange = long.Parse(humdLoct.Split(" ")[1]);
                rangeLength = long.Parse(humdLoct.Split(" ")[2]);

                if (loct >= destinationRange && loct <= destinationRange + rangeLength - 1)
                {
                    humd = loct - (destinationRange - sourceRange);
                    break;
                }
            }

            // Set the temp to be the humd value
            long temp = humd;

            // Check the humd doesn't pass through any of the maps
            // If does calculate, and set the value of the temp, and break out of the loop, we have found the map!
            foreach (string tempHumd in tempHumds)
            {
                destinationRange = long.Parse(tempHumd.Split(" ")[0]);
                sourceRange = long.Parse(tempHumd.Split(" ")[1]);
                rangeLength = long.Parse(tempHumd.Split(" ")[2]);

                if (humd >= destinationRange && humd <= destinationRange + rangeLength - 1)
                {
                    temp = humd - (destinationRange - sourceRange);
                    break;
                }
            }

            // Set the lght to be the temp value
            long lght = temp;

            // Check the temp doesn't pass through any of the maps
            // If does calculate, and set the value of the lght, and break out of the loop, we have found the map!
            foreach (string lghtTemp in lghtTemps)
            {
                destinationRange = long.Parse(lghtTemp.Split(" ")[0]);
                sourceRange = long.Parse(lghtTemp.Split(" ")[1]);
                rangeLength = long.Parse(lghtTemp.Split(" ")[2]);

                if (temp >= destinationRange && temp <= destinationRange + rangeLength - 1)
                {
                    lght = temp - (destinationRange - sourceRange);
                    break;
                }
            }

            // Set the watr to be the lght value
            long watr = lght;

            // Check the lght doesn't pass through any of the maps
            // If does calculate, and set the value of the watr, and break out of the loop, we have found the map!
            foreach (string watrLght in watrLghts)
            {
                destinationRange = long.Parse(watrLght.Split(" ")[0]);
                sourceRange = long.Parse(watrLght.Split(" ")[1]);
                rangeLength = long.Parse(watrLght.Split(" ")[2]);

                if (lght >= destinationRange && lght <= destinationRange + rangeLength - 1)
                {
                    watr = lght - (destinationRange - sourceRange);
                    break;
                }
            }

            // Set the fert to be the watr value
            long fert = watr;

            // Check the watr doesn't pass through any of the maps
            // If does calculate, and set the value of the fert, and break out of the loop, we have found the map!
            foreach (string fertWatr in fertWatrs)
            {
                destinationRange = long.Parse(fertWatr.Split(" ")[0]);
                sourceRange = long.Parse(fertWatr.Split(" ")[1]);
                rangeLength = long.Parse(fertWatr.Split(" ")[2]);

                if (watr >= destinationRange && watr <= destinationRange + rangeLength - 1)
                {
                    fert = watr - (destinationRange - sourceRange);
                    break;
                }
            }

            // Set the soil to be the fert value
            long soil = fert;

            // Check the fert doesn't pass through any of the maps
            // If does calculate, and set the value of the soil, and break out of the loop, we have found the map!
            foreach (string soilFert in soilFerts)
            {
                destinationRange = long.Parse(soilFert.Split(" ")[0]);
                sourceRange = long.Parse(soilFert.Split(" ")[1]);
                rangeLength = long.Parse(soilFert.Split(" ")[2]);

                if (fert >= destinationRange && fert <= destinationRange + rangeLength - 1)
                {
                    soil = fert - (destinationRange - sourceRange);
                    break;
                }
            }

            // Set the seed to be the soil value
            long seed = soil;

            // Check the soil doesn't pass through any of the maps
            // If does calculate, and set the value of the seed, and break out of the loop, we have found the map!
            foreach (string seedSoil in seedSoils)
            {
                destinationRange = long.Parse(seedSoil.Split(" ")[0]);
                sourceRange = long.Parse(seedSoil.Split(" ")[1]);
                rangeLength = long.Parse(seedSoil.Split(" ")[2]);

                if (soil >= destinationRange && soil <= destinationRange + rangeLength - 1)
                {
                    seed = soil - (destinationRange - sourceRange);
                    break;
                }
            }

            // For each seed range
            for (int i = 0; i < seeds.Count; i += 2)
            {
                // If seed is in seed range, we have found the smallest seed!
                if (seed >= long.Parse(seeds[i]) && seed <= long.Parse(seeds[i]) + long.Parse(seeds[i + 1]))
                {
                    finished = true;
                }
            }

            // If we arent finished, check next location
            if (!finished)
            {
                loct++;
            }
        }

        Console.WriteLine($"Day 5 Part 2 answer is: {loct}");
    }
}
