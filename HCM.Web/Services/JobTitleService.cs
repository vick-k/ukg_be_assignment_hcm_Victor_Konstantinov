using HCM.Web.Areas.Admin.ViewModels;
using HCM.Web.Data;
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
				.OrderBy(j => j.Name)
				.Select(j => new JobTitleListModel()
				{
					Id = j.Id,
					Name = j.Name
				})
				.ToListAsync();

			return jobTitles;
		}
	}
}
