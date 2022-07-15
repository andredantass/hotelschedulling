using HotelScheduleRoom.Domain.DTO;
using HotelScheduleRoom.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelScheduleRoom.Application
{
    public interface IReservationFacade
    {
        Task<string> InsertReservation(ReservationRequest obj);
        Task<List<ReservationEnt>> GetReservations();
        Task<ReservationEnt> GetReservation(int id);
        Task<int> DeleteReservation(int id);
        Task<string> UpdateReservation(ReservationRequest obj);
    }
}
