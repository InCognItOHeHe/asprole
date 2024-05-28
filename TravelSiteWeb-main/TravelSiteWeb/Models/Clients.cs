using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TravelSiteWeb.Models;

namespace TravelSiteWeb.Models
{
    public class Clients
    {
        [Key]
        public int ClientsID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FirstTrip { get; set; }

        public ICollection<Reservations> Reservations { get; set; }

        public Clients()
        {
            Reservations = new HashSet<Reservations>();
        }

    }
}
