using TravelSiteWeb.Models;
using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;


namespace TravelSiteWeb.Data
{
    public class DBInnit
    {
        public static void Initialize(TripContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Clients.Any())
            {
                return;   // DB has been seeded
            }

            var client = new Clients[]
            {
                  new Clients{LastName="Kovalsky",FirstName="Olek",FirstTrip="01.03.2021"},
                  new Clients{LastName="Spalski",FirstName="Bolek",FirstTrip="05.08.2021"},
                  new Clients{LastName="Kaczmarek",FirstName="Adam",FirstTrip="05.07.2019"},
                  new Clients{LastName="Baran",FirstName="Marcin",FirstTrip="Brak"},


            };
            foreach (Clients c in client)
            {
                context.Clients.Add(c);
            }
            context.SaveChanges();

            var destination = new Destinations[]
            {
            new Destinations{DestinationsID=1,Country="Venesuela",City="Caracas",TripType="Standard"},
            new Destinations{DestinationsID=2,City="Manila",Country="Philippines",TripType = "Standard"},
            new Destinations{DestinationsID=3,City="Angeles",Country="Philippines",TripType = "Standard"},
            new Destinations{DestinationsID=4,City="San Antonio",Country="Philippines",TripType = "Standard"},
            new Destinations{DestinationsID=5,City="Angeles",Country="Philippines",TripType = "Standard"},
            new Destinations{DestinationsID=6,City="Puerto Princessa",Country="Philippines",TripType = "Standard"},

            };
            foreach (Destinations d in destination)
            {
                context.Destinations.Add(d);
            }
            context.SaveChanges();

            var reservation = new Reservations[]
            {
            new Reservations{DestinationsID=1,ClientsID=1,ReservationDate="07.03.2024",Cost = "1200", Contact = "777-777-777", Adress="Michałowicza 17,Bielsko-Biała"},

            };
            foreach (Reservations r in reservation)
            {
                context.Reservations.Add(r);
            }
            context.SaveChanges();
        }


    }

}

