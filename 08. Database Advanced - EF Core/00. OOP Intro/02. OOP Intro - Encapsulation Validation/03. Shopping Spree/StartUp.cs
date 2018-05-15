using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Shopping_Spree
{
    public class StartUp
    {
        public static void Main()
        {
            var persons = new List<Person>();
            var products = new List<Product>();

            var personsInput = Console.ReadLine().Split(new[] { ';', '=' });
            var productsInput = Console.ReadLine().Split(new[] { ';', '=' });

            try
            {
                for (int i = 0; i < personsInput.Length - 1; i += 2)
                {
                    var personName = personsInput[i];
                    var personMoney = decimal.Parse(personsInput[i + 1]);
                    var person = new Person(personName, personMoney);
                    persons.Add(person);
                }

                for (int i = 0; i < productsInput.Length - 1; i += 2)
                {
                    var productName = productsInput[i];
                    var productCost = decimal.Parse(productsInput[i + 1]);
                    var product = new Product(productName, productCost);
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var purchaseInput = Console.ReadLine();

            while (purchaseInput != "END")
            {
                var purchaseArgs = purchaseInput.Split();
                var personName = purchaseArgs[0];
                var productName = purchaseArgs[1];

                if (persons.Any(p => p.Name == personName) && products.Any(pr => pr.Name == productName))
                {
                    var person = persons
                        .FirstOrDefault(pers => pers.Name == personName);
                    var product = products
                        .FirstOrDefault(prod => prod.Name == productName);

                    if (person != null && product != null)
                    {
                        try
                        {
                            person.AddProduct(product);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                purchaseInput = Console.ReadLine();
            }

            foreach (var person in persons)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}