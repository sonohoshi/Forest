public class Range : IEnumerable, IEnumerator
{
    private readonly int start;
    private readonly int max;
    private int now;

    public Range(int n) : this(0, n) { }

    public Range(int start, int max)
    {
        this.start = start;
        now = start - 1;
        this.max = max;
    }
    
    public IEnumerator GetEnumerator()
    {
        while (MoveNext())
        {
            yield return Current;
        }
    }

    public bool MoveNext()
    {
        return ++now < max;
    }

    public void Reset()
    {
        now = start - 1;
    }

    public object Current => now;
}