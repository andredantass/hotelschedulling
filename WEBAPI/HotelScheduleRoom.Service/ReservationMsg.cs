using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelScheduleRoom.Service
{
    public enum ReservationMsg
    {
        MoreThan3Days,
        StartReservationMore30DaysAdvance,
        NotAfterToday,
        NotAvailable,
        StartDateNotMoreEndDate,
        RetroactiveDateNotAllow,
        None

    };
}
