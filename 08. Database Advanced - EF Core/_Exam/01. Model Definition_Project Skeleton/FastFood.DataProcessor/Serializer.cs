using System;
using System.Linq;
using System.Xml.Linq;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Export;
using FastFood.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            var orderTypeEnum = Enum.Parse<OrderType>(orderType);

            var orders = context.Orders
                .Where(o => o.Employee.Name == employeeName && o.Type == orderTypeEnum)
                .Select(o => new OrderExportDto
                {
                    CustomerName = o.Customer,
                    Items = o.OrderItems.Select(oi => new ItemExportDto
                    {
                        Name = oi.Item.Name,
                        Price = oi.Item.Price,
                        Quantity = oi.Quantity
                    }).ToList(),
                    TotalPrice = o.TotalPrice
                })
                .OrderByDescending(o => o.TotalPrice)
                .ThenByDescending(o => o.Items.Count)
                .ToList();

            var resultObj = new ParentOrderExportDto
            {
                EmployeeName = employeeName,
                Orders = orders,
                TotalMade = orders.Sum(o => o.TotalPrice)
            };

            var result = JsonConvert.SerializeObject(resultObj, Formatting.Indented);
            return result;
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            var categoryNames = categoriesString
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var x = context.Categories
                .Include(c => c.Items)
                .ThenInclude(i => i.OrderItems)
                .Where(c => categoryNames.Contains(c.Name))
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Items = c.Items.Select(i => new
                    {
                        Name = i.Name,
                        Price = i.Price,
                        TimesSold = i.OrderItems.Select(oi => oi.Quantity).Sum()
                    }).ToList()

                })
                .ToList();

            var categories = x.Select(c => new CategoryExportDto
            {
                CategoryName = c.CategoryName,
                ItemName = c.Items
                    .OrderByDescending(i => i.TimesSold)
                    .FirstOrDefault()
                    .Name,
                ItemTimesSold = c.Items
                    .OrderByDescending(i => i.TimesSold)
                    .FirstOrDefault()
                    .TimesSold,
                ItemTotalMade = c.Items
                    .OrderByDescending(i => i.TimesSold)
                    .Select(i => i.TimesSold * i.Price)
                    .FirstOrDefault()
            })
            .OrderByDescending(c => c.ItemTotalMade)
            .ThenByDescending(c => c.ItemTimesSold)
            .ToList();

            var doc = new XDocument();
            doc.Add(new XElement("Categories"));

            foreach (var category in categories)
            {
                var categoryEl = new XElement("Category");
                categoryEl.Add(new XElement("Name", category.CategoryName));

                var mostPopularItemElement = new XElement("MostPopularItem");

                mostPopularItemElement.Add(new XElement("Name", category.ItemName));
                mostPopularItemElement.Add(new XElement("TotalMade", category.ItemTotalMade));
                mostPopularItemElement.Add(new XElement("TimesSold", category.ItemTimesSold));

                categoryEl.Add(mostPopularItemElement);

                doc.Root.Add(categoryEl);
            }

            return doc.ToString();
        }
    }
}