using HCM.Web.Areas.Admin.ViewModels;
using HCM.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static HCM.Web.Common.ApplicationConstants;

namespace HCM.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = AdminRoleName)]
	public class DepartmentManagementController(IDepartmentService departmentService) : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<DepartmentListModel> departments = await departmentService.GetAllDepartmentsForListAsync();

			return View(departments);
		}

		[HttpGet]
		public IActionResult Create()
		{
			DepartmentFormModel model = new DepartmentFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Create(DepartmentFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			bool result = await departmentService.CreateDepartmentAsync(model);

			if (result == false)
			{
				return View(model);
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			DepartmentFormModel model = await departmentService.GetDepartmentForEditAsync(id);

			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(DepartmentFormModel model, int id)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			bool result = await departmentService.EditDepartmentAsync(model, id);

			if (result == false)
			{
				return View(model);
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			bool result = await departmentService.DeleteDepartmentAsync(id);

			if (result == false)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index));
		}
	}
}