using TravelSiteWeb.Models;
using System.Collections.Generic;
using System;
namespace RepositoryUsingEFinMVC.Repository
{
    public interface IDestinationsRepository
    {
        IEnumerable<Destinations> GetAll();
        Destinations GetById(int DestinationsID);
        void Insert(Destinations destinations);
        void Update(Destinations destinations);
        void Delete(int DestinationsID);
        void Save();
    }
}