using System;
using System.Text;

namespace _09.Collection_Hierarchy
{
    public class StartUp
    {
        public static void Main()
        {
            IAddCollection<string> addCollection = new AddCollection<string>();
            IAddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            IMyList<string> myList = new MyList<string>();
            var addCollectionIndexes = new StringBuilder();
            var addRemoveCOllectionIndexes = new StringBuilder();
            var myListIndexes = new StringBuilder();

            var itemsToAdd = Console.ReadLine().Split();
            var removeOperationsCount = int.Parse(Console.ReadLine());

            foreach (var item in itemsToAdd)
            {
                addCollectionIndexes.Append($"{addCollection.Add(item)} ");
                addRemoveCOllectionIndexes.Append($"{addRemoveCollection.Add(item)} ");
                myListIndexes.Append($"{myList.Add(item)} ");
            }

            var addRemoveCollectionRemoveElements = new StringBuilder();
            var myListRemoveElements = new StringBuilder();

            for (int i = 0; i < removeOperationsCount; i++)
            {
                addRemoveCollectionRemoveElements.Append($"{addRemoveCollection.Remove()} ");
                myListRemoveElements.Append($"{myList.Remove()} ");
            }

            Console.WriteLine(addCollectionIndexes.ToString().Trim());
            Console.WriteLine(addRemoveCOllectionIndexes.ToString().Trim());
            Console.WriteLine(myListIndexes.ToString().Trim());

            Console.WriteLine(addRemoveCollectionRemoveElements.ToString().Trim());
            Console.WriteLine(myListRemoveElements.ToString().Trim());
        }
    }
}
