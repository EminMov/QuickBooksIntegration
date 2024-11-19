using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksIntegration.Models
{
    public class QueryResult
    {
        public string TxnID { get; set; }
        public string Date { get; set; }
        public decimal Amount { get; set; }
        public string Memo { get; set; }
    }
}