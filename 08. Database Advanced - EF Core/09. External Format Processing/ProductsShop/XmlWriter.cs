using System;
using System.Linq;
using System.Xml.Linq;
using ProductsShop.Service;

namespace ProductsShop.App
{
    public class XmlWriter
    {
        private ExportService service;

        public XmlWriter()
        {
            this.service = new ExportService();
        }

        public void Write()
        {
            GetProductsInRange();
            GetUsersWithSoldProducts();
            GetCategoriesByProductsCount();
            GetUsersWithProductsSoldCount();
            Console.WriteLine("XML data exported successfully");
        }

        private void GetProductsInRange()
        {
            var priceFrom = 1000m;
            var priceTo = 2000m;

            var productDtos = this.service.GetProductsWithBuyerInfoInRange(priceFrom, priceTo);

            var doc = new XDocument();
            var root = new XElement("products");
            doc.Add(root);

            foreach (var product in productDtos)
            {
                var element = new XElement("product");
                element.SetAttributeValue("name", product.Name);
                element.SetAttributeValue("price", product.Price);
                element.SetAttributeValue("buyer", product.BuyerName);
                doc.Element("products").Add(element);
            }

            doc.Save("Output/products-in-range.xml");

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ProductWithBuyerFullName>));

            //using (StringWriter textWriter = new StringWriter())
            //{
            //    xmlSerializer.Serialize(textWriter, productDtos);
            //    return textWriter.ToString();
            //}
        }

        private void GetUsersWithSoldProducts()
        {
            var userDtos = this.service.GetUsersWithSoldProducts();

            var doc = new XDocument();
            var root = new XElement("users");
            doc.Add(root);

            foreach (var user in userDtos)
            {
                var userEl = new XElement("user");
                userEl.SetAttributeValue("first-name", user.FirstName);
                userEl.SetAttributeValue("last-name", user.LastName);
                userEl.Add(new XElement("sold-products"));

                foreach (var product in user.ProductsSold)
                {
                    var productEl = new XElement("product");
                    productEl.Add(new XElement("name", product.Name));
                    productEl.Add(new XElement("price", product.Price));
                    userEl.Element("sold-products").Add(productEl);
                }

                doc.Element("users").Add(userEl);
            }

            doc.Save("Output/users-sold-products.xml");
        }

        private void GetCategoriesByProductsCount()
        {
            var categoryDtos = this.service.GetCategoriesByProduct();

            var doc = new XDocument();
            var root = new XElement("categories");
            doc.Add(root);

            foreach (var category in categoryDtos.OrderByDescending(c => c.ProductsCount))
            {
                var categoryEl = new XElement("category");
                categoryEl.SetAttributeValue("name", category.Name);
                categoryEl.Add(new XElement("products-count", category.ProductsCount));
                categoryEl.Add(new XElement("average-price", category.AveragePrice));
                categoryEl.Add(new XElement("total-revenue", category.TotalRevenue));
                doc.Root.Add(categoryEl);
            }

            doc.Save("Output/categories-by-products.xml");
        }

        private void GetUsersWithProductsSoldCount()
        {
            var users = this.service.GetUsersWithSoldProductsCount();

            var doc = new XDocument();
            var root = new XElement("users");
            root.SetAttributeValue("count", users.Count);
            doc.Add(root);

            foreach (var user in users)
            {
                var userEl = new XElement("user");
                userEl.SetAttributeValue("first-name", user.FirstName);
                userEl.SetAttributeValue("last-name", user.LastName);
                userEl.SetAttributeValue("age", user.Age);
                userEl.Add(new XElement("sold-products"));
                userEl.Element("sold-products").SetAttributeValue("count", user.ProductsSold.Count);

                foreach (var product in user.ProductsSold)
                {
                    var productEl = new XElement("product");
                    productEl.SetAttributeValue("name", product.Name);
                    productEl.SetAttributeValue("price", product.Price);
                    userEl.Element("sold-products").Add(productEl);
                }
                
                doc.Root.Add(userEl);
            }

            doc.Save("Output/users-and-products.xml");
        }
    }
}
