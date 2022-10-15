using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SampleRegistrationForm.Core.IRepository;
using SampleRegistrationForm.Core.IService;
using SampleRegistrationForm.Repository;
using SampleRegistrationForm.Services;


namespace SampleRegistrationForm.Utility
{
    public class DIResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            //for accessing the http context by interface in view level
            #region Http context
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            #endregion
            //for service accesssing
            #region Service

            services.AddScoped<IRegistrationService, RegistrationService>();
            #endregion
            //for Repository accessing 
            #region Repository

            services.AddScoped<IRegistrationRepository, RegistrationRepository>();

            #endregion


        }
    }
}
