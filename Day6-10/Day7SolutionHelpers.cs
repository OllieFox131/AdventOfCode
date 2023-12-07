namespace ConsoleApp;

internal static class Day7SolutionHelpers
{
    public static Dictionary<char, int> CountCharacters(string input)
    {
        Dictionary<char, int> characterCounts = [];

        foreach (char c in input)
        {
            characterCounts[c] = characterCounts.TryGetValue(c, out int value) ? ++value : 1;
        }

        return characterCounts;
    }
}