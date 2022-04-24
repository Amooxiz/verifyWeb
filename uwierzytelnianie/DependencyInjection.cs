using uwierzytelnianie.Interfaces;
using uwierzytelnianie.Repositories;
using uwierzytelnianie.Services;

namespace uwierzytelnianie
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectService(this IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            return services;
        }

    }
}
