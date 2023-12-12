using AutoMapper;
using BLL.DTO;
using BLL.Services.IService;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entity;
using DAL.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BLL.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripSet;
        private readonly IScheduleRepository _scheduleSet;
        private IMapper _mapper;

        public TripService(ITripRepository tripSet, IScheduleRepository scheduleSet, IMapper mapper)
        {
            if(tripSet == null || scheduleSet == null || mapper == null)
            {
                throw new ArgumentNullException(
                    tripSet == null ? nameof(tripSet) : "" +
                    scheduleSet == null ? nameof(scheduleSet) : "" +
                    mapper == null ? nameof(mapper) : ""); 
            }
            _tripSet = tripSet;
            _scheduleSet = scheduleSet;
            _mapper = mapper;
        }

        public IEnumerable<TripDTO> FindTripsBySchedule(DateTime? departureTime, DateTime? arrivalTime)
        {
            if(arrivalTime == null || departureTime == null)
            {
                throw new NullReferenceException();
            }

            if (arrivalTime < departureTime)
            {
                throw new ArgumentOutOfRangeException();
            }

            var user = SecurityContext.GetUser();
            var userRole = user.GetRole();

            if (userRole == nameof(Admin))
            {
                var schedules = _scheduleSet.GetAll();

                if (schedules == null || schedules.Count == 0)
                {
                    return new List<TripDTO>();
                }

                List<Trip> result = new List<Trip>();

                foreach(Schedule schedule in schedules)
                {
                    if(schedule.arrivalTime < arrivalTime && schedule.departureTime > departureTime)
                    {
                        result.Add(_tripSet.GetById(schedule.trip_Id));
                    }
                }

                var tripsDTOs = _mapper.Map<List<TripDTO>>(result);
                return tripsDTOs;
            }
            else
            {
                throw new MethodAccessException();
            }
        }

        public IEnumerable<TripDTO> GetAllTrips()
        {
            var result = _tripSet.GetAll();

            if (result == null || result.Count == 0)
            {
                return new List<TripDTO>();
            }

            var tripsDTOs = _mapper.Map<List<TripDTO>>(result);
            return tripsDTOs;
        }
    }
}
