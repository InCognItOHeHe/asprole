using Microsoft.EntityFrameworkCore;
using TravelSiteWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryUsingEFinMVC.Repository;
using TravelSiteWeb.Data;
using static RepositoryUsingEFinMVC.Repository.ClientsRepository;

namespace RepositoryUsingEFinMVC.Repository
{
    public class ClientsRepository : IClientsRepository
    {

        private readonly TripContext _context;

        public ClientsRepository()
        {
            _context = new TripContext();
        }

        public ClientsRepository(TripContext context)
        {
            _context = context;
        }

        public IQueryable<Clients> GetAll()
        {
            return _context.Clients.AsQueryable();
        }

        public Clients GetById(int ClientsID)
        {
            return _context.Clients.Find(ClientsID);
        }

        public void Insert(Clients clients)
        {

            _context.Clients.Add(clients);
        }

        public void Update(Clients clients)
        {
            _context.Entry(clients).State = EntityState.Modified;
        }

        public void Delete(int ClientsID)
        {

            Clients clients = _context.Clients.Find(ClientsID);

            if (clients != null)
            {

                _context.Clients.Remove(clients);
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