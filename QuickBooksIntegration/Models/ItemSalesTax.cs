using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksIntegration.Models
{
    public class ItemSalesTax
    {
        public string Name { get; set; }
        public string TaxCode { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }
    }
}