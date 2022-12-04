namespace Day02;

internal sealed class PartTwo
{
    internal static void Run()
    {
        string input = InputProvider.GetInput();
        int totalScore = 0;

        foreach (string predictionInput in input.Split(Environment.NewLine))
        {
            var gamePrediction = new GamePrediction(predictionInput).Parse();
            
            DrawType myDraw = CalculateMyDraw(gamePrediction.DrawResult, gamePrediction.OpponentDraw);
            Score score = new(myDraw, gamePrediction.DrawResult);

            totalScore += score.Calculate();
        }

        Console.WriteLine(totalScore);
    }

    private static DrawType CalculateMyDraw(ResultType drawResult, DrawType opponentDraw)
    {
        return (drawResult, opponentDraw) switch
        {
            (ResultType.Loss, DrawType.Scissor) => DrawType.Paper,
            (ResultType.Loss, DrawType.Rock) => DrawType.Scissor,
            (ResultType.Loss, DrawType.Paper) => DrawType.Rock,
            (ResultType.Draw, DrawType.Scissor) => DrawType.Scissor,
            (ResultType.Draw, DrawType.Rock) => DrawType.Rock,
            (ResultType.Draw, DrawType.Paper) => DrawType.Paper,
            (ResultType.Win, DrawType.Scissor) => DrawType.Rock,
            (ResultType.Win, DrawType.Rock) => DrawType.Paper,
            (ResultType.Win, DrawType.Paper) => DrawType.Scissor,
            _ => throw new ArgumentException()
        };
    }
}

file sealed class GamePrediction
{
    private readonly string _predictionInput;

    public GamePrediction(string predictionInput)
    {
        _predictionInput = predictionInput;
    }

    public DrawType OpponentDraw { get; private set; }
    public ResultType DrawResult { get; private set; }

    internal GamePrediction Parse()
    {
        string[] predictionInputs = _predictionInput.Split(' ');
        OpponentDraw = new Draw(char.Parse(predictionInputs[0]));
        DrawResult = new DrawResult(char.Parse(predictionInputs[1]));
        return this;
    }
}

file record Draw(char draw)
{
    public static implicit operator DrawType(Draw draw)
    {
        return draw.draw switch
        {
            'A' => DrawType.Rock,
            'B' => DrawType.Paper,
            'C' => DrawType.Scissor,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

file record DrawResult(char result)
{
    public static implicit operator ResultType(DrawResult drawResult)
    {
        return drawResult.result switch
        {
            'X' => ResultType.Loss,
            'Y' => ResultType.Draw,
            'Z' => ResultType.Win,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}