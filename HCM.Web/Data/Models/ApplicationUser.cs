using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HCM.Web.Common.EntityValidationConstants.ApplicationUser;

namespace HCM.Web.Data.Models
{
	public class ApplicationUser : IdentityUser<Guid>
	{
		public ApplicationUser()
		{
			Id = Guid.NewGuid();
		}

		[Required]
		[Comment("The first name of the employee")]
		[MaxLength(FirstNameMaxLength)]
		public string FirstName { get; set; } = null!;

		[Required]
		[Comment("The last name of the employee")]
		[MaxLength(LastNameMaxLength)]
		public string LastName { get; set; } = null!;

		[Precision(18, 2)]
		[Comment("The current salary of the employee")]
		public decimal Salary { get; set; }

		[ForeignKey(nameof(JobTitle))]
		[Comment("The identifier of the job title")]
		public int JobTitleId { get; set; }

		public virtual JobTitle JobTitle { get; set; } = null!;

		[ForeignKey(nameof(Department))]
		[Comment("The identifier of the department")]
		public int DepartmentId { get; set; }

		public virtual Department Department { get; set; } = null!;

		public bool IsDeleted { get; set; }
	}
}
