using FluentValidation;
using TravelSiteWeb.Models;
using RepositoryUsingEFinMVC.Repository;

//Custom Validation for Client

namespace TravelSiteWeb.Services
{
    public class ClientValidator : AbstractValidator<Clients>
    {
        public ClientValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Field cannot be empty");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Field cannot be empty");
            RuleFor(x => x.FirstTrip).Length(0, 50).NotEmpty().WithMessage("Field cannot be empty"); ;
        }
    }
}
