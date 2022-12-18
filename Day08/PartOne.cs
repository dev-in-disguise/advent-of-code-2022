namespace Day08;

internal sealed class PartOne
{
    internal static void Run()
    {
        string[] inputLines = InputProvider.GetInput().Split(Environment.NewLine);

        int visibleTrees = 0;

        for (int line = 0; line < inputLines.Length; line++)
        {
            for(int column = 0; column < inputLines[line].Length; column++)
            {
                if(IsVisible(line, column, inputLines))
                {
                    visibleTrees++;
                }
            }
        }

        Console.WriteLine(visibleTrees);
    }

    private static bool IsVisible(int lineIndex, int columnIndex, string[] inputLines)
    {
        int treeHeight = int.Parse(inputLines[lineIndex][columnIndex].ToString());

        // check left
        bool higherTreeExists = false;
        if (columnIndex == 0) return true;
        for(int leftIndex = columnIndex - 1; leftIndex >= 0; leftIndex--)
        {
            if (int.Parse(inputLines[lineIndex][leftIndex].ToString()) >= treeHeight)
            {
                higherTreeExists = true;
                break;
            }
        }

        if (!higherTreeExists) return true;

        // check right
        higherTreeExists = false;
        if (columnIndex == inputLines[lineIndex].Length -1) return true;
        for (int rightIndex = columnIndex + 1; rightIndex < inputLines[lineIndex].Length; rightIndex++)
        {
            if (int.Parse(inputLines[lineIndex][rightIndex].ToString()) >= treeHeight)
            {
                higherTreeExists = true;
                break;
            }
        }

        if (!higherTreeExists) return true;

        // check top
        higherTreeExists = false;
        if (lineIndex == 0) return true;
        for (int topIndex = lineIndex - 1; topIndex >= 0; topIndex--)
        {
            if (int.Parse(inputLines[topIndex][columnIndex].ToString()) >= treeHeight)
            {
                higherTreeExists = true;
                break;
            }
        }

        if (!higherTreeExists) return true;

        // check bottom
        higherTreeExists = false;
        if (lineIndex == 0) return true;
        for (int bottomIndex = lineIndex + 1; bottomIndex < inputLines.Length; bottomIndex++)
        {
            if (int.Parse(inputLines[bottomIndex][columnIndex].ToString()) >= treeHeight)
            {
                higherTreeExists = true;
                break;
            }
        }

        if (!higherTreeExists) return true;
        else return false;
    }
}