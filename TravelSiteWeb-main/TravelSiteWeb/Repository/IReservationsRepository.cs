using TravelSiteWeb.Models;
using System.Collections.Generic;
using System;
namespace RepositoryUsingEFinMVC.Repository
{
    public interface IReservationsRepository
    {
        IQueryable<Reservations> GetAll();
        Reservations GetById(int ReservationsID);
        void Insert(Reservations reservations);
        void Update(Reservations reservations);
        void Delete(int ReservationsID);
        void Save();
    }
}