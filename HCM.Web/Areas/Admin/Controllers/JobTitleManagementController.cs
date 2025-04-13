using HCM.Web.Areas.Admin.ViewModels;
using HCM.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static HCM.Web.Common.ApplicationConstants;

namespace HCM.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = AdminRoleName)]
	public class JobTitleManagementController(IJobTitleService jobTitleService) : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			IEnumerable<JobTitleListModel> jobTitles = await jobTitleService.GetAllJobTitlesForListAsync();

			return View(jobTitles);
		}

		[HttpGet]
		public IActionResult Create()
		{
			JobTitleFormModel model = new JobTitleFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Create(JobTitleFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			bool result = await jobTitleService.CreateJobTitleAsync(model);

			if (result == false)
			{
				return View(model);
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			JobTitleFormModel model = await jobTitleService.GetJobTitleForEditAsync(id);

			if (model == null)
			{
				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(JobTitleFormModel model, int id)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			bool result = await jobTitleService.EditJobTitleAsync(model, id);

			if (result == false)
			{
				return View(model);
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id)
		{
			bool result = await jobTitleService.DeleteJobTitleAsync(id);

			if (result == false)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
