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
        //[Dependency]
        public ICarService _carService;
        public TestJob2([Dependency("c")] ICarService carService)
        {
            _carService = carService;
        }
        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }
    }
}
