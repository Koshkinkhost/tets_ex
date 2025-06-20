using Project_Users_Managers.Repositories;
using Project_Users_Managers.Services;
using System.Threading.Tasks.Sources;

namespace Project_Users_Managers
{
    public static class ServiceManager
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskRepository,TaskRepository>();
            services.AddScoped<IServiceTask,TaskService>();
            return services;
        }

    }
}
