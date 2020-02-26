using OpenQA.Selenium;

namespace TK_Challenge.Pages
{
    public static class BenefitsDashboardPage
    {
        // Page Elements
        public static string BannerText = "[id='headerText']";
        public static string Banner = "[id='header']";
        public static string AddEmployeeButton = "[id='btnAddEmployee']";
        public static string AddEmployeeModal = "[id='addEmployeeModal']";
        public static string ModalTitle = "[id='modalTitle']";
        public static string EditButton = "[id='btnEdit]";
        public static string DeleteButton = "[id='btnDelete]";
        public static string FirstNameTextModal = "[id='firstNameTextModal]";
        public static string LastNameTextModal = "[id='lastNameTextModal]";
        public static string DependentsTextModal = "[id='dependentsTextModal]";

        // Page Actions
        public static void ClickAddEmployeeButton(this IWebDriver driver)
        {
            driver.GetElement(AddEmployeeButton).Click();
            driver.GetElement(AddEmployeeModal).WaitForDisplayed();
        }

        public static void ClickEditButton(this IWebDriver driver)
        {
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