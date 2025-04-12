using HCM.Web.Services;
using HCM.Web.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HCM.Web.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddCustomServices(this IServiceCollection services)
		{
			services.AddScoped<IBaseService, BaseService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IJobTitleService, JobTitleService>();
			services.AddScoped<IDepartmentService, DepartmentService>();

			return services;
		}
	}
}
