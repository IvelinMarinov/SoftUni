using System.Collections.Generic;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;

    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
    {
        if (type.ToLower() == "performance")
        {

           this.cars.Add(id, new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)); 
        }
        else
        {
            this.cars.Add(id, new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
        }
        
    }

    public string Check(int id)
    {
        return cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        if (type.ToLower() == "casual")
        {
            this.races.Add(id, new CasualRace(length, route, prizePool));
        }
        else if (type.ToLower() == "drag")
        {
            this.races.Add(id, new DragRace(length, route, prizePool));
        }
        else
        {
            this.races.Add(id, new DriftRace(length, route, prizePool));
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (this.garage.ParkedCars.ContainsKey(carId))
        {
            return;
        }

        var car = cars[carId];
        this.races[raceId].Participants.Add(carId, car);
    }

    public string Start(int id)
    {
        var result = races[id].Start();
        return result;
    }

    public void Park(int id)
    {
        foreach (var race in this.races.Values)
        {
            if (race.Participants.ContainsKey(id))
            {
                return;
            }
        }

        var car = cars[id];
        this.garage.ParkedCars.Add(id, car);
    }

    public void Unpark(int id)
    {
        var car = cars[id];
        this.garage.ParkedCars.Remove(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        foreach (var id in garage.ParkedCars.Keys)
        {
            cars[id].Tune(tuneIndex, addOn);
        }
    }
}