using MetricAgent.DB;
using MetricAgent.Entityes;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace MetricsAgent.Jobs
{
    public class NetworkMetricJob : IJob
    {
        private PerformanceCounter _networkCounter;
        private IServiceProvider _provider;
        
        public NetworkMetricJob(IServiceProvider provider)
        {
            _networkCounter = new PerformanceCounter("Network Interface", "Bytes Total/sec", "ASUS PCE-N10 11n Wireless LAN PCI-E Card");
            _provider = provider;
        }

        public async Task Execute(IJobExecutionContext context)
        {

            using (var scope = _provider.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IDbRepository<NetworkEntity>>();

                NetworkEntity entity = new NetworkEntity
                {
                    Value = Convert.ToInt32(_networkCounter.NextValue()),
                    Time = DateTime.UtcNow
                };
                await repository.AddAsync(entity);
            }
        }
    }
}