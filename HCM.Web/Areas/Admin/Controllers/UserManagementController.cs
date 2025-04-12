using HCM.Web.Areas.Admin.ViewModels;
using HCM.Web.Data.Models;
using HCM.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using static HCM.Web.Common.ApplicationConstants;

namespace HCM.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = AdminRoleName)]
	public class UserManagementController(IBaseService baseService, IUserService userService, IJobTitleService jobTitleService, IDepartmentService departmentService) : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<UserViewModel> users = await userService.GetAllUsersAsync();

			return View(users);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			IEnumerable<JobTitleListModel> jobTitles = await jobTitleService.GetAllJobTitlesForListAsync();
			IEnumerable<DepartmentListModel> departments = await departmentService.GetAllDepartmentsForListAsync();

			EmployeeFormModel model = new EmployeeFormModel()
			{
				JobTitles = jobTitles,
				Departments = departments
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Create(EmployeeFormModel model)
		{
			if (!ModelState.IsValid)
			{
				model.JobTitles = await jobTitleService.GetAllJobTitlesForListAsync();
				model.Departments = await departmentService.GetAllDepartmentsForListAsync();

				return View(model);
			}

			string password = GenerateSecurePassword();

			bool result = await userService.CreateUserAsync(model, password);

			if (!result)
			{
				model.JobTitles = await jobTitleService.GetAllJobTitlesForListAsync();
				model.Departments = await departmentService.GetAllDepartmentsForListAsync();

				return View(model);
			}

			TempData["GeneratedPassword"] = password;
			TempData["Username"] = model.Username;

			return RedirectToAction("EmployeeCreated");
		}

		[HttpGet]
		public IActionResult EmployeeCreated()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Edit(string id)
		{
			Guid userGuid = Guid.Empty;
			bool isGuidValid = baseService.IsGuidValid(id, ref userGuid);

			if (!isGuidValid)
			{
				return RedirectToAction(nameof(Index));
			}

			EmployeeFormModel model = await userService.GetEmployeeForEditAsync(id);

			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}

			IEnumerable<JobTitleListModel> jobTitles = await jobTitleService.GetAllJobTitlesForListAsync();
			IEnumerable<DepartmentListModel> departments = await departmentService.GetAllDepartmentsForListAsync();

			model.JobTitles = jobTitles;
			model.Departments = departments;

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(EmployeeFormModel model)
		{
			Guid userGuid = Guid.Empty;
			bool isGuidValid = baseService.IsGuidValid(model.Id, ref userGuid);

			if (!isGuidValid || model.Id == null)
			{
				return RedirectToAction(nameof(Index));
			}

			if (!ModelState.IsValid)
			{
				model.JobTitles = await jobTitleService.GetAllJobTitlesForListAsync();
				model.Departments = await departmentService.GetAllDepartmentsForListAsync();

				return View(model);
			}

			bool result = await userService.EditUserAsync(model);

			if (!result)
			{
				model.JobTitles = await jobTitleService.GetAllJobTitlesForListAsync();
				model.Departments = await departmentService.GetAllDepartmentsForListAsync();

				return View(model);
			}

			TempData["SuccessMessage"] = "Employee updated successfully.";

			return RedirectToAction(nameof(Index));
		}

		private string GenerateSecurePassword()
		{
			PasswordOptions options = new PasswordOptions
			{
				RequiredLength = 6,
				RequireDigit = true,
				RequireLowercase = true,
				RequireUppercase = true,
				RequireNonAlphanumeric = true
			};

			string[] randomChars = new[]
			{
				"ABCDEFGHJKLMNOPQRSTUVWXYZ",
				"abcdefghijkmnopqrstuvwxyz",
				"0123456789",
				"!@$?_-"
			};

			Random rand = new Random();
			List<char> chars = new List<char>();

			if (options.RequireUppercase)
			{
				chars.Add(randomChars[0][rand.Next(randomChars[0].Length)]);
			}

			if (options.RequireLowercase)
			{
				chars.Add(randomChars[1][rand.Next(randomChars[1].Length)]);
			}

			if (options.RequireDigit)
			{
				chars.Add(randomChars[2][rand.Next(randomChars[2].Length)]);
			}

			if (options.RequireNonAlphanumeric)
			{
				chars.Add(randomChars[3][rand.Next(randomChars[3].Length)]);
			}

			while (chars.Count < options.RequiredLength)
			{
				string rcs = randomChars[rand.Next(randomChars.Length)];
				chars.Add(rcs[rand.Next(rcs.Length)]);
			}

			return new string(chars.OrderBy(x => rand.Next()).ToArray());
		}
	}
}
