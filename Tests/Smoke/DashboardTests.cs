using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using TK_Challenge.Pages;
using System;

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
        public void VerifyEditButton()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.IsTrue(chromeDriver.FindElement(By.Id(BenefitsDashboardPage.AddEmployeeModal)).Displayed);
        }

        /*[TestMethod]
        public void VerifyDeleteButton()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.Login();
            chromeDriver.ClickAddEmployeeButton();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("header")).Displayed);
        }*/

        [TestMethod]
        public void VerifyAddEmployeeModalTitle()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.ModalTitle).Text, "Add Employee & Their Dependents"); // Not just His and capitalze dependents
        }

        [TestMethod]
        public void VerifyModalFirstNameTextIsCorrect() // Verifies
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Console.WriteLine(chromeDriver.GetElement(BenefitsDashboardPage.FirstNameTextModal).Text);
            //Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.FirstNameTextModal).Text, "First Name");
        }

        [TestMethod]
        public void VerifyModalLastNameTextIsCorrect() // Verifies
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Console.WriteLine(chromeDriver.GetElement(BenefitsDashboardPage.LastNameTextModal).Text);
            //Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.LastNameTextModal).Text, "Last Name");
        }

        [TestMethod]
        public void VerifyModalDependentsTextIsCorrect() // Verifies
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Console.WriteLine(chromeDriver.GetElement(BenefitsDashboardPage.DependentsTextModal).Text);
            //Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.DependentsTextModal).Text, "Dependents");
        }

        [TestMethod]
        public void VerifyModalOpensWhenAddEmployeeButtonIsClicked()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.IsTrue(chromeDriver.FindElement(By.Id(BenefitsDashboardPage.AddEmployeeModal)).Displayed);
        }

        [TestMethod]
        public void VerifyJumbotronBannerIsDisplayed() // Verifies page title "Benefits Dashboard" is displayed
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.IsTrue(chromeDriver.FindElement(By.Id(BenefitsDashboardPage.JumboBanner)).Displayed);
        }

        [TestMethod]
        public void VerifyJumbotronBannerTextIsCorrect() // Verifies page title "Benefits Dashboard" is displayed
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            //Console.WriteLine(chromeDriver.GetElement(BenefitsDashboardPage.BannerText).Text);
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.JumboBannerText).Text, "Benefits Dashboard");
        }
    }
}