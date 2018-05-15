using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            var employeeDtos = JsonConvert.DeserializeObject<List<EmployeeImportDto>>(jsonString);
            var employeesToAdd = new List<Employee>();
            var sb = new StringBuilder();

            foreach (var employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var position = employeesToAdd
                    .Select(e => e.Position)
                    .FirstOrDefault(p => p.Name == employeeDto.Position);

                if (position == null)
                {
                    position = new Position
                    {
                        Name = employeeDto.Position
                    };
                }

                var employee = new Employee
                {
                    Name = employeeDto.Name,
                    Age = employeeDto.Age,
                    Position = position
                };

                employeesToAdd.Add(employee);
                sb.AppendLine(string.Format(SuccessMessage, employee.Name));
            }

            context.Employees.AddRange(employeesToAdd);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var itemDtos = JsonConvert.DeserializeObject<List<ItemImportDto>>(jsonString);
            var itemsToAdd = new List<Item>();
            var sb = new StringBuilder();

            foreach (var itemDto in itemDtos)
            {
                if (!IsValid(itemDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (itemsToAdd.Any(i => i.Name == itemDto.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var category = itemsToAdd
                    .Select(i => i.Category)
                    .FirstOrDefault(c => c.Name == itemDto.Category);

                if (category == null)
                {
                    category = new Category()
                    {
                        Name = itemDto.Category
                    };
                }

                var item = new Item
                {
                    Name = itemDto.Name,
                    Price = itemDto.Price,
                    Category = category
                };
                itemsToAdd.Add(item);
                sb.AppendLine(string.Format(SuccessMessage, item.Name));
            }

            context.Items.AddRange(itemsToAdd);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            //var serializer = new XmlSerializer(typeof(List<OrderImportDto>), new XmlRootAttribute("Orders"));
            //var ticketDtos = (List<OrderImportDto>)serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));
            var ordersToAdd = new List<Order>();
            var orderItemsToAdd = new List<OrderItem>();
            var sb = new StringBuilder();

            var orderDtos = new List<OrderImportDto>();

            var doc = XDocument.Parse(xmlString);

            foreach (var orderElement in doc.Root.Elements())
            {
                //XML parsing
                var customerName = orderElement.Element("Customer").Value;
                var employeeName = orderElement.Element("Employee").Value;
                var dateTime = DateTime.ParseExact(orderElement.Element("DateTime").Value, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture);
                var type = Enum.Parse<OrderType>(orderElement.Element("Type").Value);
                
                var orderDto = new OrderImportDto
                {
                    CustomerName = customerName,
                    EmployeeName = employeeName,
                    DateTime = dateTime,
                    Type = type,
                    Items = new List<OrderItemImportDto>()
                };

                foreach (var itemElement in orderElement.Element("Items").Elements())
                {
                    orderDto.Items.Add(new OrderItemImportDto
                    {
                        ItemName = itemElement.Element("Name").Value,
                        Quantity = int.Parse(itemElement.Element("Quantity").Value)
                    });
                }

                //Validations
                if (!IsValid(orderDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                //Employee exists
                var employee = context.Employees
                    .FirstOrDefault(e => e.Name == orderDto.EmployeeName);
                if (employee == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                //Items exist
                var items = new List<Item>();
                bool allItemsAreValid = true;

                foreach (var itemDto in orderDto.Items)
                {
                    var item = context.Items
                        .FirstOrDefault(i => i.Name == itemDto.ItemName);

                    if (item == null)
                    {
                        allItemsAreValid = false;
                    }

                    items.Add(item);
                }

                if (!allItemsAreValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }


                //Add valid order
                var order = new Order
                {
                    Customer = orderDto.CustomerName,
                    DateTime = orderDto.DateTime,
                    Type = orderDto.Type,
                    Employee = employee
                };

                ordersToAdd.Add(order);

                foreach (var itemDto in orderDto.Items)
                {
                    var orderItem = new OrderItem
                    {
                        Item = items.FirstOrDefault(i => i.Name == itemDto.ItemName),
                        Order = order,
                        Quantity = itemDto.Quantity
                    };
                    orderItemsToAdd.Add(orderItem);
                }

                sb.AppendLine($"Order for {order.Customer} on {order.DateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} added");
            }

            context.Orders.AddRange(ordersToAdd);
            context.OrderItems.AddRange(orderItemsToAdd);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return isValid;
        }
    }
}