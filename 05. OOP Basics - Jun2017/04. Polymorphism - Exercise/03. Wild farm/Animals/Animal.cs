public abstract class Animal
{
    private string animalName;
    private string animalType;
    private double animalWeight;
    private int foodEaten;

    public Animal(string animalName, string animalType, double animalWeight)
    {
        this.AnimalName = animalName;
        this.AnimalType = animalType;
        this.AnimalWeight = animalWeight;
    }

    public int FoodEaten
    {
        get { return this.foodEaten; }
        set { this.foodEaten = value; }
    }

    public double AnimalWeight
    {
        get { return this.animalWeight; }
        set { this.animalWeight = value; }
    }

    public string AnimalType
    {
        get { return this.animalType; }
        set { this.animalType = value; }
    }

    public string AnimalName
    {
        get { return this.animalName; }
        set { this.animalName = value; }
    }

    public abstract void MakeSound();

    public abstract void Eat(Food food);
}