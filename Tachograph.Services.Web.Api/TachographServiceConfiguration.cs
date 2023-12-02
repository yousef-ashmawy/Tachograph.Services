using Microsoft.EntityFrameworkCore;
using Tachograph.Services.Domain;
using Tachograph.Services.Infrastructure.Interface;
using TachographServicesServices.Implementation;

namespace Tachograph.Services.Web.Api
{
    internal static class TachographServiceConfiguration
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts

            services.AddDbContext<TachograpDbContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"));
            });

            #endregion

            #region RegisterServices

            services.AddScoped<ITachographRecordRepo, TachographRecordService>();
            services.AddScoped<IViewsRepo, ViewsService>();
            services.AddScoped<IUsersRepo, UsersService>();

            #endregion

            return services;
        }
    }
}
 