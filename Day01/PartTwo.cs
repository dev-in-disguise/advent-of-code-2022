namespace Day01
{
    internal sealed class PartTwo
    {
        internal static void Run()
        {
            string input = InputProvider.GetInput();

            var topThree = new Elve[] { new(), new(), new() };
            Elve currentElve = new();

            foreach (var line in input.Split(Environment.NewLine))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    currentElve.AddCalories(int.Parse(line));
                }
                else
                {
                    topThree = CalculateTopThree(topThree, currentElve);

                    currentElve = new();
                }
            }

            topThree = CalculateTopThree(topThree, currentElve);

            Console.WriteLine(topThree.Sum(elve => elve.GetTotalCalories()));
        }

        private static Elve[] CalculateTopThree(Elve[] topThree, Elve currentElve)
        {
            if (currentElve.GetTotalCalories() > topThree[0].GetTotalCalories())
            {
                topThree[0] = currentElve;
                topThree = topThree.OrderBy(s => s.GetTotalCalories()).ToArray();
            }

            return topThree;
        }
    }
}
