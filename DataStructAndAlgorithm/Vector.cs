public class Vector<T> : IEnumerable
{
    private T[] arr;
    private int maxSize;
    private int nowIndex;

    public int NowLength => nowIndex;
    
    public Vector(int size = 5)
    {
        arr = new T[size];
        maxSize = size;
        nowIndex = 0;
    }
    
    public T this[int i]
    {
        get => arr[i];
        set => arr[i] = value;
    }

    public void PushBack(T item)
    {
        if (nowIndex > maxSize - 1) Doubling();
        
        arr[nowIndex++] = item;
    }

    public void Remove(int index)
    {
        if (index < 0 || index > maxSize - 1)
        {
            throw new ArgumentOutOfRangeException();
        }

        for (int i = index; i < nowIndex - 1; i++)
        {
            arr[i] = arr[i + 1];
        }

        nowIndex--;
    }

    private void Doubling()
    {
        maxSize *= 2;
        var newArr = new T[maxSize];
        
        for (int i = 0; i < nowIndex; i++)
        {
            newArr[i] = arr[i];
        }

        arr = newArr;
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < nowIndex; i++)
        {
            yield return arr[i];
        }
    }
}