namespace ConsoleApp;

internal static class Day8SolutionHelpers
{
    public static long FindGCD(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return Math.Abs(a);
    }

    public static long FindLCMOfArray(int[] numbers)
    {
        long lcm = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            lcm = (Math.Abs(lcm) / Day8SolutionHelpers.FindGCD(lcm, numbers[i])) * Math.Abs(numbers[i]);
        }

        return lcm;
    }
}