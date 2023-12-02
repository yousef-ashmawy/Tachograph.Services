using Tachograph.Services.Infrastructure.Interface;
using TachographServicesServices.Implementation;

namespace Tachograph.Worker.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly string _filesPath;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _filesPath = configuration.GetValue<string>("FilesPath");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var tachographRecordService = scope.ServiceProvider.GetRequiredService<ITachographRecordRepo>();
                        await tachographRecordService.ProcessDataFromJsonFile(_filesPath);
                    }

                    // Delay the worker for a specific interval
                    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while processing data from the JSON file.");
                }

            }
        }
    }
}