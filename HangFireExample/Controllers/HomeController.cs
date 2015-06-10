using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hangfire;

namespace HangFireExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View((object)TextBuffer.ToString());
        }

        public ActionResult Buffer()
        {
            return Content(TextBuffer.ToString());
        }

        [HttpPost]
        public ActionResult CreateBackGroundJob()
        {
            int n = GetRandom();
            BackgroundJob.Enqueue(() => new Job().DoWork(n));
            TextBuffer.WriteLine("Background job successfully created to find prime number >=" + n);

            return RedirectToAction("Index");
        }

        public ActionResult CreateRecurringJob()
        {
            int n = GetRandom();
            RecurringJob.AddOrUpdate(() => new Job().DoWork(n), Cron.Minutely);
            TextBuffer.WriteLine("Recurring Job (every minute) has been created to find prime number >=" + n.ToString());

            return RedirectToAction("Index");
        }

        private int GetRandom()
        {
            return _random.Next(10000, 100000);
        }

        private Random _random = new Random(DateTime.Now.Second);
    }
}
