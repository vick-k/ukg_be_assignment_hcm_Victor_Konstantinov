using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static HCM.Web.Common.EntityValidationConstants.JobTitle;

namespace HCM.Web.Data.Models
{
	public class JobTitle
	{
		[Key]
		[Comment("The identifier of the job title")]
		public int Id { get; set; }

		[Required]
		[Comment("The name of the job title")]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		public virtual ICollection<ApplicationUser> Employees { get; set; } = new HashSet<ApplicationUser>();
	}
}
