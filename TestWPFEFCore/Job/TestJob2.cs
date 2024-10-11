using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using TestWPFEFCore.Entity;
using TestWPFEFCore.Services;
using Unity;

namespace TestWPFEFCore.Job
{
    [DisallowConcurrentExecution]
    public class TestJob2 : IJob
    {
        [Dependency("c")]
        public ICarService _carService;
        public TestJob2()
        {

        }
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                //var sss = await _carService.GetFirstAsync();
                CarInfo carInfo = new CarInfo
                {
                    Vin = "Vin" + "123",
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };


                int count = await _carService.AddAsync(carInfo);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
