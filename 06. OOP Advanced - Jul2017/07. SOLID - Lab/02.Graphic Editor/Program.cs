namespace _02.Graphic_Editor
{
    public class Program
    {
        public static void Main()
        {
            IShape circle = new Circle();
            GraphicEditor editor = new GraphicEditor();
            editor.DrawShape(circle);
        }
    }
}
