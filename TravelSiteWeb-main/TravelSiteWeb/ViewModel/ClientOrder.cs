using TravelSiteWeb.Models;
using RepositoryUsingEFinMVC.Repository;
using TravelSiteWeb.Services;

namespace TravelSiteWeb.ViewModel
{
    public class ClientOrderViewModel
    {
        //Client needed fields
        public int ClientsID { get; set; }
        public string FullName { get; set; }

        public int ReservationID { get; set; }

        public float Cost { get; set; }

        public string Contact { get; set; }

        public string Adress { get; set; }
        public List<ReservationViewModel> Reservations { get; set; }
    }
}
