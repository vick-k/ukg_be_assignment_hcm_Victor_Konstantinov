using HCM.Web.Areas.Admin.ViewModels;
using HCM.Web.Data;
using HCM.Web.Data.Models;
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
				.Where(d => d.IsDeleted == false)
				.OrderBy(d => d.Name)
				.Select(d => new DepartmentListModel()
				{
					Id = d.Id,
					Name = d.Name
				})
				.ToListAsync();

			return departments;
		}

		public async Task<bool> CreateDepartmentAsync(DepartmentFormModel model)
		{
			bool isDuplicate = await dbContext.Departments
				.AnyAsync(d => d.Name == model.Name);

			if (isDuplicate)
			{
				return false;
			}

			Department department = new Department()
			{
				Name = model.Name
			};

			await dbContext.Departments.AddAsync(department);
			await dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<DepartmentFormModel> GetDepartmentForEditAsync(int id)
		{
			Department? department = await dbContext.Departments
				.AsNoTracking()
				.FirstOrDefaultAsync(d => d.Id == id);

			DepartmentFormModel model = new DepartmentFormModel();

			if (department != null)
			{
				model.Name = department.Name;
			}
			else
			{
				model = null!;
			}

			return model;
		}

		public async Task<bool> EditDepartmentAsync(DepartmentFormModel model, int id)
		{
			Department? department = await dbContext.Departments
				.FirstOrDefaultAsync(d => d.Id == id);

			if (department == null)
			{
				return false;
			}

			bool departmentAlreadyExists = await dbContext.Departments
				.AsNoTracking()
				.AnyAsync(d => d.Name == model.Name);

			if (departmentAlreadyExists)
			{
				return false;
			}

			department.Name = model.Name;

			await dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<bool> DeleteDepartmentAsync(int id)
		{
			Department? department = await dbContext.Departments
				.FirstOrDefaultAsync(d => d.Id == id);

			if (department == null || department.IsDeleted)
			{
				return false;
			}

			department.IsDeleted = true;

			await dbContext.SaveChangesAsync();

			return true;
		}
	}
}
