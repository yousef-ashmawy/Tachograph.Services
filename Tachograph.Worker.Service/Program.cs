using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tachograph.Services.Domain;
using Tachograph.Services.Infrastructure.Interface;
using TachographServicesServices.Implementation;
using Tachograph.Worker.Service;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                IConfiguration configuration = hostContext.Configuration;
                services.AddDbContext<TachograpDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection")));

                services.AddScoped<ITachographRecordRepo, TachographRecordService>();
                services.AddHostedService<Worker>();
            });
}