namespace HCM.Web.Common
{
	public static class ValidationMessages
	{
		public static class ApplicationUser
		{
			public const string FirstNameRequiredErrorMessage = "First name is required.";
			public const string FirstNameMinLengthErrorMessage = "First name must be at least {1} characters long.";
			public const string FirstNameMaxLengthErrorMessage = "First name must be at most {1} characters long.";
			public const string LastNameRequiredErrorMessage = "Last name is required.";
			public const string LastNameMinLengthErrorMessage = "Last name must be at least {1} characters long.";
			public const string LastNameMaxLengthErrorMessage = "Last name must be at most {1} characters long.";
			public const string UsernameRequiredErrorMessage = "Username is required.";
			public const string UsernameMinLengthErrorMessage = "Username must be at least {1} characters long.";
			public const string UsernameMaxLengthErrorMessage = "Username must be at most {1} characters long.";
			public const string EmailRequiredErrorMessage = "Email is required.";
			public const string EmailMaxLengthErrorMessage = "Email must be at most {1} characters long.";
			public const string SalaryRequiredErrorMessage = "Salary is required.";
			public const string SalaryRangeErrorMessage = "Salary must be between {1} and {2}.";
		}
	}
}
