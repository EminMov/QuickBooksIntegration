using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QBFC16Lib;
using System.IO;
using System.Xml;
using QuickBooksIntegration.Models;

namespace QuickBooksIntegration.Services
{
    public class QuickBooksService
    {
        private readonly QBSessionManager _sessionManager;
        private readonly QuickBooksParser _parser;

        public QuickBooksService()
        {
            _parser = new QuickBooksParser();
            _sessionManager = new QBSessionManager();
        }

        public void OpenConnection()
        {
            _sessionManager.OpenConnection("", "QuickBooksIntegrationApp");
            _sessionManager.BeginSession("", ENOpenMode.omDontCare);
        }

        public void CloseConnection()
        {
            _sessionManager.EndSession();
            _sessionManager.CloseConnection();
        }

        public List<QueryResult> ExecuteBillQuery()
        {
            try
            {
                OpenConnection();

                var requestSet = _sessionManager.CreateMsgSetRequest("US", 13, 0);
                var billQuery = requestSet.AppendBillQueryRq();

                var responseSet = _sessionManager.DoRequests(requestSet);
                string responseXml = responseSet.ToXMLString();

                return _parser.Parse(responseXml, "Bill");  
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка выполнения запроса: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<QueryResult> ExecuteCheckQuery()
        {
            try
            {
                OpenConnection();

                var requestSet = _sessionManager.CreateMsgSetRequest("US", 13, 0);
                var checkQuery = requestSet.AppendCheckQueryRq();

                var responseSet = _sessionManager.DoRequests(requestSet);
                string responseXml = responseSet.ToXMLString();

                return _parser.Parse(responseXml, "Bill");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка выполнения запроса: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
        }
        public List<QueryResult> ExecuteInvoiceQuery()
        {
            try
            {
                OpenConnection();

                var requestSet = _sessionManager.CreateMsgSetRequest("US", 13, 0);
                var invoiceQuery = requestSet.AppendInvoiceQueryRq();

                var responseSet = _sessionManager.DoRequests(requestSet);
                string responseXml = responseSet.ToXMLString();

                return _parser.Parse(responseXml, "Invoice");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка выполнения InvoiceQuery: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
        }
        public List<QueryResult> ExecuteCompanyQuery()
        {
            try
            {
                OpenConnection();

                var requestSet = _sessionManager.CreateMsgSetRequest("US", 13, 0);
                var invoiceQuery = requestSet.AppendCompanyQueryRq();

                var responseSet = _sessionManager.DoRequests(requestSet);
                string responseXml = responseSet.ToXMLString();

                return _parser.Parse(responseXml, "Company");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка выполнения InvoiceQuery: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
        }
        public List<QueryResult> ExecuteItemSalesQuery()
        {
            try
            {
                OpenConnection();

                var requestSet = _sessionManager.CreateMsgSetRequest("US", 13, 0);
                var invoiceQuery = requestSet.AppendItemQueryRq();

                var responseSet = _sessionManager.DoRequests(requestSet);
                string responseXml = responseSet.ToXMLString();

                return _parser.Parse(responseXml, "ItemSales");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка выполнения InvoiceQuery: {ex.Message}");
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}