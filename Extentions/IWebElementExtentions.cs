using OpenQA.Selenium;
using System;

namespace TK_Challenge
{
    public static class IWebElementExtensions
    {
        public static void WaitForDisplayed(this IWebElement element)
        {
            // 30 ms = 3 seconds
            var maxLoops = 30;

            for (int i = 0; i < maxLoops; i++)
            {
                try
                {
                    if (element.Displayed)
                    {
                        return;
                    }
                }
                catch
                {
                    System.Threading.Thread.Sleep(100);
                }
            }

            throw new Exception("Element Never Displayed");
        }
    }
}