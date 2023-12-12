using BLL.DTO;
using BLL.Services.IService;
using CCL.Security;
using CCL.Security.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NNP_Transport_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {

        private ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _tripService.GetAllTrips();

            if (result == null) return BadRequest();

            return Ok(result);
        }

        // 2021-12-11 20:03:03

        [HttpGet("ForAdmin")]
        public IActionResult FindTripsBySchedule([FromQuery] DateTime departureTime, [FromQuery] DateTime arrivalTime)
        {
            SecurityContext.SetUser(new Admin(1,"Kirgo"));

            var result = _tripService.FindTripsBySchedule(departureTime, arrivalTime);

            if (result == null) return BadRequest();

            return Ok(result);
        }
    }
}
