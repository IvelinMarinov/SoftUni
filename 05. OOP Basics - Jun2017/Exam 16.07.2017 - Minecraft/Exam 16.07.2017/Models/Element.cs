public abstract class Element
{
    private string id;

    protected Element(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get { return this.id; }
        protected set { this.id = value; }
    }

    public abstract string Print();
}
