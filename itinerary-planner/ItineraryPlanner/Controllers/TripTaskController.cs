using IP_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItineraryPlanner.Controllers
{
    public class TripTaskController : Controller
    {
        // GET: TripTask
        public ActionResult Index(int tripId)
        {
            TripTaskService tts = new TripTaskService();
            var tripTasks = tts.GetTripTasks(tripId);

            return View(tripTasks);
        }
    }
}