using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using TK_Challenge.Pages;

namespace TK_Challenge
{
    [TestClass]
    public class DashboardTests
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
            chromeDriver.Manage().Window.Maximize();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            chromeDriver.Close();
            //firefoxDriver.Close();
            //edgeDriver.Close();
        }

        [TestMethod]
        public void VerifyModalOpensWhenAddEmployeeButtonIsClicked()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.Login();
            chromeDriver.GetElement(BenefitsDashboardPage.AddEmployeeButton).Click();
            chromeDriver.GetElement(BenefitsDashboardPage.AddEmployeeModal).WaitForDisplayed();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("addEmployeeModal")).Displayed);
        }

        [TestMethod]
        public void VerifyBannerIsDisplayed()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.Login();
            chromeDriver.GetElement(BenefitsDashboardPage.AddEmployeeButton).Click();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("header")).Displayed);
        }
    }
}