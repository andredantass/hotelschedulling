using HotelScheduleRoom.Domain.DTO;
using System;

namespace HotelScheduleRoom.Service
{
    public abstract class BaseReservationService
    {

        protected ReservationMsg VerifyReservationRules(ReservationRequest obj)
        {
            
            if (obj.BeginDate.Date < DateTime.Now.Date || obj.EndDate.Date < DateTime.Now.Date)
                return ReservationMsg.RetroactiveDateNotAllow;
            if (obj.EndDate.Date < obj.BeginDate.Date)
                return ReservationMsg.StartDateNotMoreEndDate;
            if (obj.EndDate.Subtract(obj.BeginDate).Days > 3)
                return ReservationMsg.MoreThan3Days;
            if ((DateTime.Now.Subtract(obj.BeginDate).Days * -1) > 30)
                return ReservationMsg.StartReservationMore30DaysAdvance;
            if (obj.BeginDate.Date == DateTime.Now.Date)
                return ReservationMsg.NotAfterToday;


            return ReservationMsg.None;
        }
    }
}