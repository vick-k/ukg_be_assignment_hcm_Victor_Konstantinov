namespace HCM.Web.Areas.Admin.ViewModels
{
	public class EmployeeFormModel
	{
		public string? Id { get; set; }

		public string FirstName { get; set; } = null!;

		public string LastName { get; set; } = null!;

		public string Username { get; set; } = null!;

		public string Email { get; set; } = null!;

		public int JobTitleId { get; set; }

		public int DepartmentId { get; set; }

		public decimal Salary { get; set; }

		public IEnumerable<JobTitleListModel>? JobTitles { get; set; }

		public IEnumerable<DepartmentListModel>? Departments { get; set; }

		// TODO: add validations
	}
}
