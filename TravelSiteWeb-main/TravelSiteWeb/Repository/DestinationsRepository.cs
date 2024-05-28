using Microsoft.EntityFrameworkCore;
using TravelSiteWeb.Data;
using TravelSiteWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryUsingEFinMVC.Repository;
using TravelSiteWeb.Data;
using static RepositoryUsingEFinMVC.Repository.DestinationsRepository;

namespace RepositoryUsingEFinMVC.Repository
{
    public class DestinationsRepository : IDestinationsRepository
    {

        private readonly TripContext _context;

        public DestinationsRepository()
        {
            _context = new TripContext();
        }

        public DestinationsRepository(TripContext context)
        {
            _context = context;
        }

        public IEnumerable<Destinations> GetAll()
        {
            return _context.Destinations.ToList();
        }

        public Destinations GetById(int DestinationsID)
        {
            return _context.Destinations.Find(DestinationsID);
        }

        public void Insert(Destinations destinations)
        {

            _context.Destinations.Add(destinations);
        }

        public void Update(Destinations destinations)
        {
            _context.Entry(destinations).State = EntityState.Modified;
        }

        public void Delete(int DestinationsID)
        {

            Destinations destinations = _context.Destinations.Find(DestinationsID);

            if (destinations != null)
            {

                _context.Destinations.Remove(destinations);
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
