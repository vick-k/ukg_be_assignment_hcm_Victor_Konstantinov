using HCM.Web.Areas.Admin.ViewModels;
using HCM.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
	}
}
