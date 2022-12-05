namespace Day03;

internal sealed class PartOne
{
    internal static void Run()
    {
        string[] rucksacks = InputProvider.GetInput().Split(Environment.NewLine);
        int totalPriority = 0;

        foreach(string rucksack in rucksacks)
        {
            int halfSize = rucksack.Length / 2;
            string compartmentOne = rucksack.Substring(0, halfSize);
            string compartmentTwo = rucksack.Substring(halfSize);
            var result = compartmentOne.Intersect(compartmentTwo);

            foreach(char item in result)
            {
                int itemPriority = char.IsUpper(item) ? (item - 38) : (item - 96);

                totalPriority += itemPriority;
            }
        }

        Console.WriteLine(totalPriority);
    }
}