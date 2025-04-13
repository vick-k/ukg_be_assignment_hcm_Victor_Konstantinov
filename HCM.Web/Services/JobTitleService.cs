using HCM.Web.Areas.Admin.ViewModels;
using HCM.Web.Data;
using HCM.Web.Data.Models;
using HCM.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HCM.Web.Services
{
	public class JobTitleService(ApplicationDbContext dbContext) : BaseService, IJobTitleService
	{
		public async Task<IEnumerable<JobTitleListModel>> GetAllJobTitlesForListAsync()
		{
			List<JobTitleListModel> jobTitles = await dbContext.JobTitles
				.AsNoTracking()
				.Where(j => j.IsDeleted == false)
				.OrderBy(j => j.Name)
				.Select(j => new JobTitleListModel()
				{
					Id = j.Id,
					Name = j.Name
				})
				.ToListAsync();

			return jobTitles;
		}

		public async Task<bool> CreateJobTitleAsync(JobTitleFormModel model)
		{
			bool isDuplicate = await dbContext.JobTitles
				.AnyAsync(j => j.Name == model.Name);

			if (isDuplicate)
			{
				return false;
			}

			JobTitle jobTitle = new JobTitle()
			{
				Name = model.Name
			};

			await dbContext.JobTitles.AddAsync(jobTitle);
			await dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<JobTitleFormModel> GetJobTitleForEditAsync(int id)
		{
			JobTitle? jobTitle = await dbContext.JobTitles
				.AsNoTracking()
				.FirstOrDefaultAsync(j => j.Id == id);

			JobTitleFormModel model = new JobTitleFormModel();

			if (jobTitle != null)
			{
				model.Name = jobTitle.Name;
			}
			else
			{
				model = null!;
			}

			return model;
		}

		public async Task<bool> EditJobTitleAsync(JobTitleFormModel model, int id)
		{
			JobTitle? jobTitle = await dbContext.JobTitles
				.FirstOrDefaultAsync(j => j.Id == id);

			if (jobTitle == null)
			{
				return false;
			}

			bool jobTitleAlreadyExists = await dbContext.JobTitles
				.AsNoTracking()
				.AnyAsync(j => j.Name == model.Name);

			if (jobTitleAlreadyExists)
			{
				return false;
			}

			jobTitle.Name = model.Name;

			await dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<bool> DeleteJobTitleAsync(int id)
		{
			JobTitle? jobTitle = await dbContext.JobTitles
				.FirstOrDefaultAsync(j => j.Id == id);

			if (jobTitle == null || jobTitle.IsDeleted)
			{
				return false;
			}

			jobTitle.IsDeleted = true;

			await dbContext.SaveChangesAsync();

			return true;
		}
	}
}
