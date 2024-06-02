using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using TestWPFEFCore.Job;
using Unity;
using Unity.Microsoft.DependencyInjection;

namespace TestWPFEFCore.Extensions
{
    public static class QuartzExtensions
    {
        public static IServiceCollection AddQuartExtension(this IServiceCollection servicesUnity)
        {

            servicesUnity.AddQuartz(q =>
            {
                q.ScheduleJob<TestJob>(trigger => trigger
                        .StartNow()
                        .WithSimpleSchedule(x => x.WithIntervalInSeconds(1).RepeatForever()));

            });

            return servicesUnity;
        }
    }
}
