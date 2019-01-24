using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Quartz;

namespace tt_quartz.mvc.Jobs
{
    public class SimpleJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
           var message = $"Simple excecuted at ${DateTime.Now.ToString()}";
            Debug.WriteLine(message);
        }
    }
}