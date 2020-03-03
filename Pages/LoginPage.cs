using OpenQA.Selenium;

namespace TK_Challenge.Pages
{
    public static class LoginPage
    {
        // Page Elements
        public static string LoginCard = "[id='loginCard']";
        public static string LocityLogo = "[id='paylocityLogo']";
        public static string UsernameText = "[id='usernameText']";
        public static string UsernameField = "[id='formUsername']";
        public static string PasswordText = "[id='passwordText']";
        public static string PasswordField = "[id='formPassword']";
        public static string LoginButton = "[id='btnLogin']";
        public static string CopyrightFooter = "[id='footer']";
        public static string InvalidLoginBanner = "[id='validation-errors']";
        public static string UselessBlueHeader = "[id='uselessBlueHeader']";

        // Page Actions
        public static void ValidLogin(this IWebDriver driver) // Logs in the test user
        {
            driver.GetElement(LoginButton).WaitForDisplayed();
            driver.GetElement(UsernameField).SendKeys("testUser");
            driver.GetElement(PasswordField).SendKeys("Test1234");
            driver.GetElement(LoginButton).Click();
        }
  
        public static void InvalidLogin(this IWebDriver driver) // Attempt to login with invalid credentials
        {
            driver.GetElement(LoginButton).WaitForDisplayed();
            driver.GetElement(UsernameField).SendKeys("");
            driver.GetElement(PasswordField).SendKeys("");
            driver.GetElement(LoginButton).Click();
        }

        public static void InvalidPasswordLogin(this IWebDriver driver) // Attempt to login with valid username and invalid password
        {
            driver.GetElement(LoginButton).WaitForDisplayed();
            driver.GetElement(UsernameField).SendKeys("testUser");
            driver.GetElement(PasswordField).SendKeys("password");
            driver.GetElement(LoginButton).Click();
        }

        public static void InvalidUsernameLogin(this IWebDriver driver) // Attempt to login with valid password and invalid username
        {
            driver.GetElement(LoginButton).WaitForDisplayed();
            driver.GetElement(UsernameField).SendKeys("username");
            driver.GetElement(PasswordField).SendKeys("Test1234");
            driver.GetElement(LoginButton).Click();
        }

    }
}