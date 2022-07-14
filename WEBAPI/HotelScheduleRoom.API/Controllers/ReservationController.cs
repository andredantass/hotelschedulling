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
                return NotFound(response);
            else
                return Ok($"Reservation confirmed");

        }

        /// <summary>
        /// List all reservations
        /// </summary>
        /// <returns>t</returns>
        /// <response code="200">Success</response>
        [HttpGet()]
        public async Task<ActionResult<List<ReservationEnt>>> GetAll([FromServices] IReservationFacade reservationFacade)
        {
            var response = await reservationFacade.GetReservations();
            if (response == null)
                return NotFound("No Reservations founded!");
            else
                return Ok(response);
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
                return NotFound("Reservation searched not founded!");
            else
                return Ok(response);
        }

        /// <summary>
        /// Delete a specific reservation
        /// </summary>
        /// <returns>t</returns>
        /// <response code="200">Success</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromServices] IReservationFacade reservationFacade, int id)
        {
            var response = await reservationFacade.DeleteReservation(id);

            if (response == -1)
                return NotFound("An error occured!");
            else
                return Ok($"Reservation deleted!");


        }

        /// <summary>
        /// update a specific reservation
        /// </summary>
        /// <returns>t</returns>
        /// <response code="200">Success</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromServices] IReservationFacade reservationFacade, ReservationRequest reservationRequest, int id)
        {

            var response = await reservationFacade.UpdateReservation(reservationRequest,id);

            if (response != "")
                return NotFound(response);
            else
                return Ok($"Reservation updated successfully!");
        }
    }
}
