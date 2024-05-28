using TravelSiteWeb.Models;

namespace TravelSiteWeb.ViewModel
{
    public class ReservationViewModel
    {
        public int ReservationsID { get; set; }

        public string ReservationDate { get; set; }
        public string Cost { get; set; }

        public string Contact { get; set; }

        public string Adress { get; set; }
    }
}