using IPENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDAL
{
    /// <summary>
    /// TripRepository.cs connects to the database and performs CRUD operations (Stored Procedures created in SQL Server)
    /// </summary>
    public class TripRepository
    {
        public List<Trip> GetTrips()
        {
            List<Trip> trips = new List<Trip>();

            // 1. Connect to DB with the help of 'using' so that at the end, the system can destroy the connection objects
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                //conn.Open(); // If we use SQLDataAdapter we don't have to use Open and Close connection methods

                // 2. Fire the SQL Query
                string commandText = "usp_GetAllTrips";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure; // Tells SQL to execute the procedure

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand); // At this point, ADO.NET will fire query using command

                DataTable dt = new DataTable(); // At this point, Query is fired and the data table has been filled with data/records/(Trips)
                adapter.Fill(dt);

                // Fill method does five things for us:
                // 1. Open the connection
                // 2. Execute the command
                // 3. Retrieve the result
                // 4. Fill the datatable
                // 5. Close the connection 

                // 3. Convert ADO.NET object to Entities (Trip)
                foreach (DataRow dr in dt.Rows)
                {
                    trips.Add(
                        new Trip
                        {
                            TripId = Convert.ToInt32(dr["TripId"]),
                            Destination = Convert.ToString(dr["Destination"]),
                            Description = Convert.ToString(dr["Description"]),
                            StartDate = Convert.ToDateTime(dr["StartDate"]),
                            EndDate = Convert.ToDateTime(dr["EndDate"]),
                        });
                }
                return trips;
            }
        }

        /// <summary>
        /// AddTrip is responsible for adding a new trip to the database
        /// </summary>
        /// <param name="trip"></param>
        /// <returns></returns>
        public bool AddTrip(Trip trip)
        {
            using(SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_InsertTrip", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Destination", trip.Destination);
                sqlCommand.Parameters.AddWithValue("@Description", trip.Description);
                sqlCommand.Parameters.AddWithValue("@StartDate", trip.StartDate);
                sqlCommand.Parameters.AddWithValue("@EndDate", trip.EndDate);

                conn.Open();
                // ExecuteNonQuery is used for Insert, Update and Delete
                int i = sqlCommand.ExecuteNonQuery();
                conn.Close();

                if(i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// UpdateTrip peforms an update of the record
        /// </summary>
        /// <param name="trip"></param>
        /// <returns></returns>
        public bool UpdateTrip(Trip trip)
        {
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                string commandText = "usp_UpdateTrip";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@TripId", trip.TripId);
                sqlCommand.Parameters.AddWithValue("@Destination", trip.Destination);
                sqlCommand.Parameters.AddWithValue("@Description", trip.Description);
                sqlCommand.Parameters.AddWithValue("@StartDate", trip.StartDate);
                sqlCommand.Parameters.AddWithValue("@EndDate", trip.EndDate);

                conn.Open();
                int i = sqlCommand.ExecuteNonQuery();
                conn.Close();

                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// DeleteTrip is responsible for deleting the trip with the given tripId
        /// </summary>
        /// <param name="tripId"></param>
        /// <returns></returns>
        public bool DeleteTrip(int tripId)
        {
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                string commandText = "usp_DeleteTrip";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@TripId", tripId);

                conn.Open();
                int i = sqlCommand.ExecuteNonQuery();
                conn.Close();

                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
