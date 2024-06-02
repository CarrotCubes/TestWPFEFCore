using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Unity;
using TestWPFEFCore.Services;

namespace TestWPFEFCore.Job
{
    [DisallowConcurrentExecution]
    public class TestJob : IJob
    {
        //[Dependency]
        public ICarService _carService;
        public TestJob([Dependency("c")] ICarService carService)
        {
            _carService = carService;
        }
        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }
    }
}
