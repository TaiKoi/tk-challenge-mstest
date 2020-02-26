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
    public class LoginTests
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
        public void VerifyLoginUserWhenCredentialsAreValid()
        {
            chromeDriver.Url = Navigation.LoginURL;  
            chromeDriver.ValidLogin();
            Assert.AreEqual(Navigation.DashboardURL, chromeDriver.Url);
        }

        [TestMethod]
        public void VerifyLoginCardIsDisplayed()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.GetElement(LoginPage.LoginButton).WaitForDisplayed();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("loginCard")).Displayed);
        }

        [TestMethod]
        public void VerifyPaylocityLogoIsDisplayed()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.GetElement(LoginPage.LoginButton).WaitForDisplayed();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("paylocityLogo")).Displayed);
        }

        [TestMethod]
        public void VerifyUsernameTextIsDisplayedCorrectly()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.GetElement(LoginPage.LoginButton).WaitForDisplayed();
            //Console.WriteLine(chromeDriver.GetElement(LoginPage.UsernameText).Text);
            Assert.AreEqual(chromeDriver.GetElement(LoginPage.UsernameText).Text, "Username");
        }

        [TestMethod]
        public void VerifyPasswordTextIsDisplayedCorrectly()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.GetElement(LoginPage.LoginButton).WaitForDisplayed();
            //Console.WriteLine(chromeDriver.GetElement(LoginPage.PasswordText).Text);
            Assert.AreEqual(chromeDriver.GetElement(LoginPage.PasswordText).Text, "Password");
        }

        [TestMethod]
        public void VerifyPaylocityFooterIsDisplayed()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.GetElement(LoginPage.LoginButton).WaitForDisplayed();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("footer")).Displayed);
        }

        [TestMethod]
        public void VerifyLoginButtonExists()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.GetElement(LoginPage.LoginButton).WaitForDisplayed();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("btnLogin")).Displayed);
        }

        [TestMethod]
        public void VerifyInvalidLoginBannerIsDisplayedWhenCredentialsAreInvalid()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.InvalidLogin();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("validation-errors")).Displayed);
        }

        [TestMethod]
        public void VerifyInvalidLoginBannerIsDisplayedWhenUsernameIsValidAndPasswordIsInvalid()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.InvalidPasswordLogin();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("validation-errors")).Displayed);
        }

        [TestMethod]
        public void VerifyInvalidLoginBannerIsDisplayedWhenPasswordIsValidAndUsernameIsInvalid()
        {
            chromeDriver.Url = Navigation.LoginURL;
            chromeDriver.InvalidPasswordLogin();
            Assert.IsTrue(chromeDriver.FindElement(By.Id("validation-errors")).Displayed);
        }
    }
}