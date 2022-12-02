namespace Day01;

internal sealed class Elve
{
    private int _totalCalories;

    public Elve()
    {
        _totalCalories = 0;
    }

    public void AddCalories(int calories)
    {
        _totalCalories = _totalCalories + calories;
    }

    public int GetTotalCalories() => _totalCalories;
}
