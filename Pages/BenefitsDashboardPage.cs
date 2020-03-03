using OpenQA.Selenium;

namespace TK_Challenge.Pages
{
    public static class BenefitsDashboardPage
    {
        // Page Elements
        public static string JumboBannerText = "[id='headerText']";
        public static string JumboBanner = "[id='header']";
        public static string AddEmployeeButton = "[id='btnAddEmployee']";
        public static string AddEmployeeModal = "[id='addEmployeeModal']";
        public static string ModalTitle = "[id='modalTitle']";
        public static string FirstNameTextModal = "[id='firstNameTextModal']";
        public static string LastNameTextModal = "[id='lastNameTextModal']";
        public static string DependentsTextModal = "[id='dependentsTextModal']";
        public static string FirstNameFieldModal = "[id='firstNameFieldModal']";
        public static string LastNameFieldModal = "[id='lastNameFieldModal']";
        public static string DependentsFieldModal = "[id='dependentsFieldModal']";
        public static string EditButton = "[id='btnEdit']";
        public static string DeleteButton = "[id='btnDelete']";
        public static string SubmitButton = "[id='btnSubmitModal']";
        public static string CloseButton = "[id='btnCloseModal']";
        public static string CloseXButton = "[id='btnCloseModalX']";
        public static string EmployeeTable = "[id='employee-table']";
        public static string EmployeeTableHeader = "[id='tableHead']";
        public static string EmployeeTableBody = "[id='tableBody']";

        // Create a table object or interface to store all the records from the employee table.

        // Page Actions
        public static void ClickAddEmployeeButton(this IWebDriver driver)
        {
            driver.GetElement(AddEmployeeButton).Click();
            driver.GetElement(AddEmployeeModal).WaitForDisplayed();
        }

        public static void ClickSubmitEmployeeButton(this IWebDriver driver)
        {
            driver.GetElement(SubmitButton).Click();
        }

        public static void ClickEditButton(this IWebDriver driver)
        {
            //driver.ExecuteJavaScript<string>("return employee.js");

            driver.GetElement(EditButton).Click();
            driver.GetElement(AddEmployeeModal).WaitForDisplayed();
        }
        public static void ClickDeleteButton(this IWebDriver driver)
        {
            driver.GetElement(DeleteButton).Click();
        }

        public static void ClickCloseModalButton(this IWebDriver driver)
        {
            driver.GetElement(CloseButton).Click();
            //driver.GetElement(JumboBanner).WaitForDisplayed();
        }

        public static void ClickCloseModalXButton(this IWebDriver driver)
        {
            driver.GetElement(CloseXButton).Click();
            //driver.GetElement(JumboBanner).WaitForDisplayed();
        }
    }
}