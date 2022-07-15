using HotelScheduleRoom.Application;
using HotelScheduleRoom.Domain.DTO;
using HotelScheduleRoom.Domain.Entity;
using HotelScheduleRoom.Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelScheduleRoom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<ReservationController> _logger;


        /// <summary>
        /// insert one reservation
        /// </summary>
        /// <returns>t</returns>
        /// <response code="200">Success</response>
        [HttpPost()]
        [ApiExplorerSettings(IgnoreApi = false)]
        public async Task<IActionResult> Post([FromServices] IReservationFacade reservationFacade, ReservationRequest reservationRequest)
        {
            var response = await reservationFacade.InsertReservation(reservationRequest);
            if (response != "")
                return Ok(new { msg = response, error = 1 });
            else
                return Ok(new { msg = response, error = 0 });

        }

        /// <summary>
        /// List all reservations
        /// </summary>
        /// <returns>t</returns>
        /// <response code="200">Success</response>
        [HttpGet()]
        public async Task<List<ReservationEnt>> GetAll([FromServices] IReservationFacade reservationFacade)
        {
            var response = await reservationFacade.GetReservations();
            return response;
       
        }

        /// <summary>
        /// Get a specific reservation
        /// </summary>
        /// <returns>t</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromServices] IReservationFacade reservationFacade, int id)
        {
            var response = await reservationFacade.GetReservation(id);
            if (response == null)
                return Ok(new { msg = "Reservation searched not founded!", error = 1 });
            else
                return Ok(new { msg = response, error = 0 });
        }

        /// <summary>
        /// Delete a specific reservation
        /// </summary>
        /// <returns>t</returns>
        /// <response code="200">Success</response>
        [HttpDelete("{id}")]
        public  Task<int> Delete([FromServices] IReservationFacade reservationFacade, int id)
        {
            var response =  reservationFacade.DeleteReservation(id);
            return response;
        }

        /// <summary>
        /// update a specific reservation
        /// </summary>
        /// <returns>t</returns>
        /// <response code="200">Success</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromServices] IReservationFacade reservationFacade, ReservationRequest reservationRequest)
        {

            var response = await reservationFacade.UpdateReservation(reservationRequest);

            if (response != "")
                return Ok(new { msg = response, error = 1 });
            else
                return Ok(new { msg = "Reservation updated successfully!" , error = 0});
        }
    }
}
