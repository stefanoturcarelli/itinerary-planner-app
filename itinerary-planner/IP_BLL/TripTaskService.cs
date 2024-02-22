using IPDAL;
using IPENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP_BLL
{
    /// <summary>
    /// TripTaskService is responsible to invoke Repository and managing business logic
    /// </summary>
    public class TripTaskService
    {
        public List<TripTask> GetTripTasks(int tripId)
        {
            List<TripTask> tripTasks = new List<TripTask>();
            TripTaskRepository tr = new TripTaskRepository();

            tripTasks = tr.GetTripTasks(tripId);

            return tripTasks;
        }

    }
}
