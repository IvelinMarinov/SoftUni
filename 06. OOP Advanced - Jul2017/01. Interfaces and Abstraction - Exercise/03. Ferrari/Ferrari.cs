public class Ferrari : ICar
{
    private const string ferrariModel = "488-Spider";

        private string driverName;
        private string model;

    public Ferrari(string driverName)
    {
        this.driverName = driverName;
        this.model = ferrariModel;
    }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public string DriverName
        {
            get { return this.driverName; }
            set { this.driverName = value; }
        }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string GasPedal()
        {
            return "Zadu6avam sA!";
        }

    public override string ToString()
    {
        return $"{this.Model}/{this.Brakes()}/{this.GasPedal()}/{this.DriverName}";
    }
}