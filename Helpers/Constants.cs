using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TK_Challenge
{
    public static class BrowserOptions
    {
        public const string BrowserVisible = "headed"; // Change to "headless" to run without the browser OR "headed" to run with browser
    }
    
    public static class Navigation
    {
        public const string LoginURL = "file:///C:/Users/smadd/OneDrive/Desktop/tk-challenge-mstest/login.html";
        public const string DashboardURL = "file:///C:/Users/smadd/OneDrive/Desktop/tk-challenge-mstest/home.html?username=testUser";
    }

    public static class TableColumns
    {
        public const int ID = 0;
        public const int LastName = 1;
        public const int FirstName = 2;
        public const int Salary = 3;
        public const int Dependents = 4;
        public const int GrossPay = 5;
        public const int BenefitCost = 6;
        public const int NetPay = 7;
        public const int Actions = 8;
    }

    public static class Finances
    {
        public const double YearlySalary = 52000;
        public const double YearlyBenefitCost = 1000;
        public const double YearlyPaychecks = 26;
        public const double DependentCost = 500;
        public const double DiscountPercentage = 0.1f;
        public const double BiWeeklyPaycheck = YearlySalary / YearlyPaychecks;
    }

    public static class PersonNoDiscount
    {
        public static string FirstName = "Mos";
        public static string LastName = "Def";
        public static int Dependents = 0;
        public static double BenefitCost = ((Finances.YearlyBenefitCost / Finances.YearlyPaychecks) + ((Finances.DependentCost / Finances.YearlyPaychecks) * Dependents));
    }

    public static class PersonNoDiscountAndDependents
    {
        public static string FirstName = "Slim";
        public static string LastName = "Shady";
        public static int Dependents = 1;
        public static double BenefitCost = ((Finances.YearlyBenefitCost / Finances.YearlyPaychecks) + ((Finances.DependentCost / Finances.YearlyPaychecks) * Dependents));
    }

    public static class PersonWithDiscount
    {
        public static string FirstName = "Ash";
        public static string LastName = "Ketchum";
        public static int Dependents = 0;
        public static double BenefitCost = ((Finances.YearlyBenefitCost / Finances.YearlyPaychecks) + ((Finances.DependentCost / Finances.YearlyPaychecks) * Dependents)) - ((Finances.YearlyBenefitCost / Finances.YearlyPaychecks) * Finances.DiscountPercentage);
    }

    public static class PersonWithDiscountAndDependents
    {
        public static string FirstName = "Alexa";
        public static string LastName = "Amazon";
        public static int Dependents = 1;
        public static double BenefitCost = ((Finances.YearlyBenefitCost / Finances.YearlyPaychecks) + ((Finances.DependentCost / Finances.YearlyPaychecks) * Dependents)) - (((Finances.YearlyBenefitCost / Finances.YearlyPaychecks) + (Finances.DependentCost / Finances.YearlyPaychecks) * Dependents)  * Finances.DiscountPercentage);
        public static string NetPay = (Finances.BiWeeklyPaycheck - BenefitCost).ToString();
    }
}
