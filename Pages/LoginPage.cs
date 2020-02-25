using OpenQA.Selenium;

namespace TK_Challenge.Pages
{
    public static class LoginPage
    {
        // Page Elements
        public static string UsernameField = "[id='formUsername']";
        public static string PasswordField = "[id='formPassword']";
        public static string LoginButton = "[id='btnLogin']";

        // Page Actions
        public static void Login(this IWebDriver driver) // Logs in the test user
        {
            driver.GetElement(LoginButton).WaitForDisplayed();
            driver.GetElement(UsernameField).SendKeys("testUser");
            driver.GetElement(PasswordField).SendKeys("Test1234");
            driver.GetElement(LoginButton).Click();
        }
    }
}