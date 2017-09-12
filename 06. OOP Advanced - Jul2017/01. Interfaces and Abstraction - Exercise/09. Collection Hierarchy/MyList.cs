public class MyList<T> : Collection<T>, IMyList<T>
{
    public int Add(T element)
    {
        this.List.Insert(0, element);
        return 0;
    }

    public T Remove()
    {
        T element = this.List[0];
        this.List.RemoveAt(0);
        return element;
    }

    public int Used
    {
        get { return this.List.Count; }
    }
}