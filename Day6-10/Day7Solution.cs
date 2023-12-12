namespace ConsoleApp;

public static class Day7Solution
{
    public static void PartOne()
    {
        List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day7Task.txt").ToList();
        //List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day7Demo.txt").ToList();

        Dictionary<string, int> originalHandsAndPoints = [];
        Dictionary<string, int> customHandsAndPoints = [];

        // Create hand ranks for easier to read code
        Dictionary<string, int> handRanks = new()
            {
                { "5 of a kind", 7},
                { "4 of a kind", 6},
                { "Full house", 5},
                { "3 of a kind", 4},
                { "2 pair", 3},
                { "1 pair", 2},
                { "High card", 1}
            };

        Dictionary<string, int> handsAndRanks = [];
        Dictionary<string, int> finalHandsAndRanks = [];

        // Break apart the hands and points and add to dictionary
        foreach (string piece in data)
        {
            string[] pieces = piece.Split(" ");
            _ = int.TryParse(pieces[1], out int points);
            originalHandsAndPoints.Add(pieces[0], points);
        }

        foreach (KeyValuePair<string, int> originalHandAndPoint in originalHandsAndPoints)
        {
            // In order to be able to order the hands alphabetically convert hands to new coding
            string newHand = originalHandAndPoint.Key
                .Replace("A", "M")
                .Replace("K", "L")
                .Replace("2", "A")
                .Replace("3", "B")
                .Replace("4", "C")
                .Replace("5", "D")
                .Replace("6", "E")
                .Replace("7", "F")
                .Replace("8", "G")
                .Replace("9", "H")
                .Replace("T", "I")
                .Replace("J", "J")
                .Replace("Q", "K");

            // Add custom hands to new dictionary
            customHandsAndPoints.Add(newHand, originalHandAndPoint.Value);
        }

        foreach (string hand in customHandsAndPoints.Keys)
        {
            // Produce a dictionary of characters in each hand with a count
            Dictionary<char, int> characterCounts = Day7SolutionHelpers.CountCharacters(hand);

            // If a charcter has a count of 5
            if (characterCounts.ContainsValue(5))
            {
                handsAndRanks.Add(hand, handRanks["5 of a kind"]);
            }
            // If a charcter has a count of 4
            else if (characterCounts.ContainsValue(4))
            {
                handsAndRanks.Add(hand, handRanks["4 of a kind"]);
            }
            // If a charcter has a count of 3 and another character has a count of 2
            else if (characterCounts.ContainsValue(3) && characterCounts.ContainsValue(2))
            {
                handsAndRanks.Add(hand, handRanks["Full house"]);
            }
            // If a charcter has a count of 3
            else if (characterCounts.ContainsValue(3))
            {
                handsAndRanks.Add(hand, handRanks["3 of a kind"]);
            }
            // If 2 charcters have a count of 2
            else if (characterCounts.Values.Count(x => x == 2) == 2)
            {
                handsAndRanks.Add(hand, handRanks["2 pair"]);
            }
            // If a charcter has a count of 2
            else if (characterCounts.ContainsValue(2))
            {
                handsAndRanks.Add(hand, handRanks["1 pair"]);
            }
            else
            {
                handsAndRanks.Add(hand, handRanks["High card"]);
            }
        }

        // Order the hands by the rank value and then by the hand characters
        Dictionary<string, int> orderedHandsAndRanks = handsAndRanks.OrderBy(x => x.Value).ThenBy(x => x.Key).ToDictionary();

        int count = 1;

        // Create a dictionary with the ordered hands and their final ranking
        foreach (KeyValuePair<string, int> hand in orderedHandsAndRanks)
        {
            finalHandsAndRanks.Add(hand.Key, count);
            count++;
        }

        int winnings = 0;

        // Multiply the hand rank by the hand points
        foreach (KeyValuePair<string, int> hand in finalHandsAndRanks)
        {
            winnings += hand.Value * customHandsAndPoints[hand.Key];
        }

        Console.WriteLine($"Day 7 Part 1 answer is: {winnings}");
    }

