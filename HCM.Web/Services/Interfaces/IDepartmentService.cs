using HCM.Web.Areas.Admin.ViewModels;

namespace HCM.Web.Services.Interfaces
{
	public interface IDepartmentService
	{
		Task<IEnumerable<DepartmentListModel>> GetAllDepartmentsForListAsync();

		Task<bool> CreateDepartmentAsync(DepartmentFormModel model);

		Task<DepartmentFormModel> GetDepartmentForEditAsync(int id);

		Task<bool> EditDepartmentAsync(DepartmentFormModel model, int id);

		Task<bool> DeleteDepartmentAsync(int id);
	}
}
