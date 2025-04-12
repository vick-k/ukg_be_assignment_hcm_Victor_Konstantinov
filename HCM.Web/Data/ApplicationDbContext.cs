using HCM.Web.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using static HCM.Web.Common.EntityValidationConstants.ApplicationUser;

namespace HCM.Web.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Department> Departments { get; set; } = null!;

		public virtual DbSet<JobTitle> JobTitles { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<ApplicationUser>(entity =>
			{
				entity.Property(u => u.UserName)
				.HasMaxLength(UsernameMaxLength);

				entity.Property(u => u.Email)
				.HasMaxLength(EmailMaxLength);
			});
		}
	}
}
