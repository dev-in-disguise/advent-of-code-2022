namespace Day05;

internal sealed class PartOne
{
    internal static void Run()
    {
        string input = InputProvider.GetInput();
        var inputInstructions = InputInstructions.Parse(input);

        foreach (MoveInstruction moveInstruction in inputInstructions.MoveInstructions)
        {
            for (int i = 0; i < moveInstruction.Amount; i++)
            {
                var fromStack = inputInstructions.Stacks[moveInstruction.From - 1];
                char crateToMove = fromStack.Last();
                fromStack.RemoveAt(fromStack.Count - 1);
                inputInstructions.Stacks[moveInstruction.To - 1].Add(crateToMove);
            }
        }

        foreach (var stack in inputInstructions.Stacks)
        {
            Console.Write(stack.Last());
        }

        Console.WriteLine();
    }
}