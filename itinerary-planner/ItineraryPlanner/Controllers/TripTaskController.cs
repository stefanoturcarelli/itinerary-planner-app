using IP_BLL;
using IPENTITIES;
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

            // Create TempData to store tripId to pass to CreateTripTask view.
            // We use TempData because it is a dictionary that is available for the current and subsequent request.
            TempData["tripId"] = tripId;

            return View(tripTasks);
        }

        public ActionResult CreateTripTask()
        {
            TripTask tripTask = null; // This is a reference to the TripTask object

            // Get tripId from TempData
            int tripId = (int)TempData["tripId"]; // Convert.ToInt32(TempData["tripId"]

            if (tripId != 0)
            {
                tripTask = new TripTask() // The reference becomes an object
                {
                    TripId = tripId // Set the TripId property of the object
                    // The other properties are not set because the user will input them
                };
            }

            return View(tripTask);
        }

        [HttpPost]
        public ActionResult CreateTripTask(TripTask tripTask)
        {
            // Call Business Logic Layer AddTripTask()
            return null;
        }
    }
}