using FluentValidation;
using TravelSiteWeb.Models;
using RepositoryUsingEFinMVC.Repository;
using System;

//Custom Validation for Client

namespace TravelSiteWeb.Services
{
    public class TravelDestinationValidator : AbstractValidator<Destinations>
    {
        public TravelDestinationValidator()
        {
            RuleFor(x => x.Country).NotNull();
            RuleFor(x => x.City).NotNull();
            RuleFor(x => x.TripType).NotEmpty().Length(20, 255);
        }

    }
}
