using AutoMapper;
using BLL.DTO;
using DAL.Entity;

namespace BLL
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Trip, TripDTO>().ReverseMap();
            CreateMap<Schedule, ScheduleDTO>().ReverseMap();
            CreateMap<Bus, BusDTO>().ReverseMap();
            CreateMap<BusStop, BusStopDTO>().ReverseMap();
        }

    }
}
