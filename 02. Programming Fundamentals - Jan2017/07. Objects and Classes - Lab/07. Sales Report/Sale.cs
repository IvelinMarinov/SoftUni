namespace _07.Sales_Report
{
    public class Sale
    {
        public string City { get; set; }

        public string Product { get; set; }

        public double Price { get; set; }

        public double Quantity { get; set; }

        public double Revenue => Price * Quantity;
    }
}
