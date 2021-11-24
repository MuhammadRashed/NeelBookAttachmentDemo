namespace Demo4.Employees
{
    public static class EmployeeConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Employee." : string.Empty);
        }

    }
}