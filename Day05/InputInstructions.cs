namespace Day05;

internal sealed class InputInstructions
{
    private InputInstructions(List<List<char>> stacks, List<MoveInstruction> moveInstructions)
    {
        Stacks = stacks;
        MoveInstructions = moveInstructions;
    }

    public List<List<char>> Stacks { get; }
    public List<MoveInstruction> MoveInstructions { get; }

    internal static InputInstructions Parse(string input)
    {
        bool stackMode = true;
        List<List<char>> stacks = new();
        List<MoveInstruction> moveInstructions = new();

        foreach (string line in input.Split(Environment.NewLine))
        {
            if (stackMode)
            {
                stackMode = ParseStack(line, stacks);
            }
            else
            {
                moveInstructions.Add(MoveInstruction.Parse(line));
            }
        }

        return new InputInstructions(stacks.Select(s => { s.Reverse(); return s; }).ToList(), moveInstructions);
    }

    private static bool ParseStack(string line, List<List<char>> stacks)
    {
        if (string.IsNullOrWhiteSpace(line)) return false;
        if (!line.Contains('[')) return true;

        int stackNumber = 0;

        for (int i = 0; i < line.Length; i += 4)
        {
            if (stacks.Count == stackNumber) stacks.Add(new List<char>());

            string crate = line.Substring(i + 1, 1);

            if (!string.IsNullOrWhiteSpace(crate))
            {
                stacks[stackNumber].Add(char.Parse(crate));
            }

            stackNumber++;
        }

        return true;
    }
}

internal sealed class MoveInstruction
{
    private MoveInstruction(int amount, int from, int to)
    {
        Amount = amount;
        From = from;
        To = to;
    }

    public int Amount { get; }
    public int From { get; }
    public int To { get; }

    internal static MoveInstruction Parse(string line)
    {
        string amountString = string.Empty;
        int lastPartEnd = 0;

        for (int i = "move ".Length; i < line.Length; i++)
        {
            char c = line[i];

            if (char.IsDigit(c))
            {
                amountString += c;
            }
            else
            {
                lastPartEnd = i + " from ".Length;
                break;
            }
        }

        int amount = int.Parse(amountString);

        string fromString = string.Empty;

        for (int i = lastPartEnd; i < line.Length; i++)
        {
            char c = line[i];

            if (char.IsDigit(c))
            {
                fromString += c;
            }
            else
            {
                lastPartEnd = i + " to ".Length;
                break;
            }
        }

        int from = int.Parse(fromString);

        string toString = string.Empty;

        for (int i = lastPartEnd; i < line.Length; i++)
        {
            char c = line[i];

            if (char.IsDigit(c))
            {
                toString += c;
            }
            else
            {
                break;
            }
        }

        int to = int.Parse(toString);

        return new MoveInstruction(amount, from, to);
    }
}