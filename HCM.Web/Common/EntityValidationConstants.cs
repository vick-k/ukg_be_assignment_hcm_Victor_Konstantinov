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
			public const int FirstNameMinLength = 1;
			public const int FirstNameMaxLength = 50;
			public const int LastNameMinLength = 1;
			public const int LastNameMaxLength = 80;
		}
	}
}
