using System.Diagnostics;

namespace Day08;

internal sealed class PartTwo
{
    internal static void Run()
    {
        string[] inputLines = InputProvider.GetInput().Split(Environment.NewLine);

        int highestScenicScore = 0;

        for (int line = 0; line < inputLines.Length; line++)
        {
            for (int column = 0; column < inputLines[line].Length; column++)
            {
                int? scenicScore;
                if ((scenicScore = GetScenicScore(line, column, inputLines)) > highestScenicScore)
                {
                    Debug.Assert(scenicScore is not null);
                    highestScenicScore = scenicScore.Value;
                }
            }
        }

        Console.WriteLine(highestScenicScore);
    }

    private static int GetScenicScore(int lineIndex, int columnIndex, string[] inputLines)
    {
        int treeHeight = int.Parse(inputLines[lineIndex][columnIndex].ToString());

        // check left
        int scoreLeft = 0;
        for (int leftIndex = columnIndex - 1; leftIndex >= 0; leftIndex--)
        {
            scoreLeft++;
            int leftTreeHeight = int.Parse(inputLines[lineIndex][leftIndex].ToString());
            if (leftTreeHeight >= treeHeight) break;
        }


        // check right
        int scoreRight = 0;
        for (int rightIndex = columnIndex + 1; rightIndex < inputLines[lineIndex].Length; rightIndex++)
        {
            scoreRight++;
            int rightTreeHeight = int.Parse(inputLines[lineIndex][rightIndex].ToString());
            if (rightTreeHeight >= treeHeight) break;
        }

        // check top
        int scoreTop = 0;
        for (int topIndex = lineIndex - 1; topIndex >= 0; topIndex--)
        {
            scoreTop++;
            int topTreeHeight = int.Parse(inputLines[topIndex][columnIndex].ToString());
            if (topTreeHeight >= treeHeight) break;
        }

        // check bottom
        int scoreBottom = 0;
        for (int bottomIndex = lineIndex + 1; bottomIndex < inputLines.Length; bottomIndex++)
        {
            scoreBottom++;
            int bottomTreeHeight = int.Parse(inputLines[bottomIndex][columnIndex].ToString());
            if (bottomTreeHeight >= treeHeight) break;
        }

        return scoreBottom * scoreTop * scoreLeft * scoreRight;
    }
}