namespace ConsoleApp;

internal static class Day10SolutionHelpers
{
    public static (char pipeType, int i, int j) NextPipeToStart(char[,] charArray, int i, int j)
    {
        // If its not a letter, digit or . then its a symbol return true
        if (i - 1 >= 0 && (charArray[i - 1, j] == '|' || charArray[i - 1, j] == '7' || charArray[i - 1, j] == 'F'))
        {
            return (charArray[i - 1, j], i - 1, j);
        }

        // If you can check below
        if (i + 1 <= charArray.GetLength(0) - 1 && (charArray[i - 1, j] == '|' || charArray[i - 1, j] == 'L' || charArray[i - 1, j] == 'J'))
        {
            return (charArray[i + 1, j], i + 1, j);
        }

        // If you can check to left and its not a letter, digit or . then its a symbol return true
        if (j - 1 >= 0 && (charArray[i - 1, j] == '-' || charArray[i - 1, j] == 'F' || charArray[i - 1, j] == 'L'))
        {
            return (charArray[i, j - 1], i, j - 1);
        }

        return (charArray[i, j + 1], i, j + 1);
    }

    public static (char pipeType, int i, int j) NextPipe(char[,] charArray, (char pipeType, int i, int j) pipe, (char pipeType, int i, int j) lastPipe)
    {
        if (pipe.pipeType == '|')
        {
            if (lastPipe.i == pipe.i - 1)
            {
                return (charArray[pipe.i + 1, pipe.j], pipe.i + 1, pipe.j);
            }
            else
            {
                return (charArray[pipe.i - 1, pipe.j], pipe.i - 1, pipe.j);
            }
        }

        if (pipe.pipeType == '-')
        {
            if (lastPipe.j == pipe.j - 1)
            {
                return (charArray[pipe.i, pipe.j + 1], pipe.i, pipe.j + 1);
            }
            else
            {
                return (charArray[pipe.i, pipe.j - 1], pipe.i, pipe.j - 1);
            }
        }

        if (pipe.pipeType == 'L')
        {
            if (lastPipe.i == pipe.i - 1)
            {
                return (charArray[pipe.i, pipe.j + 1], pipe.i, pipe.j + 1);
            }
            else
            {
                return (charArray[pipe.i - 1, pipe.j], pipe.i - 1, pipe.j);
            }
        }

        if (pipe.pipeType == 'J')
        {
            if (lastPipe.i == pipe.i - 1)
            {
                return (charArray[pipe.i, pipe.j - 1], pipe.i, pipe.j - 1);
            }
            else
            {
                return (charArray[pipe.i - 1, pipe.j], pipe.i - 1, pipe.j);
            }
        }

        if (pipe.pipeType == 'F')
        {
            if (lastPipe.i == pipe.i + 1)
            {
                return (charArray[pipe.i, pipe.j + 1], pipe.i, pipe.j + 1);
            }
            else
            {
                return (charArray[pipe.i + 1, pipe.j], pipe.i + 1, pipe.j);
            }
        }

        if (pipe.pipeType == '7')
        {
            if (lastPipe.i == pipe.i + 1)
            {
                return (charArray[pipe.i, pipe.j - 1], pipe.i, pipe.j - 1);
            }
            else
            {
                return (charArray[pipe.i + 1, pipe.j], pipe.i + 1, pipe.j);
            }
        }

        return ('?', 1, 1);
    }
}