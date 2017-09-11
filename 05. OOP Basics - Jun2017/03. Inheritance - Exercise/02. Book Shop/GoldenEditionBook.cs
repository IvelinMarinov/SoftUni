    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string title, string author, decimal price) : base(title, author, price)
        {
            this.Price = price;
        }

        public override decimal Price
        {
            get { return base.Price * (decimal)1.3; }
        }
    }