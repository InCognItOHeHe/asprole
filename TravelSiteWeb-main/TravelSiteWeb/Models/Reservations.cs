using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelSiteWeb.Models;

namespace TravelSiteWeb.Models
{
    public class Reservations
    {
        [Key]
        public int ReservationsID { get; set; }

        public string ReservationDate { get; set; }

        public int ClientsID { get; set; }

        public int DestinationsID { get; set; }

        public string Cost { get; set; }

        public string Contact { get; set; }

        public string Adress { get; set; }

        public virtual Clients? Clients { get; set; }

        public virtual Destinations? Destinations { get; set; }


    }
}