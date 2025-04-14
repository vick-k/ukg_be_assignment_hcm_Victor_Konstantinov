using HCM.Web.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HCM.Web.Data.Configurations
{
	public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{
			builder.HasData(GetDepartments());
		}

		private IEnumerable<Department> GetDepartments()
		{
			return new List<Department>
			{
				new Department
				{
					Id = 1,
					Name = "Human Resources"
				},
				new Department
				{
					Id = 2,
					Name = "Marketing"
				},
				new Department
				{
					Id = 3,
					Name = "Finance and Accounting"
				},
				new Department
				{
					Id = 4,
					Name = "Product Management"
				},
				new Department
				{
					Id = 5,
					Name = "Software Development"
				},
				new Department
				{
					Id = 6,
					Name = "Quality Assurance"
				},
				new Department
				{
					Id = 7,
					Name = "IT Support"
				}
			};
		}
	}

}
