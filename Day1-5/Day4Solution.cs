using System.Linq;

namespace ConsoleApp;

public static class Day4Solution
{
    public static void PartOne()
    {
        List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day4Task.txt").ToList();
        //List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day4Demo.txt").ToList();

        List<int> cardPoints = [];

        foreach (string card in data)
        {
            // Get the card data
            string actualCard = card.Split(": ")[1];

            // Get the winning numbers string and our numbers
            string winningNumbersString = actualCard.Split(" | ")[0];
            string ourNumbersString = actualCard.Split(" | ")[1];

            List<string> winningNumbers = [];
            List<string> ourNumbers = [];

            // Get each of the winning numbers add add them to the list
            for (int i = 0; i < winningNumbersString.Length; i += 3)
            {
                winningNumbers.Add(winningNumbersString.Substring(i, 2).Replace(" ", ""));
            }

            // Get each of our numbers and add them to the list
            for (int i = 0; i < ourNumbersString.Length; i += 3)
            {
                ourNumbers.Add(ourNumbersString.Substring(i, 2).Replace(" ", ""));
            }

            int points = 0;
            // If the winning number has our number, either add 1 to start the count or double the count
            foreach (var _ in ourNumbers.Where(winningNumbers.Contains).Select(_ => new { }))
            {
                points = points == 0 ? 1 : points * 2;
            }

            // Add the final count for the card to the counts list
            cardPoints.Add(points);
        }

        Console.WriteLine($"Day 4 Part 1 answer is: {cardPoints.Sum()}");
    }

    public static void PartTwo()
    {
        List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day4Task.txt").ToList();
        //List<string> data = File.ReadLines("C:\\Users\\AT319375\\source\\repos\\ConsoleApp\\Day1-5\\TextFiles\\Day4Demo.txt").ToList();

        Dictionary<int, int> cardNumbers = [];

        // Initialize a card numbers array to keep track of how many of each card we have
        for (int i = 1; i <= data.Count; i++)
        {
            cardNumbers.Add(i, 1);
        }

        foreach (string card in data)
        {
            // Get the card id
            string cardIdString = card.Split(": ")[0];
            string cardOnlyIdString = cardIdString.Replace("Card ", "").Replace(" ", "");
            _ = int.TryParse(cardOnlyIdString, out int cardId);

            string actualCard = card.Split(": ")[1];

            // Get the winning numbers string and our number
            string winningNumbersString = actualCard.Split(" | ")[0];
            string ourNumbersString = actualCard.Split(" | ")[1];

            List<string> winningNumbers = [];
            List<string> ourNumbers = [];

            // Get each of the winning numbers add add them to the list
            for (int i = 0; i < winningNumbersString.Length; i += 3)
            {
                winningNumbers.Add(winningNumbersString.Substring(i, 2).Replace(" ", ""));
            }

            // Get each of our numbers add add them to the list
            for (int i = 0; i < ourNumbersString.Length; i += 3)
            {
                ourNumbers.Add(ourNumbersString.Substring(i, 2).Replace(" ", ""));
            }

            // Count the number of wins for the card
            int wins = ourNumbers.Count(winningNumbers.Contains);

            // For the cards indexed with an id within the current card id + wins
            // Add the number of cards of the current card to the next cards
            for (int i = 1; i <= wins; i++)
            {
                cardNumbers[cardId + i] += cardNumbers[cardId];
            }
        }

        Console.WriteLine($"Day 4 Part 2 answer is: {cardNumbers.Values.Sum()}");
    }
}
