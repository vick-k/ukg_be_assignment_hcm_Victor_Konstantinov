using HCM.Web.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static HCM.Web.Common.EntityValidationConstants.ApplicationUser;

namespace HCM.Web.Data.Configurations
{
	public class ApplicationUserConfiguration() : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder.Property(u => u.UserName)
				.HasMaxLength(UsernameMaxLength);

			builder.Property(u => u.Email)
				.HasMaxLength(EmailMaxLength);

			builder.HasData(GetUsers());
		}

		private IEnumerable<ApplicationUser> GetUsers()
		{
			ApplicationUser ivan = new ApplicationUser()
			{
				Id = Guid.Parse("21e27e05-cbee-44b0-88c2-0a6473769deb"),
				UserName = "ivan",
				NormalizedUserName = "IVAN",
				Email = "i.ivanov@hcm.com",
				NormalizedEmail = "I.IVANOV@HCM.COM",
				FirstName = "Ivan",
				LastName = "Ivanov",
				Salary = 1000m,
				JobTitleId = 3,
				DepartmentId = 4,
				SecurityStamp = Guid.NewGuid().ToString(),
				LockoutEnabled = true
			};

			ApplicationUser peter = new ApplicationUser()
			{
				Id = Guid.Parse("9835d1fa-775f-4396-b50e-5135a2112208"),
				UserName = "peter",
				NormalizedUserName = "PETER",
				Email = "p.petrov@hcm.com",
				NormalizedEmail = "P.PETROV@HCM.COM",
				FirstName = "Peter",
				LastName = "Petrov",
				Salary = 2500m,
				JobTitleId = 5,
				DepartmentId = 6,
				SecurityStamp = Guid.NewGuid().ToString(),
				LockoutEnabled = true
			};

			ApplicationUser george = new ApplicationUser()
			{
				Id = Guid.Parse("1211a2a3-dcd7-4a3d-be2d-aa8d07af4465"),
				UserName = "george",
				NormalizedUserName = "GEORGE",
				Email = "g.georgiev@hcm.com",
				NormalizedEmail = "G.GEORGIEV@HCM.COM",
				FirstName = "George",
				LastName = "Georgiev",
				Salary = 3500m,
				JobTitleId = 6,
				DepartmentId = 6,
				SecurityStamp = Guid.NewGuid().ToString(),
				LockoutEnabled = true
			};

			PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

			ivan.PasswordHash = passwordHasher.HashPassword(ivan, "Password1!");
			peter.PasswordHash = passwordHasher.HashPassword(peter, "Password1!");
			george.PasswordHash = passwordHasher.HashPassword(george, "Password1!");

			IEnumerable<ApplicationUser> users = new List<ApplicationUser>()
			{
				ivan,
				peter,
				george
			};

			return users;
		}
	}
}
