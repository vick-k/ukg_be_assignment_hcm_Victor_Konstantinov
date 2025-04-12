using HCM.Web.Areas.Admin.ViewModels;
using HCM.Web.Data;
using HCM.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HCM.Web.Services
{
	public class DepartmentService(ApplicationDbContext dbContext) : BaseService, IDepartmentService
	{
		public async Task<IEnumerable<DepartmentListModel>> GetAllDepartmentsForListAsync()
		{
			List<DepartmentListModel> departments = await dbContext.Departments
				.AsNoTracking()
				.OrderBy(d => d.Name)
				.Select(d => new DepartmentListModel()
				{
					Id = d.Id,
					Name = d.Name
				})
				.ToListAsync();

			return departments;
		}
	}
}
