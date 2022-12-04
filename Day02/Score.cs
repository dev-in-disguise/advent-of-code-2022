internal sealed class Score
{
    private readonly DrawType _drawType;
    private readonly ResultType _resultType;

    public Score(DrawType drawType, ResultType resultType)
    {
        _drawType = drawType;
        _resultType = resultType;
    }

    public int Calculate() => ((int)_drawType) + ((int)_resultType);
}
