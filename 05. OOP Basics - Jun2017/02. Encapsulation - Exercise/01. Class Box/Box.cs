public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

    public double Length
    {
        get { return this.length; }
        set { value = this.length; }
    }

    public double Width
    {
        get { return this.width; }
        set { value = this.width; }
    }

    public double Height
    {
        get { return this.height; }
        set { value = this.height; }
    }

    public double SurfaceArea()
    {
        return 2 * ((this.height * this.length) + (this.width * this.height) + (this.length * this.width));
    }

    public double LateralSurfaceArea()
    {
        return 2 * ((this.height * this.length) + (this.width * this.height));
    }

    public double Volume()
    {
        return length * height * width;
    }
}