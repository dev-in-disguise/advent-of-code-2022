namespace Day05;

internal sealed class PartTwo
{
    internal static void Run()
    {
        string input = InputProvider.GetInput();
        var inputInstructions = InputInstructions.Parse(input);

        foreach (MoveInstruction moveInstruction in inputInstructions.MoveInstructions)
        {
            var fromStack = inputInstructions.Stacks[moveInstruction.From - 1];
            var cratesToMove = fromStack.GetRange(fromStack.Count - (moveInstruction.Amount), moveInstruction.Amount);
            fromStack.RemoveRange(fromStack.Count - (moveInstruction.Amount), moveInstruction.Amount);
            inputInstructions.Stacks[moveInstruction.To - 1].AddRange(cratesToMove);
        }

        foreach (var stack in inputInstructions.Stacks)
        {
            Console.Write(stack.Last());
        }

        Console.WriteLine();
    }
}