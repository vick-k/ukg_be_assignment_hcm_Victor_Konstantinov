﻿using HCM.Web.Areas.Admin.ViewModels;
using HCM.Web.Data;
using HCM.Web.Data.Models;
using HCM.Web.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

using static HCM.Web.Common.ApplicationConstants;

namespace HCM.Web.Services
{
	public class UserService(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext) : BaseService, IUserService
	{
		public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
		{
			List<ApplicationUser> users = userManager.Users
				.ToList();

			List<UserViewModel> userViewModels = new List<UserViewModel>();

			foreach (ApplicationUser user in users)
			{
				IList<string> roles = await userManager.GetRolesAsync(user);

				await dbContext.Entry(user)
					.Reference(u => u.JobTitle)
					.LoadAsync();

				await dbContext.Entry(user)
					.Reference(u => u.Department)
					.LoadAsync();

				userViewModels.Add(new UserViewModel
				{
					Id = user.Id.ToString(),
					Username = user.UserName!,
					FirstName = user.FirstName,
					LastName = user.LastName,
					Email = user.Email!,
					Salary = user.Salary,
					JobTitle = user.JobTitle.Name,
					Department = user.Department.Name,
					Roles = roles.ToList()
				});
			}

			return userViewModels;
		}

		public async Task<bool> CreateUserAsync(EmployeeFormModel model, string password)
		{
			ApplicationUser employee = new ApplicationUser()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				UserName = model.Username,
				Email = model.Email,
				JobTitleId = model.JobTitleId,
				DepartmentId = model.DepartmentId,
				Salary = model.Salary
			};

			IdentityResult result = await userManager.CreateAsync(employee, password);

			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(employee, UserRoleName);

				return true;
			}

			return false;
		}
	}
}
