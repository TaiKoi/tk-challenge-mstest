namespace TK_Challenge
{
    public static class Finances
    {
        public const int YearlySalary = 52000;
        public const int YearlyBenefitCost = 1000;
        public const int YearlyPaychecks = 26;
        public const int DependentCost = 500;
        public const float DiscountPercentage = 0.1f;
    }

    public static class PersonNoDiscount
    {
        public static string FirstName = "Mos";
        public static string LastName = "Def";
        public static int Dependents = 0;
    }

    public static class PersonNoDiscountAndDependents
    {
        public static string FirstName = "Ash";
        public static string LastName = "Ketchum";
        public static int Dependents = 1;
    }

    public static class PersonWithDiscount
    {
        public static string FirstName = "Ash";
        public static string LastName = "Ketchum";
        public static int Dependents = 0;
    }

    public static class PersonWithDiscountAndDependents
    {
        public static string FirstName = "Ash";
        public static string LastName = "Ketchum";
        public static int Dependents = 1;
    }
}