using HotelScheduleRoom.Domain.DTO;
using HotelScheduleRoom.Domain.Entity;
using HotelScheduleRoom.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelScheduleRoom.Application
{
    public class ReservationFacade : IReservationFacade
    {
        private readonly IReservationService _reservationService;
        public ReservationFacade(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        public Task<string> InsertReservation(ReservationRequest obj)
        {
            return _reservationService.Insert(obj);
        }

        public Task<List<ReservationEnt>> GetReservations()
        {
            return _reservationService.GetAll();
        }
        public Task<ReservationEnt> GetReservation(int id)
        {
            return _reservationService.Get(id);
        }

        public Task<int> DeleteReservation(int id)
        {
            return _reservationService.Delete(id);
        }

        public Task<string> UpdateReservation(ReservationRequest obj)
        {
            return _reservationService.Update(obj);
        }
    }
}
