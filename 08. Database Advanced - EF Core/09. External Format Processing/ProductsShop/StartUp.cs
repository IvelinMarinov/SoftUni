using System;
using ProductsShop.App;
using ProductShop.Data;

namespace ProductsShop
{
    class StartUp
    {
        static void Main()
        {
            using (var db = new ProductShopDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            Console.WriteLine("Database initialized");

            AutoMapperConfiguration.InitializeMapper();
            
            ImportData();
            ExportData();
        }

        private static void ImportData()
        {
            var jsonReader = new JsonReader();
            jsonReader.Read();
            var xmlReader = new XmlReader();
            xmlReader.Import();
        }

        private static void ExportData()
        {
            var jsonWriter = new JsonWriter();
            jsonWriter.Write();
            var xmlWriter = new XmlWriter();
            xmlWriter.Write();
        }
    }
}
