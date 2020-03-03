using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TK_Challenge.Pages;

namespace TK_Challenge
{
    [TestClass]
    public class LoginTests
    {
        public static IWebDriver chromeDriver, firefoxDriver, edgeDriver; // TODO: Setup tests to run in parallel on multiple browsers

        [ClassInitialize] // Use TestInitialize to open a fresh window for each test VS one window for the entire test class; TestInitialize would be beneficial if the application has any kind of session persistance
        public static void ClassInitialize(TestContext test)
        {
            var options = new ChromeOptions();
            options.AddArguments(BrowserOptions.BrowserVisible); 
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
        public void VerifyUselessBlueHeaderExists() // Verify useless blue header exists and is useless (also, critical bug, it's not blue)
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.ValidLogin();
            Assert.IsTrue(chromeDriver.GetElement(LoginPage.UselessBlueHeader).Displayed);
        }

        [TestMethod] // Verify user is logged in when using valid credentials
        public void VerifyLoginUserWhenCredentialsAreValid()
        {
            chromeDriver.Url = Navigation.LoginURL;  
            chromeDriver.ValidLogin();
            Assert.AreEqual(Navigation.DashboardURL, chromeDriver.Url);
        }

        [TestMethod] // Verify login card is displayed
        public void VerifyLoginCardIsDisplayed()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.GetElement(LoginPage.LoginButton).WaitForDisplayed();
            Assert.IsTrue(chromeDriver.GetElement(LoginPage.LoginCard).Displayed);
        }

        [TestMethod] // Verify Paylocity logo is displayed
        public void VerifyPaylocityLogoIsDisplayed()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.GetElement(LoginPage.LoginButton).WaitForDisplayed();
            Assert.IsTrue(chromeDriver.GetElement(LoginPage.LocityLogo).Displayed);
        }

        [TestMethod] // Verify Username field text is displayed correctly
        public void VerifyUsernameTextIsDisplayedCorrectly()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.GetElement(LoginPage.LoginButton).WaitForDisplayed();
            Assert.AreEqual(chromeDriver.GetElement(LoginPage.UsernameText).Text, "Username");
        }

        [TestMethod] // Verify Password field text is displayed correctly
        public void VerifyPasswordTextIsDisplayedCorrectly()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.GetElement(LoginPage.LoginButton).WaitForDisplayed();
            //Console.WriteLine(chromeDriver.GetElement(LoginPage.PasswordText).Text);
            Assert.AreEqual(chromeDriver.GetElement(LoginPage.PasswordText).Text, "Password");
        }

        [TestMethod] // Verify footer is displayed
        public void VerifyPaylocityFooterIsDisplayed()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.GetElement(LoginPage.LoginButton).WaitForDisplayed();
            Assert.IsTrue(chromeDriver.GetElement(LoginPage.CopyrightFooter).Displayed);
        }

        [TestMethod]  // Verify login button exists
        public void VerifyLoginButtonExists()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.GetElement(LoginPage.LoginButton).WaitForDisplayed();
            Assert.IsTrue(chromeDriver.GetElement(LoginPage.LoginButton).Displayed);
        }

        [TestMethod] // Verify validation error message is displayed for invalid username & password
        public void VerifyInvalidLoginBannerIsDisplayedWhenCredentialsAreInvalid()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.InvalidLogin();
            Assert.IsTrue(chromeDriver.GetElement(LoginPage.InvalidLoginBanner).Displayed);
        }

        [TestMethod] // Verify validation error message is displayed for valid username & invalid password
        public void VerifyInvalidLoginBannerIsDisplayedWhenUsernameIsValidAndPasswordIsInvalid()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.InvalidPasswordLogin();
            Assert.IsTrue(chromeDriver.GetElement(LoginPage.InvalidLoginBanner).Displayed);
        }

        [TestMethod] // Verify validation error message is displayed for invalid username & valid password
        public void VerifyInvalidLoginBannerIsDisplayedWhenPasswordIsValidAndUsernameIsInvalid()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.InvalidPasswordLogin();
            Assert.IsTrue(chromeDriver.GetElement(LoginPage.InvalidLoginBanner).Displayed);
        }
    }
}