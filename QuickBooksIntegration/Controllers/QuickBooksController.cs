using QuickBooksIntegration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickBooksIntegration.Controllers
{
    public class QuickBooksController : Controller
    {
        private readonly QuickBooksService _quickBooksService;

        public QuickBooksController()
        {
            _quickBooksService = new QuickBooksService();
        }

        public ActionResult QueryBill()
        {
            try
            {
                var results = _quickBooksService.ExecuteBillQuery();
                return View("QueryResult", results);
            }
            catch (Exception ex)
            {
                return View("Error", (object)ex.Message);
            }
        }
        public ActionResult QueryCheck()
        {
            try
            {
                var results = _quickBooksService.ExecuteCheckQuery();
                return View("QueryResult", results);
            }
            catch (Exception ex)
            {
                return View("Error", (object)ex.Message);
            }
        }
        public ActionResult QueryInvoice()
        {
            try
            {
                var results = _quickBooksService.ExecuteInvoiceQuery();
                return View("QueryResult", results);
            }
            catch (Exception ex)
            {
                return View("Error", (object)ex.Message);
            }
        }
        public ActionResult QueryCompany()
        {
            try
            {
                var results = _quickBooksService.ExecuteCompanyQuery();
                return View("QueryResult", results);
            }
            catch (Exception ex)
            {
                return View("Error", (object)ex.Message);
            }
        }
        public ActionResult QueryItemSales()
        {
            try
            {
                var results = _quickBooksService.ExecuteItemSalesQuery();
                return View("QueryResult", results);
            }
            catch (Exception ex)
            {
                return View("Error", (object)ex.Message);
            }
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}