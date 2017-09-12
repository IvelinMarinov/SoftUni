using System;
using System.Linq;
using System.Reflection;

namespace _01.Harvesting_Fields
{
    public class HarvestingFieldsTests
    {
        public static void Main()
        {
            Type classType = typeof(HarvestingFields);
            FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            
            string command = Console.ReadLine();

            while (command != "HARVEST")
            {
                FieldInfo[] gatherdFields;

                switch (command)
                {
                    case "private":
                        gatherdFields = fields.Where(f => f.IsPrivate).ToArray();
                        break;
                    case "protected":
                        gatherdFields = fields.Where(f => f.IsFamily).ToArray();
                        break;
                    case "public":
                        gatherdFields = fields.Where(f => f.IsPublic).ToArray();
                        break;
                    case "all":
                        gatherdFields = fields;
                        break;
                    default:
                        gatherdFields = null;
                        break;
                }

                string[] result = gatherdFields
                    .Select(f => $"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}")
                    .ToArray();

                Console.WriteLine(string.Join(Environment.NewLine, result).Replace("family", "protected"));

                command = Console.ReadLine();
            }
        }
    }
}
