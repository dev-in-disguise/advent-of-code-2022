namespace Day06;

internal sealed class PartTwo
{
    internal static void Run()
    {
        string input = InputProvider.GetInput();
        MaxSizeQueue<char> startMarker = new(14);

        for (int i = 0; i < input.Length; i++)
        {
            startMarker.Enqueue(input[i]);

            if (IsStartOfMessageMarker(startMarker))
            {
                Console.WriteLine(i + 1);
                break;
            }
        }
    }

    private static bool IsStartOfMessageMarker(MaxSizeQueue<char> startMarker)
    {
        if (startMarker.Count != 14) return false;

        var distinct = startMarker.AsEnumerable().Distinct();
        return distinct.Count() == startMarker.Count;
    }
}