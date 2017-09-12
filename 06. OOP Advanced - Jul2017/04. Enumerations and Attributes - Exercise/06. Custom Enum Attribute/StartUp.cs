using System;

namespace _06.Custom_Enum_Attribute
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            object[] attrInfo = new object[1];

            switch (input.ToLower())
            {
                case "rank":
                    attrInfo = typeof(CardRanks).GetCustomAttributes(false);
                    break;
                case "suit":
                    attrInfo = typeof(CardSuits).GetCustomAttributes(false);
                    break;
            }

            
            foreach (var x in attrInfo)
            {
                Console.WriteLine(x.ToString());
            }
        }
    }
}
