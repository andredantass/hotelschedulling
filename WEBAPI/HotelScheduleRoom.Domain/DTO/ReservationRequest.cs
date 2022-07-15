using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelScheduleRoom.Domain.DTO
{
    public class ReservationRequest : BaseRequest
    {

        public string Name { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
