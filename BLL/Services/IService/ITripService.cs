using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.IService
{
    public interface ITripService
    {
        IEnumerable<TripDTO> GetAllTrips();
        IEnumerable<TripDTO> FindTripsBySchedule(DateTime? arrivalTime, DateTime? departureTime);
    }
}
