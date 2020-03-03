# Benefits Dashboard Automation

## Project Description:

Good afternoon and welcome to Ty's Paylocity automation challenge!　:japanese_ogre:

This project handles the End to End automation of the Benefits Dashboard application

## Built With:

* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [MSTest](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest)
* [Selenium](https://www.selenium.dev/)


**This project uses the following NuGet Packages:**

* Selenium.WebDriver
* Selenium.SupportSelenium.WebDriver.ChromeDriver 
* coverlet.collector
* Microsoft.NET.Test.Sdk
* MSTest.TestAdapter
* MSTest.TestFramework

## Installation:

**Install the above Nuget Packages**

Within the package manager console in Visual Studio, enter the following commands:

[Selenium.WebDriver](https://www.nuget.org/packages/Selenium.WebDriver/3.141.0?_src=template)

    PM> Install-Package Selenium.WebDriver -Version 3.141.0

[Selenium.WebDriver.ChromeDriver](https://www.nuget.org/packages/Selenium.WebDriver.ChromeDriver/80.0.3987.10600?_src=template)

    PM> Install-Package Selenium.WebDriver.ChromeDriver -Version 80.0.3987.10600

## Running Tests:

**Local**

`npm run qa:local`

**Test**

`npm run qa:e2e`