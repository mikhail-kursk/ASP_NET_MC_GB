using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MetricAgent.DB;
using MetricAgent.Entityes;
using AutoMapper;
using Quartz.Spi;
using MetricAgent.Jobs;
using Quartz;
using Quartz.Impl;
using MetricsAgent.Jobs;

namespace MetricAgent
{
    public class Startup
    {
        private const string CronExpression = "0/5 * * * * ?";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddHttpClient();

            services.AddDbContext<DB.AppDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDbRepository<CpuEntity>, DbRepository<CpuEntity>>();
            services.AddScoped<IDbRepository<HddEntity>, DbRepository<HddEntity>>();
            services.AddScoped<IDbRepository<NetworkEntity>, DbRepository<NetworkEntity>>();
            services.AddScoped<IDbRepository<RamEntity>, DbRepository<RamEntity>>();

            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
 
            services.AddSingleton<CpuMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(CpuMetricJob),
                cronExpression: CronExpression));

            services.AddSingleton<HddMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(HddMetricJob),
                cronExpression: CronExpression));

            services.AddSingleton<NetworkMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(NetworkMetricJob),
                cronExpression: CronExpression));

            services.AddSingleton<RamMetricJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(RamMetricJob),
                cronExpression: CronExpression));

            var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);
            services.AddHostedService<QuartzHostedService>();
            services.AddHostedService<ServiceAgent>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
