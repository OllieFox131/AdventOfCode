namespace ConsoleApp;

internal static class Day10SolutionHelpers
{
    public static (char pipeType, int i, int j) NextPipeToStart(char[,] charArray, int i, int j)
    {
        // If you can check above and it is |, 7 or F
        if (i - 1 >= 0 && (charArray[i - 1, j] == '|' || charArray[i - 1, j] == '7' || charArray[i - 1, j] == 'F'))
        {
            return (charArray[i - 1, j], i - 1, j);
        }

        // If you can check below and it is |, L or J
        if (i + 1 <= charArray.GetLength(0) - 1 && (charArray[i - 1, j] == '|' || charArray[i - 1, j] == 'L' || charArray[i - 1, j] == 'J'))
        {
            return (charArray[i + 1, j], i + 1, j);
        }

        // If you can check right and it is -, F or L
        if (j - 1 >= 0 && (charArray[i - 1, j] == '-' || charArray[i - 1, j] == 'F' || charArray[i - 1, j] == 'L'))
        {
            return (charArray[i, j - 1], i, j - 1);
        }

        // Else must be the char on the left
        return (charArray[i, j + 1], i, j + 1);
    }

    public static (char pipeType, int i, int j) NextPipe(char[,] charArray, (char pipeType, int i, int j) pipe, (char pipeType, int i, int j) lastPipe)
    {
        if (pipe.pipeType == '|')
        {
            // If last pipe was above
            return lastPipe.i == pipe.i - 1
                ? ((char pipeType, int i, int j))(charArray[pipe.i + 1, pipe.j], pipe.i + 1, pipe.j)
                : ((char pipeType, int i, int j))(charArray[pipe.i - 1, pipe.j], pipe.i - 1, pipe.j);
        }

        if (pipe.pipeType == '-')
        {
            // If last pipe was right
            return lastPipe.j == pipe.j - 1
                ? ((char pipeType, int i, int j))(charArray[pipe.i, pipe.j + 1], pipe.i, pipe.j + 1)
                : ((char pipeType, int i, int j))(charArray[pipe.i, pipe.j - 1], pipe.i, pipe.j - 1);
        }

        if (pipe.pipeType == 'L')
        {
            // If last pipe was above
            return lastPipe.i == pipe.i - 1
                ? ((char pipeType, int i, int j))(charArray[pipe.i, pipe.j + 1], pipe.i, pipe.j + 1)
                : ((char pipeType, int i, int j))(charArray[pipe.i - 1, pipe.j], pipe.i - 1, pipe.j);
        }

        if (pipe.pipeType == 'J')
        {
            // If last pipe was above
            return lastPipe.i == pipe.i - 1
                ? ((char pipeType, int i, int j))(charArray[pipe.i, pipe.j - 1], pipe.i, pipe.j - 1)
                : ((char pipeType, int i, int j))(charArray[pipe.i - 1, pipe.j], pipe.i - 1, pipe.j);
        }

        if (pipe.pipeType == 'F')
        {
            // If last pipe was right
            return lastPipe.i == pipe.i + 1
                ? ((char pipeType, int i, int j))(charArray[pipe.i, pipe.j + 1], pipe.i, pipe.j + 1)
                : ((char pipeType, int i, int j))(charArray[pipe.i + 1, pipe.j], pipe.i + 1, pipe.j);
        }

        if (pipe.pipeType == '7')
        {
            // If last pipe was right
            return lastPipe.i == pipe.i + 1
                ? ((char pipeType, int i, int j))(charArray[pipe.i, pipe.j - 1], pipe.i, pipe.j - 1)
                : ((char pipeType, int i, int j))(charArray[pipe.i + 1, pipe.j], pipe.i + 1, pipe.j);
        }

        // Else return giberish
        return ('?', 1, 1);
    }
}