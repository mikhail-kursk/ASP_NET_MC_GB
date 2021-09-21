using MetricAgent.DB;
using MetricAgent.Entityes;
using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class DotnetMetricJob : IJob
    {
        public DotnetMetricJob()
        {
        }

        public Task Execute(IJobExecutionContext context)
        {
            // теперь можно записать что-то при помощи репозитория
            Console.WriteLine("DOTNET");
            return Task.CompletedTask;
        }
    }
}