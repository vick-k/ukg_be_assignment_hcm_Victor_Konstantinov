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
	public class UserManagementController(IUserService userService, IJobTitleService jobTitleService, IDepartmentService departmentService) : Controller
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