    public static void PartTwo()
    {
        List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day7Task.txt").ToList();
        //List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day6-10\\TextFiles\\Day7Demo.txt").ToList();

        Dictionary<string, int> originalHandsAndPoints = [];
        Dictionary<string, int> customHandsAndPoints = [];

        // Create hand ranks for easier to read code
        Dictionary<string, int> handRanks = new()
            {
                { "5 of a kind", 7},
                { "4 of a kind", 6},
                { "Full house", 5},
                { "3 of a kind", 4},
                { "2 pair", 3},
                { "1 pair", 2},
                { "High card", 1}
            };

        Dictionary<string, int> handsAndRanks = [];
        Dictionary<string, int> finalHandsAndRanks = [];

        // Break apart the hands and points and add to dictionary
        foreach (string piece in data)
        {
            string[] pieces = piece.Split(" ");
            _ = int.TryParse(pieces[1], out int points);
            originalHandsAndPoints.Add(pieces[0], points);
        }

        foreach (KeyValuePair<string, int> originalHandAndPoint in originalHandsAndPoints)
        {
            // In order to be able to order the hands alphabetically convert hands to new coding
            // This time make J (Joker) the lowest rank
            string newHand = originalHandAndPoint.Key
                .Replace("A", "M")
                .Replace("K", "L")
                .Replace("J", "A")
                .Replace("2", "B")
                .Replace("3", "C")
                .Replace("4", "D")
                .Replace("5", "E")
                .Replace("6", "F")
                .Replace("7", "G")
                .Replace("8", "H")
                .Replace("9", "I")
                .Replace("T", "J")
                .Replace("Q", "K");

            // Add custom hands to new dictionary
            customHandsAndPoints.Add(newHand, originalHandAndPoint.Value);
        }

        foreach (string hand in customHandsAndPoints.Keys)
        {
            // Produce a dictionary of characters in each hand with a count
            Dictionary<char, int> characterCounts = Day7SolutionHelpers.CountCharacters(hand);

            // Remove A (the Joker) from the dictionary so we can analyse hands without the jokers
            _ = characterCounts.Remove('A');

            // If a charcter has a count of 5
            // OR a character has a count of 4 and there are only 4 cards without jokers
            // OR a character has a count of 3 and there are only 3 cards without jokers
            // OR a character has a count of 2 and there are only 2 cards without jokers
            // OR a character has a count of 1 and there are only 1 cards without jokers
            // OR there are no cards (all jokers)
            if (characterCounts.ContainsValue(5)
                || (characterCounts.ContainsValue(4) && characterCounts.Values.Sum() == 4)
                || (characterCounts.ContainsValue(3) && characterCounts.Values.Sum() == 3)
                || (characterCounts.ContainsValue(2) && characterCounts.Values.Sum() == 2)
                || (characterCounts.ContainsValue(1) && characterCounts.Values.Sum() == 1)
                || (characterCounts.Values.Sum() == 0))
            {
                handsAndRanks.Add(hand, handRanks["5 of a kind"]);
            }
            // If a charcter has a count of 4
            // OR a character has a count of 3 and there are only 4 cards without jokers
            // OR a character has a count of 2 and there are only 3 cards without jokers
            // OR a character has a count of 1 and there are only 2 cards without jokers
            else if (characterCounts.ContainsValue(4)
                || (characterCounts.ContainsValue(3) && characterCounts.Values.Sum() == 4)
                || (characterCounts.ContainsValue(2) && characterCounts.Values.Sum() == 3)
                || (characterCounts.ContainsValue(1) && characterCounts.Values.Sum() == 2))
            {
                handsAndRanks.Add(hand, handRanks["4 of a kind"]);
            }
            // If a charcter has a count of 3 and another has a count of 2
            // OR a charcter has a count of 3 and another has a count of 1 and there are only 4 cards without jokers
            // OR a charcter has a count of 3 and there are only 3 cards without jokers
            // OR 2 charcters have a count of 2 and there are only 4 cards without jokers
            // OR a charcter has a count of 2 and there are only 3 cards without jokers
            else if ((characterCounts.ContainsValue(3) && characterCounts.ContainsValue(2))
                || (characterCounts.ContainsValue(3) && characterCounts.ContainsValue(1) && characterCounts.Values.Sum() == 4)
                || (characterCounts.ContainsValue(3) && characterCounts.Values.Sum() == 3)
                || (characterCounts.Values.Count(x => x == 2) == 2 && characterCounts.Values.Sum() == 4)
                || (characterCounts.ContainsValue(2) && characterCounts.ContainsValue(1) && characterCounts.Values.Sum() == 3))
            {
                handsAndRanks.Add(hand, handRanks["Full house"]);
            }
            // If a charcter has a count of 3
            // OR a character has a count of 2 and there are only 4 cards without jokers
            // OR a character has a count of 1 and there are only 3 cards without jokers
            else if (characterCounts.ContainsValue(3)
                || (characterCounts.ContainsValue(2) && characterCounts.Values.Sum() == 4)
                || (characterCounts.ContainsValue(1) && characterCounts.Values.Sum() == 3))
            {
                handsAndRanks.Add(hand, handRanks["3 of a kind"]);
            }
            // If 2 charcters have a count of 2
            // OR a charcter has a count of 2 and another has a count of 1 and there are only 4 cards without jokers
            // OR a charcter has a count of 2 and there are only 3 cards without jokers
            // OR 2 charcters have a count of 1 and there are only 3 cards without jokers
            // OR a charcter has a count of 1 and there are only 2 cards without jokers
            else if (characterCounts.Values.Count(x => x == 2) == 2
                || (characterCounts.ContainsValue(2) && characterCounts.ContainsValue(1) && characterCounts.Values.Sum() == 4)
                || (characterCounts.ContainsValue(2) && characterCounts.Values.Sum() == 3)
                || (characterCounts.Values.Count(x => x == 1) == 2 && characterCounts.Values.Sum() == 3)
                || (characterCounts.ContainsValue(1) && characterCounts.Values.Sum() == 2))
            {
                handsAndRanks.Add(hand, handRanks["2 pair"]);
            }
            // If a charcter has a count of 2
            // OR a character has a count of 1 and there are only 4 cards without jokers
            else if (characterCounts.ContainsValue(2)
                || (characterCounts.ContainsValue(1) && characterCounts.Values.Sum() == 4))
            {
                handsAndRanks.Add(hand, handRanks["1 pair"]);
            }
            else
            {
                handsAndRanks.Add(hand, handRanks["High card"]);
            }
        }

        // Order the hands by the rank value and then by the hand characters
        Dictionary<string, int> orderedHandsAndRanks = handsAndRanks.OrderBy(x => x.Value).ThenBy(x => x.Key).ToDictionary();

        int count = 1;

        // Create a dictionary with the ordered hands and their final ranking
        foreach (KeyValuePair<string, int> hand in orderedHandsAndRanks)
        {
            finalHandsAndRanks.Add(hand.Key, count);
            count++;
        }

        int winnings = 0;

        // Multiply the hand rank by the hand points
        foreach (KeyValuePair<string, int> hand in finalHandsAndRanks)
        {
            winnings += hand.Value * customHandsAndPoints[hand.Key];
        }

        Console.WriteLine($"Day 7 Part 2 answer is: {winnings}");
    }
}
