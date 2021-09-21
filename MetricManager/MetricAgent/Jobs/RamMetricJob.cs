using MetricAgent.DB;
using MetricAgent.Entityes;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class RamMetricJob : IJob
    {

        public RamMetricJob()
        {
        }

        public Task Execute(IJobExecutionContext context)
        {
            // теперь можно записать что-то при помощи репозитория
            Console.WriteLine("RAM");
            return Task.CompletedTask;
        }
    }
}