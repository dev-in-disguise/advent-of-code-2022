namespace Day06;

internal sealed class PartOne
{
    internal static void Run()
    {
        string input = InputProvider.GetInput();
        MaxSizeQueue<char> startMarker = new(4);

        for (int i = 0; i < input.Length; i++)
        {
            startMarker.Enqueue(input[i]);

            if(IsStartOfPacketMarker(startMarker))
            {
                Console.WriteLine(i + 1);
                break;
            }
        }
    }

    private static bool IsStartOfPacketMarker(MaxSizeQueue<char> startMarker)
    {
        if(startMarker.Count != 4) return false;

        var distinct = startMarker.AsEnumerable().Distinct();
        return distinct.Count() == startMarker.Count;
    }
}