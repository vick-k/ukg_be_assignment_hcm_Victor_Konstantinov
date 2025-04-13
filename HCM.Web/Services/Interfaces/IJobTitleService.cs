using HCM.Web.Areas.Admin.ViewModels;

namespace HCM.Web.Services.Interfaces
{
	public interface IJobTitleService
	{
		Task<IEnumerable<JobTitleListModel>> GetAllJobTitlesForListAsync();

		Task<bool> CreateJobTitleAsync(JobTitleFormModel model);

		Task<JobTitleFormModel> GetJobTitleForEditAsync(int id);

		Task<bool> EditJobTitleAsync(JobTitleFormModel model, int id);

		Task<bool> DeleteJobTitleAsync(int id);
	}
}
