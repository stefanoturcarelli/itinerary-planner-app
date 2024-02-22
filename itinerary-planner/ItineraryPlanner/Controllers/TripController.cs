using IP_BLL;
using IPENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItineraryPlanner.Controllers
{
    public class TripController : Controller
    {
        // GET: Trip
        public ActionResult Index()
        {
            TripService ts = new TripService();
            var trips = ts.GetTrips();
            return View(trips);
        }

        public ActionResult CreateTripView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTripView(Trip trip)
        {
            TripService ts = new TripService();
            if (ts.AddTripService(trip))
            {
                ViewBag.Message = "Trip added successfully";
            }
            return View();
        }

        /// <summary>
        /// EditTripView is responsible for fetching the trip with the given tripId and displaying it in the view
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        public ActionResult EditTripView(int tripId)
        {
            TripService ts = new TripService();
            // Fetch all the trips and find the trip with the given tripId
            var trip = ts.GetTrips().Find(t => t.TripId == tripId);

            return View(trip);
        }

        /// <summary>
        /// EditTripView is responsible for updating the trip with the given tripId and displaying it in the view
        /// and pass that to the service and repository to update the trip
        /// </summary>
        /// <param name="trip"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditTripView(Trip trip)
        {
            TripService ts = new TripService();
            if (ts.UpdateTripService(trip))
            {
                ViewBag.Message = "Trip updated successfully";
            }
            return View();
        }

        public ActionResult DeleteTrip(int tripId)
        {
            TripService ts = new TripService();
            if (ts.DeleteTripService(tripId))
            {
                ViewBag.Message = "Trip deleted successfully";
                return RedirectToAction("Index");
            }
            return null;
        }
    }
}