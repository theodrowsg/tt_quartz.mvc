using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quartz;
using tt_quartz.mvc.Jobs;
using tt_quartz.mvc.Models;

namespace tt_quartz.mvc.Controllers
{
    public class HomeController : Controller
    {
        IScheduler _scheduler;
        
        public HomeController(IScheduler _scheduler){
            this._scheduler = _scheduler;
        }
        public async Task<IActionResult> StartSimpleJob(){
            IJobDetail job = JobBuilder.Create<SimpleJob>()
            .WithIdentity("simplejob","quartzexamples")
            .Build();

            ITrigger trigger = TriggerBuilder.Create()
                                             .WithIdentity("testtrigger","quartzexamples")
                                             .StartNow()
                                             .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).WithRepeatCount(5))
                                             .Build();

            await _scheduler.ScheduleJob(job, trigger);

            return RedirectToAction("Index");
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
