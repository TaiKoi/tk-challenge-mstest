using OpenQA.Selenium;
using System;

namespace TK_Challenge.Pages
{
    public static class IWebDriverExtentions
    {
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
    }
}