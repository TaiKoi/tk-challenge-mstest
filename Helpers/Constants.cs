namespace TK_Challenge
{
    public static class Navigation
    {
        public const string LoginURL = "file:///C:/Users/smadd/OneDrive/Desktop/tk-challenge-mstest/login.html";
        public const string DashboardURL = "file:///C:/Users/smadd/OneDrive/Desktop/tk-challenge-mstest/home.html?username=testUser";
    }

    public static class Finances
    {
        public const int YearlySalary = 52000;
        public const int YearlyBenefitCost = 1000;
        public const int YearlyPaychecks = 26;
        public const int DependentCost = 500;
        public const float DiscountPercentage = 0.1f;
        public const int BiWeeklyPaycheck = YearlySalary / YearlyPaychecks;
    }

    public static class PersonNoDiscount
    {
        public static string FirstName = "Mos";
        public static string LastName = "Def";
        public static int Dependents = 0;
        public static float BenefitCost = ((Finances.YearlyBenefitCost / Finances.YearlyPaychecks) + ((Finances.DependentCost / Finances.YearlyPaychecks) * Dependents));
    }

    public static class PersonNoDiscountAndDependents
    {
        public static string FirstName = "Slim";
        public static string LastName = "Shady";
        public static int Dependents = 1;
        public static float BenefitCost = ((Finances.YearlyBenefitCost / Finances.YearlyPaychecks) + ((Finances.DependentCost / Finances.YearlyPaychecks) * Dependents));
    }

    public static class PersonWithDiscount
    {
        public static string FirstName = "Ash";
        public static string LastName = "Ketchum";
        public static int Dependents = 0;
        public static float BenefitCost = ((Finances.YearlyBenefitCost / Finances.YearlyPaychecks) + ((Finances.DependentCost / Finances.YearlyPaychecks) * Dependents));
    }

    public static class PersonWithDiscountAndDependents
    {
        public static string FirstName = "Alexa";
        public static string LastName = "Amazon";
        public static int Dependents = 1;
        public static float BenefitCost = ((Finances.YearlyBenefitCost / Finances.YearlyPaychecks) + ((Finances.DependentCost / Finances.YearlyPaychecks) * Dependents));
        public static string NetPay = (Finances.BiWeeklyPaycheck - BenefitCost).ToString();
    }
}
