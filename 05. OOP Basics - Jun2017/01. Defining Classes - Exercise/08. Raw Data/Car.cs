public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private Tyre[] tyres;

    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType,
        double tyreOnePressure, int tyreOneAge, double tyreTwoPressure, int tyreTwoAge,
        double tyreThreePressure, int tyreThreeAge, double tyreFourPressure, int tyreFourAge)
    {
        this.Model = model;
        this.Engine = new Engine(engineSpeed, enginePower);
        this.Cargo = new Cargo(cargoWeight, cargoType);
        this.Tyres = new Tyre[]
        {
            new Tyre(tyreOnePressure, tyreOneAge),
            new Tyre(tyreTwoPressure, tyreTwoAge),
            new Tyre(tyreThreePressure, tyreThreeAge),
            new Tyre(tyreFourPressure, tyreFourAge)
        };
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public Engine Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }

    public Cargo Cargo
    {
        get { return this.cargo; }
        set { this.cargo = value; }
    }

    public Tyre[] Tyres
    {
        get { return this.tyres; }
        set { this.tyres = value; }
    }
}