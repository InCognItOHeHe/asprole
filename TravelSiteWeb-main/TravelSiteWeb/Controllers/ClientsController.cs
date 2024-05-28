using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelSiteWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryUsingEFinMVC.Repository;
using TravelSiteWeb.Data;

using static RepositoryUsingEFinMVC.Repository.ClientsRepository;
using TravelSiteWeb;
using TravelSiteWeb.Services;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace RepositoryUsingEFinMVC.Controllers
{

    [Authorize(Roles = "Employee , Admin")]
    public class ClientsController : Controller
    {

        private IClientsRepository _clientsRepository;
        private readonly IPaginatedListService _paginatedListService;
        private readonly MappingService _mappingService;
        private readonly IValidator<Clients> _validator;


        public ClientsController(IClientsRepository clientsRepository, IPaginatedListService paginatedListService, MappingService mappingService, IValidator<Clients> validator)
        {
            _clientsRepository = clientsRepository;
            _paginatedListService = paginatedListService;
            _mappingService = mappingService;
            _validator = validator;
        }



        [HttpGet]
        
        public async Task<IActionResult> Index(string currentFilter, string searchString, int? pageNumber)
        {


            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var clients = _clientsRepository.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                clients = clients.Where(c => c.LastName.Contains(searchString)
                                       || c.FirstName.Contains(searchString));
            }



            int pageSize = 3; // Number of items per page
            int pageIndex = pageNumber ?? 1; // Current page number
            var paginatedList = await _paginatedListService.CreateAsync(clients, pageIndex, pageSize);
            return View(paginatedList);
        }

        [HttpGet]
        public ActionResult ClientView([FromServices] TripContext context)
        {
            var clientsViewModels = _mappingService.GetClientView(context);
            return View(clientsViewModels);
        }

        [HttpGet]
        [Authorize(Roles = "Employee , Admin")]
        // [ValidateAntiForgeryToken]
        public ActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddClient(Clients model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);
            if (result.IsValid)
            {
                _clientsRepository.Insert(model);
                _clientsRepository.Save();
                return RedirectToAction("Index", "Clients");
            }
            else
            {

                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Employee , Admin")]
        //[ValidateAntiForgeryToken]
        public ActionResult EditClient(int ClientsID)
        {

            Clients model = _clientsRepository.GetById(ClientsID);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditClient(Clients model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);

            if (result.IsValid)
            {
                _clientsRepository.Update(model);
                _clientsRepository.Save();
                return RedirectToAction("Index", "Clients");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        [Authorize (Roles = "Admin")]
            
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteClient(int ClientsID)
        {

            Clients model = _clientsRepository.GetById(ClientsID);

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int ClientsID)
        {
            _clientsRepository.Delete(ClientsID);
            _clientsRepository.Save();

            return RedirectToAction("Index", "Clients");
        }
    }
}