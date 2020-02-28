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

        // Landing Tests

        [TestMethod]
        public void VerifyEditButtonOpensModal()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("addEmployeeModal")).Displayed);
        }

        [TestMethod]
        public void VerifyEditButtonOpensModalWithCorrectEmployeeInformation()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("addEmployeeModal")).Displayed);
        }

        [TestMethod]
        public void VerifyEditButtonExists()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("btnEdit")).Displayed);
        }

        [TestMethod]
        public void VerifyDeleteButtonExists()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("btnDelete")).Displayed);
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
        public void VerifyEmployeeTableExists()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("employee-table")).Displayed);
        }

        [TestMethod]
        public void VerifyJumbotronBannerIsDisplayed() // Verifies page title "Benefits Dashboard" is displayed
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("header")).Displayed);
        }

        [TestMethod]
        public void VerifyJumbotronBannerTextIsCorrect() // Verifies page title "Benefits Dashboard" is displayed
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            //Console.WriteLine(chromeDriver.GetElement(BenefitsDashboardPage.BannerText).Text);
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.JumboBannerText).Text, "Benefits Dashboard");
        }

        [TestMethod]
        public void VerifyModalOpensWhenAddEmployeeButtonIsClicked()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("addEmployeeModal")).Displayed);
        }

        // Modal Tests

        [TestMethod]
        public void VerifyModalDependentsTextIsCorrect() // Verifies
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Console.WriteLine(chromeDriver.GetElement(BenefitsDashboardPage.DependentsTextModal).Text);
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.DependentsTextModal).Text, "Dependents:");
        }

        [TestMethod]
        public void VerifyModalFirstNameTextIsCorrect() // Verifies
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Console.WriteLine(chromeDriver.GetElement(BenefitsDashboardPage.FirstNameTextModal).Text);
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.FirstNameTextModal).Text, "First Name:");
        }

        [TestMethod]
        public void VerifyModalLastNameTextIsCorrect() // Verifies
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Console.WriteLine(chromeDriver.GetElement(BenefitsDashboardPage.LastNameTextModal).Text);
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.LastNameTextModal).Text, "Last Name:");
        }

        [TestMethod]
        public void VerifyAddEmployeeModalTitle()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.ModalTitle).Text, "Add Employee & Their Dependents"); // Not just His and capitalze dependents
        }

        [TestMethod]
        public void VerifyModalSubmitButtonExists()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("btnSubmitModal")).Displayed);
        }

        [TestMethod]
        public void VerifyModalCloseButtonExists()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("btnCloseModal")).Displayed);
        }

        [TestMethod]
        public void VerifyModalCloseXButtonExists()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("btnCloseModalX")).Displayed);
        }

        [TestMethod]
        public void VerifyModalClosesWhenCloseButtonIsClicked()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            chromeDriver.ClickCloseModalButton();
            Assert.IsFalse(chromeDriver.FindElement(By.Id("modalTitle")).Displayed);
        }
    }
}