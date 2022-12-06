namespace Day03;

internal sealed class PartTwo
{
    internal static void Run()
    {
        string[] rucksacks = InputProvider.GetInput().Split(Environment.NewLine);
        int totalPriority = 0;

        for (int i = 0; i < rucksacks.Length; i += 3)
        {
            var result = rucksacks[i].Intersect(rucksacks[i + 1]).Intersect(rucksacks[i + 2]);

            foreach (char item in result)
            {
                int itemPriority = char.IsUpper(item) ? (item - 38) : (item - 96);

                totalPriority += itemPriority;
            }
        }

        Console.WriteLine(totalPriority);
    }
}