using System;
using System.Reflection;

namespace _01.Oldest_Family_Member
{
    public class StartUp
    {
        public static void Main()
        {
            var numberOfPeople = int.Parse(Console.ReadLine());
            string input;
            var family = new Family();


            for (int i = 0; i < numberOfPeople; i++)
            {
                input = Console.ReadLine();
                var inputArgs = input.Split();
                var name = inputArgs[0];
                var age = int.Parse(inputArgs[1]);

                var person = new Person(name, age);
                family.AddMember(person);
            }

            var oldestMember = family.GetOldestMember();
            Console.WriteLine($"{oldestMember.name} {oldestMember.age}");

            MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
            MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
            if (oldestMemberMethod == null || addMemberMethod == null)
            {
                throw new Exception();
            }
        }
    }
}
