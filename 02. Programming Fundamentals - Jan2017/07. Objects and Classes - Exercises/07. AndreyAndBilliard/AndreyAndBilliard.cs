using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AndreyAndBilliard
{
    public class AndreyAndBilliard
    {
        public static void Main()
        {
            var itemsInMenu = int.Parse(Console.ReadLine());

            var Menu = new Dictionary<string, double>();

            for (int i = 0; i < itemsInMenu; i++)
            {
                var currItem = Console.ReadLine().Split('-');
                Menu[currItem[0]] = double.Parse(currItem[1]);
            }

            var currCustomerString = Console.ReadLine();

            var customerList = new Dictionary<string, Customer>();

            while (currCustomerString != "end of clients")
            {
                var currCustomerArr = currCustomerString.Split(new char[] { '-', ',' });
                var currCustName = currCustomerArr[0];
                var currCustItem = currCustomerArr[1];
                var currCustQuantity = int.Parse(currCustomerArr[2]);


                if (Menu.ContainsKey(currCustItem))
                {
                    var currCustomer = new Customer()
                    {
                        Name = currCustName,
                        Order = new Dictionary<string, int>(),
                    };

                    currCustomer.Order.Add(currCustItem, currCustQuantity);
                    currCustomer.Bill = currCustQuantity * Menu[currCustItem];

                    foreach (var student in customerList.Values)
                    {
                        if (student.Name == currCustName && !student.Order.ContainsKey(currCustItem))
                        {
                            student.Order.Add(currCustItem, currCustQuantity);
                            student.Bill += currCustomer.Bill;
                        }

                        else if (student.Name == currCustName && student.Order.ContainsKey(currCustItem))
                        {
                            student.Order[currCustItem] += currCustQuantity;
                            student.Bill += currCustomer.Bill;
                        }
                    }

                    if (!customerList.ContainsKey(currCustName))
                    {
                        customerList.Add(currCustName, currCustomer);
                    }
                }

                currCustomerString = Console.ReadLine();
            }

            var totalBill = 0.0;

            foreach (var customer in customerList.OrderBy(x => x.Value.Name))
            {
                Console.WriteLine(customer.Value.Name);

                foreach (var kvp in customer.Value.Order)
                {
                    Console.WriteLine($"-- {kvp.Key} - {kvp.Value}");
                }

                Console.WriteLine($"Bill: {customer.Value.Bill:f2}");

                totalBill += customer.Value.Bill;
            }

            Console.WriteLine($"Total bill: {totalBill:f2}");
        }
    }
}
