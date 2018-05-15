using System;
using System.Collections.Generic;

namespace ProductsShop.Models
{
    public class Category
    {
        private string name;
        
        public int Id { get; set; }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length < 3 || value.Length > 15)
                {
                    throw new ArgumentException("Invalid category name!");
                }
                this.name = value;
            }
        }

        public ICollection<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();
    }
}
