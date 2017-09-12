public class AddCollection<T> : Collection<T>,IAddCollection<T>
{
    private IMyList<T> list;

    public int Add(T element)
    {
        this.List.Add(element);
        return this.List.Count - 1;
    }
}
