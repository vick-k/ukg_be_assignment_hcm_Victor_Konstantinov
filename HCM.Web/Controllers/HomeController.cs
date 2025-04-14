using HCM.Web.Areas.Admin.ViewModels;
using HCM.Web.Data.Models;
using HCM.Web.Models;
using HCM.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HCM.Web.Controllers
{
	public class HomeController(IUserService userService) : Controller
	{
		public async Task<IActionResult> Index()
		{
			if (User?.Identity?.IsAuthenticated ?? false)
			{
				UserViewModel model = new UserViewModel();
				ApplicationUser? user = await userService.GetUserAsync(User.Identity!.Name!);

				if (user != null)
				{
					model.FirstName = user.FirstName;
					model.LastName = user.LastName;
					model.JobTitle = user.JobTitle.Name;
					model.Department = user.Department.Name;
					model.Salary = user.Salary;
				}

				return View(model);
			}

			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
