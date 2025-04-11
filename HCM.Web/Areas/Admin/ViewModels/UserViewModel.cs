namespace HCM.Web.Areas.Admin.ViewModels
{
	public class UserViewModel
	{
		public string Id { get; set; } = null!;

		public string Username { get; set; } = null!;

		public string FirstName { get; set; } = null!;

		public string LastName { get; set; } = null!;

		public string Email { get; set; } = null!;

		public decimal Salary { get; set; }

		public string JobTitle { get; set; } = null!;

		public string Department { get; set; } = null!;

		public List<string> Roles { get; set; } = new List<string>();
	}
}
