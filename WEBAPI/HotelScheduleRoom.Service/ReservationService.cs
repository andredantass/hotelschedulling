using HotelScheduleRoom.Domain.DTO;
using HotelScheduleRoom.Domain.Entity;
using HotelScheduleRoom.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelScheduleRoom.Service
{
    public class ReservationService : BaseReservationService, IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<int> Delete(int id)
        {
            return await _reservationRepository.Delete(id);
        }

        public async Task<ReservationEnt> Get(int id)
        {
            return await _reservationRepository.Get((x) => x.id == id);
        }

        public async Task<List<ReservationEnt>> GetAll()
        {
            return await _reservationRepository.GetAll();
        }

        public async Task<string> Insert(ReservationRequest obj)
        {

            var result = ReservationMsg.None;

            result = VerifyReservationRules(obj);

            if (result != ReservationMsg.None)
                return Util.TreatReturnMsg(result);


            if (!VerifyRoomAvailability(obj))
            {
                return Util.TreatReturnMsg(ReservationMsg.NotAvailable);
            }


            var reservationEnt = new ReservationEnt
            {
                BeginDate = obj.BeginDate.Date,
                EndDate = obj.EndDate.Date,
                Name = obj.Name
            };
            await _reservationRepository.Insert(reservationEnt);
            return "";
        }

        public async Task<string> Update(ReservationRequest obj)
        {
            var result = ReservationMsg.None;

            if (!VerifyRoomAvailability(obj))
            {
                return Util.TreatReturnMsg(ReservationMsg.NotAvailable);
            }
            result = VerifyReservationRules(obj);

            if (result != ReservationMsg.None)
                return Util.TreatReturnMsg(result);


            var reservationEnt = new ReservationEnt
            {
                id = obj.id,
                BeginDate = obj.BeginDate.Date,
                EndDate = obj.EndDate.Date,
                Name = obj.Name
            };
            await _reservationRepository.Update(reservationEnt);
            return "";
        }
        private bool VerifyRoomAvailability(ReservationRequest obj)
        {
            IEnumerable<ReservationEnt> lstReservation;

            if (obj.id != -1)
                lstReservation = GetAll().Result.Where(x => !x.id.Equals(obj.id));
            else
                lstReservation = GetAll().Result.ToArray();

            var firstVerify = lstReservation.Where(x => obj.BeginDate.Date <= x.EndDate && obj.BeginDate.Date >= x.BeginDate.Date);
            var secondVerify = lstReservation.Where(x => obj.EndDate.Date <= x.EndDate && obj.EndDate.Date >= x.BeginDate.Date);
            var thirdVerify = lstReservation.Where(x => x.BeginDate.Date >= obj.BeginDate.Date && x.EndDate.Date <= obj.EndDate.Date);

            return firstVerify.ToArray().Count() == 0 && 
                   secondVerify.ToArray().Count() == 0 &&
                   thirdVerify.ToArray().Count() == 0 
                   ? true : false;
        }

    }
}
