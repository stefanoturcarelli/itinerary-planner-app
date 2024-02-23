using IPDAL;
using IPENTITIES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP_BLL
{
    /// <summary>
    /// The TripService class is responsible for managing trip-related operations by interacting with the TripRepository class.
    /// </summary>
    public class TripService
    {
        /// <summary>
        /// GetTrips is responsible for fetching all the trips from the database
        /// using the TripRepository class method GetTrips
        /// </summary>
        /// <returns>A list of Trip objects representing all trips in the system</returns>
        public List<Trip> GetTrips()
        {
            List<Trip> trips = new List<Trip>();
            TripRepository tr = new TripRepository();

            trips = tr.GetTrips();

            return trips;
        }

        /// <summary>
        /// AddTripService is responsible for adding a new trip to the database
        /// using the TripRepository class method AddTrip
        /// </summary>
        /// <param name="trip"></param>
        /// <returns></returns>
        public bool AddTripService(Trip trip)
        {
            TripRepository tr = new TripRepository();
            return tr.AddTrip(trip);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trip"></param>
        /// <returns></returns>
        public bool UpdateTripService(Trip trip)
        {
            TripRepository tr = new TripRepository();
            return tr.UpdateTrip(trip);
        }

        public bool DeleteTripService(int tripId)
        {
            TripRepository tr = new TripRepository();
            return tr.DeleteTrip(tripId);
        }
    }
}
