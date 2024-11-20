using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksIntegration.Models
{
    public class CompanyInfo
    {
        public string CompanyName { get; set; }
        public string LegalName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string EIN { get; set; }
    }
}