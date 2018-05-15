using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.DataProcessor.Dto.Export
{
    public class CategoryExportDto
    {
        public string CategoryName { get; set; }

        public string ItemName { get; set; }

        public decimal ItemTotalMade { get; set; }

        public int ItemTimesSold { get; set; }

    }
}
