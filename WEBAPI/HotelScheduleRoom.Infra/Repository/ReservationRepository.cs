using HotelScheduleRoom.Domain.Entity;
using HotelScheduleRoom.Domain.Interface;
using HotelScheduleRoom.Infra.Context;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelScheduleRoom.Infra.Repository
{
    public class ReservationRepository : BaseRepository<ReservationEnt>, IReservationRepository
    {
        public ReservationRepository(HotelScheduleDbContext context,ILogger<ReservationEnt> logger) : base(context, logger)
        {

        }
    }
}
