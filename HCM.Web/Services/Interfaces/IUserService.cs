using HCM.Web.Areas.Admin.ViewModels;
using HCM.Web.Data.Models;

namespace HCM.Web.Services.Interfaces
{
	public interface IUserService
	{
		Task<IEnumerable<UserViewModel>> GetAllUsersAsync();

		Task<bool> CreateUserAsync(EmployeeFormModel model, string password);

		Task<EmployeeFormModel> GetEmployeeForEditAsync(string id);

		Task<bool> EditUserAsync(EmployeeFormModel model);
	}
}
