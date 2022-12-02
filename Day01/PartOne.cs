namespace Day01;

internal sealed class PartOne
{
    internal static void Run()
    {
        string input = InputProvider.GetInput();

        Elve mostCalories = new();
        Elve currentElve = new();

        foreach (var line in input.Split(Environment.NewLine))
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                currentElve.AddCalories(int.Parse(line));
            }
            else
            {
                if (currentElve.GetTotalCalories() > mostCalories.GetTotalCalories())
                {
                    mostCalories = currentElve;
                }

                currentElve = new();
            }
        }

        if (currentElve.GetTotalCalories() > mostCalories.GetTotalCalories())
        {
            mostCalories = currentElve;
        }

        Console.WriteLine(mostCalories.GetTotalCalories());
    }

}