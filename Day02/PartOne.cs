namespace Day02;

internal sealed class PartOne
{
    internal static void Run()
    {
        string input = InputProvider.GetInput();
        int totalScore = 0;

        foreach (string game in input.Split(Environment.NewLine))
        {
            var draws = game.Split(' ').Select(s => new Draw(char.Parse(s))).ToArray();
            DrawType opponentDraw = draws[0];
            DrawType myDraw = draws[1];

            ResultType result = CalculateResult(opponentDraw, myDraw);
            Score score = new(myDraw, result);

            totalScore += score.Calculate();
        }

        Console.WriteLine(totalScore);
    }

    private static ResultType CalculateResult(DrawType opponentDraw, DrawType myDraw)
    {
        return (myDraw, opponentDraw) switch
        {
            (DrawType.Paper, DrawType.Paper) => ResultType.Draw,
            (DrawType.Paper, DrawType.Rock) => ResultType.Win,
            (DrawType.Paper, DrawType.Scissor) => ResultType.Loss,
            (DrawType.Rock, DrawType.Paper) => ResultType.Loss,
            (DrawType.Rock, DrawType.Rock) => ResultType.Draw,
            (DrawType.Rock, DrawType.Scissor) => ResultType.Win,
            (DrawType.Scissor, DrawType.Paper) => ResultType.Win,
            (DrawType.Scissor, DrawType.Rock) => ResultType.Loss,
            (DrawType.Scissor, DrawType.Scissor) => ResultType.Draw,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

file record Draw(char draw)
{
    public static implicit operator DrawType(Draw draw)
    {
        return draw.draw switch
        {
            'A' => DrawType.Rock,
            'X' => DrawType.Rock,
            'B' => DrawType.Paper,
            'Y' => DrawType.Paper,
            'C' => DrawType.Scissor,
            'Z' => DrawType.Scissor,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
