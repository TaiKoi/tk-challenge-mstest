using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using TK_Challenge;
using TK_Challenge.Pages;

namespace TKTest
{
    [TestClass]
    public class TKChallengeTests
    {
        public static IWebDriver chromeDriver, firefoxDriver, edgeDriver;

        [ClassInitialize]
        public static void ClassInitialize(TestContext test)
        {
            var options = new ChromeOptions();
            options.AddArguments("headed"); // Change argument to "headless" to run without the browser
            chromeDriver = new ChromeDriver(options);
            //firefoxDriver = new FirefoxDriver();
            //edgeDriver = new EdgeDriver();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            chromeDriver.Close();
            //firefoxDriver.Close();
            //edgeDriver.Close();
        }

        [TestMethod]
        public void AddEmployee()
        {
            chromeDriver.Url = URLConstants.LoginURL;
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Login();
            chromeDriver.GetElement(BenefitsDashboardPage.AddEmployeeButton).Click();
            chromeDriver.GetElement(BenefitsDashboardPage.AddEmployeeModal).WaitForDisplayed();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("addEmployeeModal")).Displayed);
        }

        [TestMethod]
        public void Login()
        {
            chromeDriver.Url = URLConstants.LoginURL;
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Login();
            Assert.AreEqual(URLConstants.DashboardURL, chromeDriver.Url);
        }


    }
}