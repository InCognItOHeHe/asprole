using TravelSiteWeb.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace RepositoryUsingEFinMVC.Repository
{
    public interface IClientsRepository
    {
        IQueryable<Clients> GetAll();
        Clients GetById(int ClientsID);
        void Insert(Clients clients);
        void Update(Clients clients);
        void Delete(int ID);
        void Save();
    }
}