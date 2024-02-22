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
    /// TripTaskRepository is responsible to connect to DB and perform and execute commands
    /// </summary>
    public class TripTaskRepository
    {
        public List<TripTask> GetTripTasks(int tripId)
        {
            List<TripTask> tripTasks = new List<TripTask>();

            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {

                // 2. Fire the SQL Query
                string commandText = "usp_GetTasks";
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);
                sqlCommand.CommandType = CommandType.StoredProcedure; // Tells SQL to execute the procedure

                // Pass a parameter before
                sqlCommand.Parameters.AddWithValue("@tripId", tripId);

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
                    tripTasks.Add(
                            new TripTask
                            {
                                TripId = Convert.ToInt32(dr["TripId"]),
                                TaskName = Convert.ToString(dr["TaskName"]),
                                Description = Convert.ToString(dr["TaskDescription"]),
                                TaskDueDate = Convert.ToDateTime(dr["TaskDueDate"]),
                            });
                }
            }

            return tripTasks;
        }
    }
}
