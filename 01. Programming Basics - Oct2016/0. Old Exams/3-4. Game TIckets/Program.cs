using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_4.Game_TIckets
{
    class Program
    {
        static void Main(string[] args)
        {
            var totalGrossBudget = double.Parse(Console.ReadLine());
            var category = Console.ReadLine();
            var num = int.Parse(Console.ReadLine());
            var budget = totalGrossBudget / num;

            var VIPTicket = 499.99;
            var normalTicket = 249.99;
            var totalBudget = 0.00;
            var totalCost = 0.00;           

            if (num >= 1 && num <= 4)
            {
                budget *= 0.25;
                totalBudget = budget * num;
                if (category == "VIP")
                {
                    totalCost = num * VIPTicket;
                    if (totalBudget >= totalCost)
                    {
                        Console.WriteLine("Yes! You have {0:0.00} leva left.", Math.Abs(totalBudget - totalCost));
                    }
                    else
                    {
                        Console.WriteLine("Not enough money! You need {0:0.00} leva.", Math.Abs(totalBudget - totalCost));
                    }
                }
                else if (category == "Normal")
                {
                    totalCost = num * normalTicket;
                    if (totalBudget >= totalCost)
                    {
                        Console.WriteLine("Yes! You have {0:0.00} leva left.", Math.Abs(totalBudget - totalCost));
                    }
                    else
                    {
                        Console.WriteLine("Not enough money! You need {0:0.00} leva.", Math.Abs(totalBudget - totalCost));
                    }
                }
            }
            else if (num >= 5 && num <= 9)
            {
                {
                    budget *= 0.4;
                    totalBudget = budget * num;
                    if (category == "VIP")
                    {
                        totalCost = num * VIPTicket;
                        if (totalBudget >= totalCost)
                        {
                            Console.WriteLine("Yes! You have {0:0.00} leva left.", Math.Abs(totalBudget - totalCost));
                        }
                        else
                        {
                            Console.WriteLine("Not enough money! You need {0:0.00} leva.", Math.Abs(totalBudget - totalCost));
                        }
                    }
                    else if (category == "Normal")
                    {
                        totalCost = num * normalTicket;
                        if (totalBudget >= totalCost)
                        {
                            Console.WriteLine("Yes! You have {0:0.00} leva left.", Math.Abs(totalBudget - totalCost));
                        }
                        else
                        {
                            Console.WriteLine("Not enough money! You need {0:0.00} leva.", Math.Abs(totalBudget - totalCost));
                        }
                    }
                }
            }
            else if (num >= 10 && num <= 24)
            {
                {
                    budget *= 0.5;
                    totalBudget = budget * num;
                    if (category == "VIP")
                    {
                        totalCost = num * VIPTicket;
                        if (totalBudget >= totalCost)
                        {
                            Console.WriteLine("Yes! You have {0:0.00} leva left.", Math.Abs(totalBudget - totalCost));
                        }
                        else
                        {
                            Console.WriteLine("Not enough money! You need {0:0.00} leva.", Math.Abs(totalBudget - totalCost));
                        }
                    }
                    else if (category == "Normal")
                    {
                        totalCost = num * normalTicket;
                        if (totalBudget >= totalCost)
                        {
                            Console.WriteLine("Yes! You have {0:0.00} leva left.", Math.Abs(totalBudget - totalCost));
                        }
                        else
                        {
                            Console.WriteLine("Not enough money! You need {0:0.00} leva.", Math.Abs(totalBudget - totalCost));
                        }
                    }
                }
            }
            else if (num >= 25 && num <= 49)
            {
                {
                    budget *= 0.6;
                    totalBudget = budget * num;
                    if (category == "VIP")
                    {
                        totalCost = num * VIPTicket;
                        if (totalBudget >= totalCost)
                        {
                            Console.WriteLine("Yes! You have {0:0.00} leva left.", Math.Abs(totalBudget - totalCost));
                        }
                        else
                        {
                            Console.WriteLine("Not enough money! You need {0:0.00} leva.", Math.Abs(totalBudget - totalCost));
                        }
                    }
                    else if (category == "Normal")
                    {
                        totalCost = num * normalTicket;
                        if (totalBudget >= totalCost)
                        {
                            Console.WriteLine("Yes! You have {0:0.00} leva left.", Math.Abs(totalBudget - totalCost));
                        }
                        else
                        {
                            Console.WriteLine("Not enough money! You need {0:0.00} leva.", Math.Abs(totalBudget - totalCost));
                        }
                    }
                }
            }
            else
            {
                {
                    budget *= 0.75;
                    totalBudget = budget * num;
                    if (category == "VIP")
                    {
                        totalCost = num * VIPTicket;
                        if (totalBudget >= totalCost)
                        {
                            Console.WriteLine("Yes! You have {0:0.00} leva left.", Math.Abs(totalBudget - totalCost));
                        }
                        else
                        {
                            Console.WriteLine("Not enough money! You need {0:0.00} leva.", Math.Abs(totalBudget - totalCost));
                        }
                    }
                    else if (category == "Normal")
                    {
                        totalCost = num * normalTicket;
                        if (totalBudget >= totalCost)
                        {
                            Console.WriteLine("Yes! You have {0:0.00} leva left.", Math.Abs(totalBudget - totalCost));
                        }
                        else
                        {
                            Console.WriteLine("Not enough money! You need {0:0.00} leva.", Math.Abs(totalBudget - totalCost));
                        }
                    }
                }
            }
        }
    }
}
