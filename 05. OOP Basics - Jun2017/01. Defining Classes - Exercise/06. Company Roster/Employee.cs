public class Employee
{
    private string name;
    private double salary;
    private string position;
    private string department;
    private string email;
    private int age;

    public Employee()
    {
        this.Name = string.Empty;
        this.Salary = 0;
        this.Position = string.Empty;
        this.Department = string.Empty;
        this.Email = "n/a";
        this.Age = -1;
    }

    public Employee(string name, double salary, string position, string department) : this()
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public double Salary
    {
        get { return this.salary; }
        set { this.salary = value; }
    }

    public string Position
    {
        get { return this.position; }
        set { this.position = value; }
    }

    public string Department
    {
        get { return this.department; }
        set { this.department = value; }
    }

    public string Email
    {
        get { return this.email; }
        set { this.email = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }
}