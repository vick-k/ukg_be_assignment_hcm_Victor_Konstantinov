using HCM.Web.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HCM.Web.Data.Configurations
{
	public class JobTitleConfiguration : IEntityTypeConfiguration<JobTitle>
	{
		public void Configure(EntityTypeBuilder<JobTitle> builder)
		{
			builder.HasData(GetJobTitles());
		}

		private IEnumerable<JobTitle> GetJobTitles()
		{
			return new List<JobTitle>
			{
				new JobTitle
				{
					Id = 1,
					Name = "Senior Software Engineer"
				},
				new JobTitle
				{
					Id = 2,
					Name = "Junior Software Engineer"
				},
				new JobTitle
				{
					Id = 3,
					Name = "Project Manager"
				},
				new JobTitle
				{
					Id = 4,
					Name = "Business Analyst"
				},
				new JobTitle
				{
					Id = 5,
					Name = "QA Specialist"
				},
				new JobTitle
				{
					Id = 6,
					Name = "QA Lead"
				},
				new JobTitle
				{
					Id = 7,
					Name = "HR Specialist"
				},
				new JobTitle
				{
					Id = 8,
					Name = "HR Lead"
				},
				new JobTitle
				{
					Id = 9,
					Name = "System Administrator"
				},
				new JobTitle
				{
					Id = 10,
					Name = "Account Manager"
				}
			};
		}
	}
}
