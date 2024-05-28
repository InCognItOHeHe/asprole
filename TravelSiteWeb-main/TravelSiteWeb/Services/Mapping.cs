using Mapster;
using TravelSiteWeb.ViewModel;
using TravelSiteWeb.Models;
using TravelSiteWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace TravelSiteWeb.Services
{
    public class MappingService
    {
        public void ConfigureMapping()
        {
            //Maping for ClientViewModel
            TypeAdapterConfig<Clients, ClientViewModel>.NewConfig()
                .Map(dest => dest.ClientsID, src => src.ClientsID)
                //Combine 2 fields for viewmodel
                .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}")
                .Map(dest => dest.FirstTrip, src => src.FirstTrip);
            //Mapping for ReservationViewModel
            TypeAdapterConfig<Reservations, ReservationViewModel>.NewConfig()
                .Map(dest => dest.ReservationsID, src => src.ReservationsID)
                .Map(dest => dest.ReservationDate, src => src.ReservationDate)
                .Map(dest => dest.Cost, src => src.Cost)
                .Map(dest => dest.Contact, src => src.Contact)
                .Map(dest => dest.Adress, src => src.Adress);
            //Mapping for ClientOrderViewModel
            TypeAdapterConfig<Clients, ClientOrderViewModel>.NewConfig()
                .Map(dest => dest.ClientsID, src => src.ClientsID)
                .Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}");
            TypeAdapterConfig<Reservations, ClientOrderViewModel>.NewConfig()
                .Map(dest => dest.ReservationID, src => src.ReservationsID)
                .Map(dest => dest.Contact, src => src.Contact)
                .Map(dest => dest.Cost, src => src.Cost)
                .Map(dest => dest.Adress, src => src.Adress);
        }
        public List<ClientOrderViewModel> GetClientOrderViewModels(TripContext context)
        {
            //Get all clients from db
            var allClients = context.Clients.ToList();
            //Get all reservations from db
            var allReservations = context.Reservations.ToList();



            //Mapping client and reservation data to viewModel
            var clientOrderViewModels = new List<ClientOrderViewModel>();

            foreach (var client in allClients)
            {
                var clientOrderViewModel = client.Adapt<ClientOrderViewModel>();
                var reservationsForClient = allReservations.Where(r => r.ClientsID == client.ClientsID).ToList();
                clientOrderViewModel.Reservations = reservationsForClient.Adapt<List<ReservationViewModel>>();
                clientOrderViewModels.Add(clientOrderViewModel);
            }
            return clientOrderViewModels;

        }
        public List<ClientViewModel> GetClientView(TripContext context)
        {
            var allClients = context.Clients.ToList();
            var clientsViewModels = new List<ClientViewModel>();

            foreach (var client in allClients)
            {
                var clientsViewModel = client.Adapt<ClientViewModel>();
                clientsViewModels.Add(clientsViewModel);
            }
            return clientsViewModels;
        }
    }

}
