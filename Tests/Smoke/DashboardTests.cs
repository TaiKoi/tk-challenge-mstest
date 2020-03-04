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

        [ClassInitialize] // Use TestInitialize to open a fresh window for each test VS one window for the entire test class; TestInitialize would be beneficial if the application has any kind of session persistance
        public static void ClassInitialize(TestContext test)
        {
            var options = new ChromeOptions();
            options.AddArguments(BrowserOptions.BrowserVisible); // Change argument to "headless" to run without the browser
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
        public void VerifyUselessBlueHeaderExists() // Verify useless blue header exists and is useless (also, critical bug, it's not blue)
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            Assert.IsTrue(chromeDriver.GetElement(BenefitsDashboardPage.UselessBlueHeader).Displayed);
        }

        [TestMethod]
        public void VerifyEditButtonOpensModal() // Verify edit button opens modal
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            if (chromeDriver.GetTableRows("employee-table").Length != 0)
            {
                chromeDriver.ClickEditButton();
                Assert.IsTrue(chromeDriver.GetElement(BenefitsDashboardPage.AddEmployeeModal).Displayed);
            }
            else
            {
                Assert.Inconclusive("No rows in table to test against");
            }
        }

        [TestMethod]
        public void VerifyEditButtonOpensModalWithCorrectEmployeeInformation() // Verify edit button opens modal with correct employee information
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickEditButton();
            Console.WriteLine(chromeDriver.GetElement(BenefitsDashboardPage.FirstNameFieldModal).Text);
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.FirstNameFieldModal).Text, "Zack"); // Make these dynamic //chromeDriver.GetTableRows(BenefitsDashboardPage.EmployeeTable)[0]);
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.LastNameFieldModal).Text, "Siler");
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.DependentsFieldModal).Text, "1");
        }

        [TestMethod]
        public void VerifyEditButtonExists() // Verify Edit buttpm is displayed
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            Assert.IsTrue(chromeDriver.GetElement(BenefitsDashboardPage.EditButton).Displayed);
        }

        [TestMethod]
        public void VerifyDeleteButtonExists() // Verify delete button is displayed
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            Assert.IsTrue(chromeDriver.GetElement(BenefitsDashboardPage.DeleteButton).Displayed);
        }

        [TestMethod]
        public void VerifyEmployeeTableExists() // Verify employee table exists
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            Assert.IsTrue(chromeDriver.GetElement(BenefitsDashboardPage.EmployeeTable).Displayed);
        }

        [TestMethod]
        public void VerifyJumbotronBannerIsDisplayed() // Verify page title "Benefits Dashboard" is displayed
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.IsTrue(chromeDriver.GetElement(BenefitsDashboardPage.JumboBanner).Displayed);
        }

        [TestMethod]
        public void VerifyJumbotronBannerTextIsCorrect() // Verify page title "Benefits Dashboard" is displayed with correct text
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.JumboBannerText).Text, "Benefits Dashboard");
        }

        [TestMethod]
        public void VerifyModalOpensWhenAddEmployeeButtonIsClicked() // Verify add employee modal opens when Add Employee button is clicked
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.IsTrue(chromeDriver.GetElement(BenefitsDashboardPage.AddEmployeeModal).Displayed);
        }

        [TestMethod]
        public void VerifyModalOpensBlankWhenAddEmployeeButtonIsClicked() // Verify add employee modal opens with empty input fields when Add Employee button is clicked
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            chromeDriver.GetElement(BenefitsDashboardPage.AddEmployeeModal).WaitForDisplayed();
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.FirstNameFieldModal).Text, "");
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.LastNameFieldModal).Text, "");
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.DependentsFieldModal).Text, "");
        }

        [TestMethod]
        public void VerifyEmployeeTableHeaderText() // Verify employee table header exists with correct column titles
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
        public void VerifyGrossPayValue() // Verify Gross Pay is displayed with correct value
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            if(chromeDriver.GetTableRows("employee-table").Length != 0)
            {
                Assert.AreEqual(chromeDriver.GetTableRowContent("employee-table")[0], 2000);
            }
            else
            {
                Assert.Inconclusive("No rows in table to test against");
            }
        }*/

        [TestMethod]
        public void VerifyDeleteButtonDeletesEmployeeFromTable() // Verify employee can be deleted from table
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            if (chromeDriver.GetTableRows("employee-table").Length != 0)
            {
                chromeDriver.ClickDeleteButton(); // Would need to specify which row to delete based on which delete button was clicked
                Assert.AreEqual(chromeDriver.GetTableRows("employee-table").Length, 0);
            }
            else
            {
                Assert.Inconclusive("No rows in table to test against");
            }
        }

        [TestMethod]
        public void VerifyAddEmployeeToTable() // Verify new employee can be added to table
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
        public void VerifyBenefitCostOfEmployeeWithNoDiscount() // Verify Benefit Cost is calculated and displayed correctly for employee with no discount 
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
        public void VerifyModalDependentsTextIsCorrect() // Verify Dependents text is displayed correctly in modal
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Console.WriteLine(chromeDriver.GetElement(BenefitsDashboardPage.DependentsTextModal).Text);
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.DependentsTextModal).Text, "Dependents:");
        }

        [TestMethod]
        public void VerifyModalFirstNameTextIsCorrect() // Verify First Name text is displayed correctly in modal
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Console.WriteLine(chromeDriver.GetElement(BenefitsDashboardPage.FirstNameTextModal).Text);
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.FirstNameTextModal).Text, "First Name:");
        }

        [TestMethod]
        public void VerifyModalLastNameTextIsCorrect() // Verify Last Name text is displayed correctly in modal
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Console.WriteLine(chromeDriver.GetElement(BenefitsDashboardPage.LastNameTextModal).Text);
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.LastNameTextModal).Text, "Last Name:");
        }

        [TestMethod]
        public void VerifyAddEmployeeModalTitle() // Verify modal title is correct
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.AreEqual(chromeDriver.GetElement(BenefitsDashboardPage.ModalTitle).Text, "Add Employee & Employee Dependents");
        }

        [TestMethod]
        public void VerifyModalSubmitButtonExists() // Verify modal submit button is displayed when modal is opened 
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.IsTrue(chromeDriver.GetElement(BenefitsDashboardPage.SubmitButton).Displayed);
        }

        [TestMethod]
        public void VerifyModalCloseButtonExists() // Verify modal close button is displayed when modal is opened 
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.IsTrue(chromeDriver.GetElement(BenefitsDashboardPage.CloseButton).Displayed);
        }

        [TestMethod]
        public void VerifyModalCloseXButtonExists() // Verify modal close X button is displayed when modal is opened 
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            Assert.IsTrue(chromeDriver.GetElement(BenefitsDashboardPage.CloseXButton).Displayed);
        }

        [TestMethod]
        public void VerifyModalClosesWhenCloseButtonIsClicked() // Verify modal closes when close button is clicked
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            System.Threading.Thread.Sleep(500);
            chromeDriver.ClickCloseModalButton();
            System.Threading.Thread.Sleep(500);
            Assert.IsFalse(chromeDriver.GetElement(BenefitsDashboardPage.ModalTitle).Displayed);
        }

        [TestMethod]
        public void VerifyModalClosesWhenCloseXButtonIsClicked() // Verify modal closes when close X button is clicked
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            chromeDriver.ClickAddEmployeeButton();
            System.Threading.Thread.Sleep(500);
            chromeDriver.ClickCloseModalButton();
            System.Threading.Thread.Sleep(500);
            Assert.IsFalse(chromeDriver.GetElement(BenefitsDashboardPage.ModalTitle).Displayed);
        }
    }
}