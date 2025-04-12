namespace HCM.Web.Common
{
	public static class EntityValidationConstants
	{
		public static class Department
		{
			public const int NameMinLength = 2;
			public const int NameMaxLength = 80;
		}

		public static class JobTitle
		{
			public const int NameMinLength = 2;
			public const int NameMaxLength = 50;
		}

		public static class ApplicationUser
		{
			public const int FirstNameMinLength = 2;
			public const int FirstNameMaxLength = 50;
			public const int LastNameMinLength = 2;
			public const int LastNameMaxLength = 80;
			public const int UsernameMinLength = 3;
			public const int UsernameMaxLength = 20;
			public const int EmailMaxLength = 50;
			public const string SalaryMinValue = "500";
			public const string SalaryMaxValue = "100000";
		}
	}
}
