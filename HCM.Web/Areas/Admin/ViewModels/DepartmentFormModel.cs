using System.ComponentModel.DataAnnotations;
using static HCM.Web.Common.EntityValidationConstants.Department;

namespace HCM.Web.Areas.Admin.ViewModels
{
	public class DepartmentFormModel
	{
		[Required]
		[MinLength(NameMinLength)]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;
	}
}
