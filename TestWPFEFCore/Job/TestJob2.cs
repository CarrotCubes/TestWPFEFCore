using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using TestWPFEFCore.Services;
using Unity;

namespace TestWPFEFCore.Job
{
    [DisallowConcurrentExecution]
    public class TestJob2 : IJob
    {
        [Dependency("c")]
        public ICarService? _carService;
        public TestJob2()
        {

        }
        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }
    }
}
