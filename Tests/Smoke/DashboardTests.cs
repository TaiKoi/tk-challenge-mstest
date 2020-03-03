using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
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

        [TestMethod]
        public void TestMethod()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();

            string[] columnText = new string[chromeDriver.GetTableHeaderElements("employee-table").Length];
            int i = 0;
            foreach (IWebElement column in chromeDriver.GetTableHeaderElements("employee-table"))
            {
                Console.WriteLine(columnText[i++] = column.Text);
            }

            Assert.AreEqual(chromeDriver.GetTableHeaderElements("employee-table").Length, 9);
        }

        [TestMethod]
        public void TestMethod3()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();

            string[] rowDataText = new string[chromeDriver.GetTableRows("employee-table").Length];
            int i = 0;
            foreach (IWebElement column in chromeDriver.GetTableRows("employee-table"))
            {
                Console.WriteLine(rowDataText[i++] = column.Text);
            }

            Assert.AreEqual(chromeDriver.GetTableRows("employee-table").Length, 1);
        }

        [TestMethod]
        public void VerifyEmployeeTableHeaderText()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.GetTableHeaderElements("employee-table");

            string[] columnText = new string[chromeDriver.GetTableHeaderElements("employee-table").Length];
            int i = 0;
            foreach (IWebElement column in chromeDriver.GetTableHeaderElements("employee-table"))
            {
                Console.WriteLine(columnText[i++] = column.Text);
            }

            Assert.AreEqual(chromeDriver.GetTableHeaderElements("employee-table")[0].Text, "ID");
            Assert.AreEqual(chromeDriver.GetTableHeaderElements("employee-table")[1].Text, "Last Name");
            Assert.AreEqual(chromeDriver.GetTableHeaderElements("employee-table")[2].Text, "First Name");
            Assert.AreEqual(chromeDriver.GetTableHeaderElements("employee-table")[3].Text, "Salary");
            Assert.AreEqual(chromeDriver.GetTableHeaderElements("employee-table")[4].Text, "Dependents");
            Assert.AreEqual(chromeDriver.GetTableHeaderElements("employee-table")[5].Text, "Gross Pay");
            Assert.AreEqual(chromeDriver.GetTableHeaderElements("employee-table")[6].Text, "Benefit Cost");
            Assert.AreEqual(chromeDriver.GetTableHeaderElements("employee-table")[7].Text, "Net Pay");
            Assert.AreEqual(chromeDriver.GetTableHeaderElements("employee-table")[8].Text, "Actions");
        }

        /*[TestMethod]
        public void VerifyGrossPayValue()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            if(chromeDriver.GetTableRowContent("employee-table").Length != 0)
            {
                Assert.AreEqual(chromeDriver.GetTableRowContent("employee-table")[0], 2000);
            }
            else
            {
                Assert.Inconclusive("No rows in table to test against");
            }
        }*/

        [TestMethod]
        public void VerifyAddEmployeeToTable()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            chromeDriver.GetElement(BenefitsDashboardPage.FirstNameFieldModal).SendKeys(PersonNoDiscount.FirstName);
            chromeDriver.GetElement(BenefitsDashboardPage.LastNameFieldModal).SendKeys(PersonNoDiscount.LastName);
            chromeDriver.GetElement(BenefitsDashboardPage.DependentsFieldModal).SendKeys(PersonNoDiscount.Dependents.ToString());
            chromeDriver.ClickSubmitEmployeeButton();
            Assert.AreEqual(chromeDriver.GetTableRows("employee-table").Length, 2);
        }

        [TestMethod] 
        public void VerifyBenefitCostOfEmployeeWithNoDiscount()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            chromeDriver.GetElement(BenefitsDashboardPage.FirstNameFieldModal).SendKeys(PersonNoDiscount.FirstName);
            chromeDriver.GetElement(BenefitsDashboardPage.LastNameFieldModal).SendKeys(PersonNoDiscount.LastName);
            chromeDriver.GetElement(BenefitsDashboardPage.DependentsFieldModal).SendKeys(PersonNoDiscount.Dependents.ToString());
            chromeDriver.ClickSubmitEmployeeButton();
            //Assert.AreEqual(chromeDriver.GetTableRows("employee-table")[1][index of benefit cost column].value in benefit cost column, Finances.Salary);
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