using HCM.Web.Areas.Admin.ViewModels;

namespace HCM.Web.Services.Interfaces
{
	public interface IJobTitleService
	{
		Task<IEnumerable<JobTitleListModel>> GetAllJobTitlesForListAsync();
	}
}
