using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermPaper
{
    internal class BaseField
    {

        public int ClientsID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOFBrith { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Passport { get; set; }

        public int RoomsId { get; set; }

        public string Number { get; set; }

        public int Floor { get; set; }

        public string Type { get; set; }

        public int Capcfcity { get; set; }

        public string Status { get; set; }

        public string Price { get; set; }


        public int ReservationsId { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }
        public string TypePayment { get; set; }

      



    }
}
