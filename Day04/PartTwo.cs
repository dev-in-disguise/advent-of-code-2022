namespace Day03;

internal sealed class PartTwo
{
    internal static void Run()
    {
        string[] pairings = InputProvider.GetInput().Split(Environment.NewLine);
        int irrelevantElveCount = 0;

        foreach (string pairing in pairings)
        {
            string[] elves = pairing.Split(',');

            IEnumerable<int> elveOneSections = GetSections(elves[0]);
            IEnumerable<int> elveTwoSections = GetSections(elves[1]);

            int intersectCount = elveOneSections.Intersect(elveTwoSections).Count();

            if (intersectCount > 0)
            {
                irrelevantElveCount++;
            }
        }

        Console.WriteLine(irrelevantElveCount);
    }

    private static IEnumerable<int> GetSections(string elveSections)
    {
        string[] fromTo = elveSections.Split('-');
        int from = int.Parse(fromTo[0]);
        int to = int.Parse(fromTo[1]);

        return Enumerable.Range(from, to - from + 1);
    }
}