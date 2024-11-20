using QuickBooksIntegration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace QuickBooksIntegration.Services
{
    public class QuickBooksParser
    {
        public List<QueryResult> Parse(string responseXml, string queryType)
        {
            var results = new List<QueryResult>();
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(responseXml);

            XmlNodeList nodes;

            if (queryType == "Bill")
            {
                nodes = xmlDoc.SelectNodes("//BillRet");
            }
            else if (queryType == "Check")
            {
                nodes = xmlDoc.SelectNodes("//CheckRet");
            }
            else if (queryType == "Invoice")
            {
                nodes = xmlDoc.SelectNodes("//InvoiceRet");
            }
            else
            {
                throw new Exception("Неизвестный тип запроса");
            }

            foreach (XmlNode node in nodes)
            {
                var result = new QueryResult
                {
                    TxnID = node.SelectSingleNode("TxnID")?.InnerText,
                    Date = node.SelectSingleNode("TxnDate")?.InnerText,
                    Amount = decimal.Parse(node.SelectSingleNode("Amount")?.InnerText ?? "0"),
                    Memo = node.SelectSingleNode("Memo")?.InnerText
                };

                results.Add(result);
            }

            return results;
        }
        public CompanyInfo ParseCompanyResponse(string responseXml)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(responseXml);

            var companyNode = xmlDoc.SelectSingleNode("//CompanyRet");
            if (companyNode == null)
            {
                throw new Exception("Данные о компании не найдены");
            }

            var companyInfo = new CompanyInfo
            {
                CompanyName = companyNode.SelectSingleNode("CompanyName")?.InnerText,
                LegalName = companyNode.SelectSingleNode("LegalName")?.InnerText,
                Address = companyNode.SelectSingleNode("Address/Addr1")?.InnerText,
                PhoneNumber = companyNode.SelectSingleNode("Phone")?.InnerText,
                Email = companyNode.SelectSingleNode("Email")?.InnerText,
                EIN = companyNode.SelectSingleNode("EIN")?.InnerText,
            };

            return companyInfo;
        }

        public List<ItemSalesTax> ParseItemSalesTaxResponse(string responseXml)
        {
            var itemSalesTaxes = new List<ItemSalesTax>();
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(responseXml);

            var nodes = xmlDoc.SelectNodes("//ItemSalesTaxRet");
            if (nodes == null || nodes.Count == 0)
            {
                throw new Exception("Данные о налогах с продаж не найдены");
            }

            foreach (XmlNode node in nodes)
            {
                var itemSalesTax = new ItemSalesTax()
                {
                    Name = node.SelectSingleNode("Name")?.InnerText,
                    TaxCode = node.SelectSingleNode("ItemSalesTaxRef/FullName")?.InnerText,
                    Rate = decimal.TryParse(node.SelectSingleNode("TaxRate")?.InnerText, out var rate) ? rate : 0,
                    Description = node.SelectSingleNode("ItemDesc")?.InnerText
                };
                itemSalesTaxes.Add(itemSalesTax);
            }
            return itemSalesTaxes;
        }
    }
}