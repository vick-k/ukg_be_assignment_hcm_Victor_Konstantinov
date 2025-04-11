using HCM.Web.Data.Models;
using Microsoft.AspNetCore.Identity;

using static HCM.Web.Common.ApplicationConstants;

namespace HCM.Web.Data
{
	public static class DatabaseSeeder
	{
		public static void SeedRoles(IServiceProvider serviceProvider)
		{
			RoleManager<IdentityRole<Guid>> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

			string[] roles = { AdminRoleName, ManagerRoleName, UserRoleName };

			foreach (var role in roles)
			{
				bool roleExists = roleManager.RoleExistsAsync(role).GetAwaiter().GetResult();

				if (!roleExists)
				{
					IdentityResult result = roleManager.CreateAsync(new IdentityRole<Guid> { Name = role }).GetAwaiter().GetResult();

					if (!result.Succeeded)
					{
						throw new Exception($"Failed to create role: {role}");
					}
				}
			}
		}

		public static void AssignAdminRole(IServiceProvider serviceProvider)
		{
			UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

			string adminUserName = "admin";
			string adminEmail = "admin@gmail.com";
			string adminFirstName = "John";
			string adminLastName = "Doe";
			decimal adminSalary = 0m;
			int adminJobTitleId = 1;
			int adminDepartmentId = 1;
			string adminPassword = "Password1!";

			ApplicationUser? adminUser = userManager.FindByEmailAsync(adminEmail).GetAwaiter().GetResult();

			if (adminUser == null)
			{
				adminUser = new ApplicationUser()
				{
					UserName = adminUserName,
					Email = adminEmail,
					FirstName = adminFirstName,
					LastName = adminLastName,
					Salary = adminSalary,
					JobTitleId = adminJobTitleId,
					DepartmentId = adminDepartmentId
				};

				IdentityResult createUserResult = userManager.CreateAsync(adminUser, adminPassword).GetAwaiter().GetResult();

				if (!createUserResult.Succeeded)
				{
					throw new Exception($"Failed to create admin user: {adminUserName}");
				}
			}

			bool isInRole = userManager.IsInRoleAsync(adminUser, AdminRoleName).GetAwaiter().GetResult();

			if (!isInRole)
			{
				IdentityResult addRoleResult = userManager.AddToRoleAsync(adminUser, AdminRoleName).GetAwaiter().GetResult();

				if (!addRoleResult.Succeeded)
				{
					throw new Exception($"Failed to assign admin role to user: {adminUserName}");
				}
			}
		}
	}
}
