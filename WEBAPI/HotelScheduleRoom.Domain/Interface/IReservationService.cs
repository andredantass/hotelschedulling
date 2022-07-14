using HotelScheduleRoom.Domain.DTO;
using HotelScheduleRoom.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelScheduleRoom.Domain.Interface
{
    public interface IReservationService
    {
        Task<string> Insert(ReservationRequest obj);
        Task<List<ReservationEnt>> GetAll();
        Task<ReservationEnt> Get(int id);
        Task<int> Delete(int id);
        Task<string> Update(ReservationRequest obj, int id);

    }
}
