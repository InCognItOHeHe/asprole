using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelSiteWeb.Models;

namespace TravelSiteWeb.Models
{
    public class Destinations
    {

        [Key]
        public int DestinationsID { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string TripType { get; set; }

        public virtual ICollection<Reservations> Reservations { get; set; }

        public Destinations()
        {
            Reservations = new HashSet<Reservations>();
        }
    }
}
