using System.ComponentModel.DataAnnotations;
using static HCM.Web.Common.EntityValidationConstants.JobTitle;

namespace HCM.Web.Areas.Admin.ViewModels
{
	public class JobTitleFormModel
	{
		[Required]
		[MinLength(NameMinLength)]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;
	}
}
