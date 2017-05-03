using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Andrey_and_billiard
    {
        public class Customer
        {
            public string Name { get; set; }
            public Dictionary<string, decimal> PurchaseList { get; set; }
            public decimal Bill { get { return PurchaseList.Values.Sum(); } }
        }
        class Program
        {
            static void Main(string[] args)
            {

                int entities = int.Parse(Console.ReadLine());
                Dictionary<string, decimal> priceList = new Dictionary<string, decimal>();

                for (int i = 0; i < entities; i++)
                {
                    string[] entityLine = Console.ReadLine().Split('-').ToArray();
                    string item = entityLine[0];
                    decimal itemPrice = decimal.Parse(entityLine[1]);
                    priceList[item] = itemPrice;
                }
                List<Customer> customers = new List<Customer>();
                do
                {
                    string input = Console.ReadLine();

                    if (input == "end of clients")
                    {
                        break;
                    }
                    string[] customerPurchaseLine = input.Split('-').ToArray();
                    string customerName = customerPurchaseLine[0];

                    string product = customerPurchaseLine[1].Split(',')[0];
                    int amounth = int.Parse(customerPurchaseLine[1].Split(',')[1]);
                    Customer currentCustomer = new Customer();
                    if (!priceList.ContainsKey(product))
                    {
                        continue;
                    }

                    currentCustomer.Name = customerName;
                    currentCustomer.PurchaseList = new Dictionary<string, decimal>();
                    currentCustomer.PurchaseList[product] = amounth;
                    bool exists = false;

                    foreach (var custName in customers)
                    {
                        if (custName.Name == currentCustomer.Name)
                        {
                            if (custName.PurchaseList.ContainsKey(product))
                            {
                                exists = true;
                                custName.PurchaseList[product] += amounth;
                            }
                            else
                            {
                                custName.PurchaseList[product] = amounth;
                            }
                        }
                    }

                    if (!exists)
                    {
                        customers.Add(currentCustomer);
                    }

                } while (true);

                decimal totalBill = default(decimal);

                foreach (var customer in customers.OrderBy(name => name.Name))
                {

                    Console.WriteLine($"{customer.Name}");
                    foreach (var item in customer.PurchaseList)
                    {
                        Console.WriteLine($"-- {item.Key} - {item.Value}");
                        Console.WriteLine("Bill: {0:0.00}", priceList[item.Key] * item.Value);

                        totalBill += priceList[item.Key] * item.Value;
                    }

                }
                Console.WriteLine("Total bill: {0:0.00}", totalBill);

            }
        }
    }