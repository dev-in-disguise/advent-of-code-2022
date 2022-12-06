namespace Day06;

internal class MaxSizeQueue<T> : Queue<T>
{
    private readonly int maxCapacity;
    
    public MaxSizeQueue(int maxCapacity)
    {
        this.maxCapacity = maxCapacity;
    }

    public new void Enqueue(T item)
    {
        if(this.Count == maxCapacity)
        {
            base.Dequeue();
        }

        base.Enqueue(item);
    }
}