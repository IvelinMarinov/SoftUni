using System.Collections.Generic;
using System.Linq;

public class Family
{
    public List<Person> listOfPeople;

    public Family()
    {
        this.listOfPeople = new List<Person>();
    }

    public void AddMember(Person member)
    {
        listOfPeople.Add(member);
    }

    public Person GetOldestMember()
    {
        return listOfPeople.OrderByDescending(p => p.age).FirstOrDefault();
    }
}