using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace TK_Challenge.Pages
{
    public static class BenefitsDashboardPage
    {
        // Page Elements
        public static string JumboBannerText = "[id='headerText']";
        public static string JumboBanner = "[id='header']";
        public static string AddEmployeeButton = "[id='btnAddEmployee']";
        public static string AddEmployeeModal = "[id='addEmployeeModal']";
        public static string EmployeeTable = "[id='employee-table']";
        public static string ModalTitle = "[id='modalTitle']";
        public static string EditButton = "[id='btnEdit']";
        public static string DeleteButton = "[id='btnDelete']";
        public static string FirstNameTextModal = "[id='firstNameTextModal']";
        public static string LastNameTextModal = "[id='lastNameTextModal']";
        public static string DependentsTextModal = "[id='dependentsTextModal']";
        
        // Create a table object or interface to store all the records from the employee table. Then 

        // Page Actions
        public static void ClickAddEmployeeButton(this IWebDriver driver)
        {
            driver.GetElement(AddEmployeeButton).Click();
            driver.GetElement(AddEmployeeModal).WaitForDisplayed();
        }

        public static void ClickEditButton(this IWebDriver driver, string firstName, string lastName, int dependents)
        {
            //driver.ExecuteJavaScript<string>("return employee.js");
            firstName = driver.GetElement(EmployeeTable);

            driver.GetElement(EditButton).Click();
            driver.GetElement(AddEmployeeModal).WaitForDisplayed();
        }
        public static void ClickDeleteButton(this IWebDriver driver)
        {
            driver.GetElement(DeleteButton).Click();
            driver.GetElement(AddEmployeeModal).WaitForDisplayed();
        }

    }
}