using HCM.Web.Areas.Admin.ViewModels;
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

		public async Task<EmployeeFormModel> GetEmployeeForEditAsync(string id)
		{
			ApplicationUser? employee = userManager.Users
				.FirstOrDefault(u => u.Id.ToString() == id);

			EmployeeFormModel model = new EmployeeFormModel();

			if (employee != null)
			{
				model.Id = employee.Id.ToString();
				model.FirstName = employee.FirstName;
				model.LastName = employee.LastName;
				model.Username = employee.UserName!;
				model.Email = employee.Email!;
				model.Salary = employee.Salary;
				model.JobTitleId = employee.JobTitleId;
				model.DepartmentId = employee.DepartmentId;
			}
			else
			{
				model = null!;
			}

			return model;
		}

		public async Task<bool> EditUserAsync(EmployeeFormModel model)
		{
			ApplicationUser? employee = userManager.Users
				.FirstOrDefault(u => u.Id.ToString() == model.Id);

			if (employee == null)
			{
				return false;
			}

			employee.FirstName = model.FirstName;
			employee.LastName = model.LastName;
			employee.UserName = model.Username;
			employee.Email = model.Email;
			employee.Salary = model.Salary;
			employee.JobTitleId = model.JobTitleId;
			employee.DepartmentId = model.DepartmentId;

			IdentityResult result = await userManager.UpdateAsync(employee);

			if (result.Succeeded)
			{
				return true;
			}

			return false;
		}
	}
}
