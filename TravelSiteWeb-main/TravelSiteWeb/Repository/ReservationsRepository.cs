using Microsoft.EntityFrameworkCore;
using TravelSiteWeb.Data;
using TravelSiteWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryUsingEFinMVC.Repository;
using TravelSiteWeb.Data;
using static RepositoryUsingEFinMVC.Repository.ReservationsRepository;

namespace RepositoryUsingEFinMVC.Repository
{
    public class ReservationsRepository : IReservationsRepository
    {

        private readonly TripContext _context;

        public ReservationsRepository()
        {
            _context = new TripContext();
        }

        public ReservationsRepository(TripContext context)
        {
            _context = context;
        }

        public IQueryable<Reservations> GetAll()
        {
            return _context.Reservations.AsQueryable();
        }

        public Reservations GetById(int ReservationsID)
        {
            return _context.Reservations.Find(ReservationsID);
        }

        public void Insert(Reservations reservations)
        {

            _context.Reservations.Add(reservations);
        }

        public void Update(Reservations reservations)
        {
            _context.Entry(reservations).State = EntityState.Modified;
        }

        public void Delete(int ReservationsID)
        {

            Reservations reservations = _context.Reservations.Find(ReservationsID);

            if (reservations != null)
            {

                _context.Reservations.Remove(reservations);
            }

        }

        public void Save()
        {

            _context.SaveChanges();
        }
        private bool disposed = false;


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
