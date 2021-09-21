using MetricAgent.DB;
using MetricAgent.Entityes;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class NetworkMetricJob : IJob
    {
        public NetworkMetricJob()
        {
        }

        public Task Execute(IJobExecutionContext context)
        {
            // теперь можно записать что-то при помощи репозитория
            Console.WriteLine("NETWORK");
            return Task.CompletedTask;
        }
    }
}