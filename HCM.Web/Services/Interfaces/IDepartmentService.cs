using HCM.Web.Areas.Admin.ViewModels;

namespace HCM.Web.Services.Interfaces
{
	public interface IDepartmentService
	{
		Task<IEnumerable<DepartmentListModel>> GetAllDepartmentsForListAsync();
	}
}
