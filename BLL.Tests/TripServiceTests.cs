using AutoMapper;
using BLL.DTO;
using BLL.Services;
using BLL.Services.IService;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entity;
using DAL.Repository;
using DAL.Repository.IRepository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BLL.Tests
{
    public class TripServiceTests
    {

        [Fact]
        public void Ctor_InputNullDependencies_ThrowArgumentNullExeption()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(
                () => new TripService(null, null, null));

        }

        [Fact]
        public void GetAllTrips_NoInputParams_ReturnsCorrectlyMappedTripDTOs()
        {
            // Arrange

            var mockTripRepo = new Mock<ITripRepository>();
            var mockScheduleRepo = new Mock<IScheduleRepository>();

            var testTrip1 = new Trip() { name = "testTrip" };
            var testTrip2 = new Trip() { name = "testTrip2" };

            mockTripRepo
                .Setup(set => set.GetAll())
                .Returns(new List<Trip>(new Trip[] {testTrip1, testTrip2}));

            var testTrip1DTO = new TripDTO() { name = testTrip1.name };
            var testTrip2DTO = new TripDTO() { name = testTrip2.name };

            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<MapperConfig>()));

            ITripService tripService = new TripService(mockTripRepo.Object, mockScheduleRepo.Object, mapper);

            // Act

            var result = tripService.GetAllTrips();

            // Assert 

            Assert.NotNull(result);

            Assert.Equivalent(result.ToList()[0], testTrip1DTO);
            Assert.Equivalent(result.ToList()[1], testTrip2DTO);

        }

        [Fact]
        public void FindTripsBySchedule_NoAdminUser_ThrowMethodAccessException()
        {
            // Arrange

            User user = new CCL.Security.Identity.Employee(1,"test");
            SecurityContext.SetUser(user);
            var mockTripRepo = new Mock<ITripRepository>();
            var mockScheduleRepo = new Mock<IScheduleRepository>();
            var mockMapper = new Mock<IMapper>();


            ITripService tripService = new TripService(mockTripRepo.Object, mockScheduleRepo.Object, mockMapper.Object);

            // Act
            // Assert 

            Assert.Throws<MethodAccessException>(
                () => tripService.FindTripsBySchedule(DateTime.Now, DateTime.Now));
        }


        [Fact]
        public void FindTripsBySchedule_WrongArrivalAndDepartureTimeSpan_ThrowMethodAccessException()
        {
            // Arrange

            User user = new Admin(1, "test");
            SecurityContext.SetUser(user);
            var mockTripRepo = new Mock<ITripRepository>();
            var mockScheduleRepo = new Mock<IScheduleRepository>();
            var mockMapper = new Mock<IMapper>();

            ITripService tripService = new TripService(mockTripRepo.Object, mockScheduleRepo.Object, mockMapper.Object);

            // Act
            // Assert 

            Assert.Throws<ArgumentOutOfRangeException>(
                () => tripService.FindTripsBySchedule(DateTime.Now, DateTime.Now.AddMonths(-1)));
        }

        [Fact]
        public void FindTripsBySchedule_InputArrivalAndDepartureTime_ReturnsTwoTripDTOs()
        {
            // Arrange

            User user = new Admin(1, "test");
            SecurityContext.SetUser(user);
            var mockTripRepo = new Mock<ITripRepository>();
            var mockScheduleRepo = new Mock<IScheduleRepository>();

            mockScheduleRepo
                .Setup(set => set.GetAll())
                .Returns(new List<Schedule>(
                    new Schedule[] { 
                        new Schedule() { departureTime = DateTime.Now.AddMinutes(-20), arrivalTime = DateTime.Now.AddMinutes(-10), trip_Id = 1 },
                        new Schedule() { departureTime = DateTime.Now.AddMinutes(-20), arrivalTime = DateTime.Now.AddMinutes(-10), trip_Id = 2 },
                        new Schedule() { departureTime = DateTime.Now.AddMinutes(-40), arrivalTime = DateTime.Now.AddMinutes(40), trip_Id = 3 }
                    }
                    ));

            var testTrip1 = new Trip() { name = "testTrip" };
            var testTrip2 = new Trip() { name = "testTrip2" };

            mockTripRepo
                .Setup(set => set.GetById(1))
                .Returns(testTrip1);

            mockTripRepo
                .Setup(set => set.GetById(2))
                .Returns(testTrip2);

            var testTrip1DTO = new TripDTO() { name = testTrip1.name };
            var testTrip2DTO = new TripDTO() { name = testTrip2.name };

            var mockMapper = new Mock<IMapper>();

            mockMapper
                .Setup(m => m.Map<List<TripDTO>>(It.IsAny<List<Trip>>()))
                .Returns(new List<TripDTO>(new TripDTO[]{ testTrip1DTO, testTrip2DTO}));

            ITripService tripService = new TripService(mockTripRepo.Object, mockScheduleRepo.Object, mockMapper.Object);

            // Act

            var result = tripService.FindTripsBySchedule(DateTime.Now.AddMinutes(-30), DateTime.Now);

            // Assert 

            Assert.NotNull(result);

            mockScheduleRepo.Verify(set => set.GetAll(), Times.Once);
            mockTripRepo.Verify(set => set.GetById(It.IsAny<int>()), Times.Exactly(2));

            Assert.Equal(result.ToList()[0], testTrip1DTO);
            Assert.Equal(result.ToList()[1], testTrip2DTO);

        }

    }

}
