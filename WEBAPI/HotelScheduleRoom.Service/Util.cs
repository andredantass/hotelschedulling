using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelScheduleRoom.Service
{
    public static class Util
    {
        public static string TreatReturnMsg(ReservationMsg option)
        {
            switch(option)
            {
                case ReservationMsg.MoreThan3Days:
                    return "The reservation can´t be more than 3 days";
                case ReservationMsg.NotAfterToday:
                    return "The reservation can´t start today";
                case ReservationMsg.StartReservationMore30DaysAdvance:
                    return "The reservation can´t start 30 days advance";
                case ReservationMsg.NotAvailable:
                    return "The reservation can´t be made. Other guest already scheduled this date";
                case ReservationMsg.StartDateNotMoreEndDate:
                    return "The start date can´t be higher then end date";
                case ReservationMsg.RetroactiveDateNotAllow:
                    return "The Dates can´t be in the past";
                default:
                    return "";
            }
        }
    }
}
