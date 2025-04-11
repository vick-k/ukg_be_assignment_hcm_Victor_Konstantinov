using HCM.Web.Areas.Admin.ViewModels;

namespace HCM.Web.Services.Interfaces
{
	public interface IUserService
	{
		Task<IEnumerable<UserViewModel>> GetAllUsersAsync();
	}
}
