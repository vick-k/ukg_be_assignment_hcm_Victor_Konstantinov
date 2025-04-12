using System.ComponentModel.DataAnnotations;

using static HCM.Web.Common.EntityValidationConstants.ApplicationUser;
using static HCM.Web.Common.ValidationMessages.ApplicationUser;

namespace HCM.Web.Areas.Admin.ViewModels
{
	public class EmployeeFormModel
	{
		public string? Id { get; set; }

		[Required(ErrorMessage = FirstNameRequiredErrorMessage)]
		[MinLength(FirstNameMinLength, ErrorMessage = FirstNameMinLengthErrorMessage)]
		[MaxLength(FirstNameMaxLength, ErrorMessage = FirstNameMaxLengthErrorMessage)]
		public string FirstName { get; set; } = null!;

		[Required(ErrorMessage = LastNameRequiredErrorMessage)]
		[MinLength(LastNameMinLength, ErrorMessage = LastNameMinLengthErrorMessage)]
		[MaxLength(LastNameMaxLength, ErrorMessage = LastNameMaxLengthErrorMessage)]
		public string LastName { get; set; } = null!;

		[Required(ErrorMessage = UsernameRequiredErrorMessage)]
		[MinLength(UsernameMinLength, ErrorMessage = UsernameMinLengthErrorMessage)]
		[MaxLength(UsernameMaxLength, ErrorMessage = UsernameMaxLengthErrorMessage)]
		public string Username { get; set; } = null!;

		[EmailAddress]
		[Required(ErrorMessage = EmailRequiredErrorMessage)]
		[MaxLength(EmailMaxLength, ErrorMessage = EmailMaxLengthErrorMessage)]
		public string Email { get; set; } = null!;

		public int JobTitleId { get; set; }

		public int DepartmentId { get; set; }

		[Required(ErrorMessage = SalaryRequiredErrorMessage)]
		[Range(typeof(decimal), SalaryMinValue, SalaryMaxValue, ErrorMessage = SalaryRangeErrorMessage)]
		public decimal Salary { get; set; }

		public IEnumerable<JobTitleListModel>? JobTitles { get; set; }

		public IEnumerable<DepartmentListModel>? Departments { get; set; }
	}
}
