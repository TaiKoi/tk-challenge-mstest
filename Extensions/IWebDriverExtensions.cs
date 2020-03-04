using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TK_Challenge.Pages
{
    public static class IWebDriverExtensions
    {
        public static void Wait(int delay = 100)
        {
            System.Threading.Thread.Sleep(delay);
        }

        public static IWebElement GetElement(this IWebDriver driver, string cssSelector)
        {
            // 30 ms = 3 seconds
            var maxLoops = 30;

            for (int i = 0; i < maxLoops; i++)
            {
                try
                {
                    return driver.FindElement(By.CssSelector(cssSelector));
                }
                catch
                {
                    System.Threading.Thread.Sleep(100);
                }
            }

            throw new Exception("Element Not Found");
        }

        public static IWebElement[] GetTableHeaderElements(this IWebDriver driver, string tableName)
        {
            IWebElement tableElement = driver.FindElement(By.Id(tableName));
            IWebElement tableHeader = tableElement.FindElement(By.Id("tableHead"));
            IList<IWebElement> tableHeaderColumns = tableHeader.FindElements(By.TagName("th"));

            IWebElement[] headerColumns = tableHeaderColumns.ToArray();

            return headerColumns;
        }

        public static IWebElement[] GetTableRows(this IWebDriver driver, string tableName)
        {
            IWebElement tableElement = driver.FindElement(By.Id(tableName));
            IWebElement tableBody = tableElement.FindElement(By.Id("tableBody"));
            IList<IWebElement> tableRows = tableBody.FindElements(By.TagName("tr"));
            IList<IWebElement> rowTD;
            foreach (IWebElement row in tableRows)
            {
                rowTD = row.FindElements(By.TagName("td"));
            }
            IWebElement[] rowData = tableRows.ToArray();

            return rowData;
        }

        /*public static IWebElement[] GetTableRowContent(this IWebDriver driver, string tableName)
        {
            IWebElement tableElement = driver.FindElement(By.Id(tableName));
            IWebElement tableBody = tableElement.FindElement(By.Id("tableBody"));
            IList<IWebElement> tableRows = tableBody.FindElements(By.TagName("tr"));
            IList<IWebElement> rowColumns = tableRows.First<IWebElement>;
            //IWebElement[] rowDatas = new IWebElement[0];
            foreach (IWebElement row in tableRows)
            {
                rowTD = row.FindElements(By.TagName("td"));
                *//*foreach (IWebElement column in rowTD)
                {
                    rowColumn = column.FindElements
                }*//*
  
            }
            IWebElement[] rowData = tableRows.ToArray();

            return rowData;
        }*/
    }
}