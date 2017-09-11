public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private Point topLeftCorner;

    public Rectangle(string id, double width, double height, double x, double y)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.TopLeftCorner = new Point(x, y);
    }

    public string Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    public double Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    public double Height
    {
        get { return this.height; }
        set { this.height = value; }
    }

    public Point TopLeftCorner
    {
        get { return this.topLeftCorner; }
        set { this.topLeftCorner = value; }
    }

    public bool InteresectsWith(Rectangle rectangle)
    {
        if (this.topLeftCorner.X <= rectangle.topLeftCorner.X + rectangle.width && 
            this.topLeftCorner.X + this.width >= rectangle.topLeftCorner.X && 
            this.topLeftCorner.Y <= rectangle.topLeftCorner.Y + rectangle.height && 
            this.topLeftCorner.Y + this.height >= rectangle.topLeftCorner.Y)
        {
            return true;
        }

        return false;
    }
}