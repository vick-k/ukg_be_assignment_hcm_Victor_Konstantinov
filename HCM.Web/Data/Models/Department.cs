using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static HCM.Web.Common.EntityValidationConstants.Department;

namespace HCM.Web.Data.Models
{
	public class Department
	{
		[Key]
		[Comment("The identifier of the department")]
		public int Id { get; set; }

		[Required]
		[Comment("The name of the department")]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		public bool IsDeleted { get; set; }

		public virtual ICollection<ApplicationUser> Employees { get; set; } = new HashSet<ApplicationUser>();
	}
}
