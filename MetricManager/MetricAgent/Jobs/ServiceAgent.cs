using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MetricAgent.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Quartz;
using Quartz.Spi;

namespace MetricAgent.Jobs
{
    public class ServiceAgent : IHostedService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public ServiceAgent(
            IConfiguration configuration,
            IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
        }
        public IScheduler Scheduler { get; set; }

        public async Task StartAsync(CancellationToken cancellationToken)
        {

            var MetricAgentUri = _configuration.GetConnectionString("MetricManager");
            MetricAgentUri += "register";
            var client = _clientFactory.CreateClient();

            var agentDto = new AgentDto();

            agentDto.ClientName = "CPUAgent";
            agentDto.Uri = "https://localhost:44333/api/metrics/cpu";
            var data = new StringContent(JsonConvert.SerializeObject(agentDto), Encoding.UTF8, "application/json");
            var result = await client.PostAsync(MetricAgentUri, data);

            agentDto.ClientName = "DotnetAgent";
            agentDto.Uri = "https://localhost:44333/api/metrics/dotnet";
            data = new StringContent(JsonConvert.SerializeObject(agentDto), Encoding.UTF8, "application/json");
            result = await client.PostAsync(MetricAgentUri, data);

            agentDto.ClientName = "RAMAgent";
            agentDto.Uri = "https://localhost:44333/api/metrics/ram";
            data = new StringContent(JsonConvert.SerializeObject(agentDto), Encoding.UTF8, "application/json");
            result = await client.PostAsync(MetricAgentUri, data);

            agentDto.ClientName = "HDDAgent";
            agentDto.Uri = "https://localhost:44333/api/metrics/hdd";
            data = new StringContent(JsonConvert.SerializeObject(agentDto), Encoding.UTF8, "application/json");
            result = await client.PostAsync(MetricAgentUri, data);

            agentDto.ClientName = "NETWORKAgent";
            agentDto.Uri = "https://localhost:44333/api/metrics/network";
            data = new StringContent(JsonConvert.SerializeObject(agentDto), Encoding.UTF8, "application/json");
            result = await client.PostAsync(MetricAgentUri, data);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Scheduler?.Shutdown(cancellationToken);
        }
    }
}