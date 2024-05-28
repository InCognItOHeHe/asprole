using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelSiteWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryUsingEFinMVC.Repository;
using TravelSiteWeb.Data;
using static RepositoryUsingEFinMVC.Repository.ReservationsRepository;
using TravelSiteWeb;
using TravelSiteWeb.Services;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;
using Microsoft.AspNetCore.Authorization;

namespace RepositoryUsingEFinMVC.Controllers
{
    public class ReservationsController : Controller
    {

        private IReservationsRepository _reservationsRepository;
        private readonly IPaginatedListService _paginatedListService;
        private readonly IValidator<Reservations> _validator;
        

        public ReservationsController(IReservationsRepository reservationsRepository,IPaginatedListService paginatedListService, IValidator<Reservations> validator)
        {
            _reservationsRepository = reservationsRepository;
            _paginatedListService = paginatedListService;
            _validator = validator;
        }

        [HttpGet]
        [Authorize(Roles = "Employee , Admin")]
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

            var reservations = _reservationsRepository.GetAll();

            if (!String.IsNullOrEmpty(searchString))
            {
                reservations = reservations.Where(r => r.Cost.Contains(searchString)
                                       || r.ReservationDate.Contains(searchString));
            }



            int pageSize = 3; // Number of items per page
            int pageIndex = pageNumber ?? 1; // Current page number
            var paginatedList = await _paginatedListService.CreateAsync(reservations, pageIndex, pageSize);
            return View(paginatedList);
        }

        [HttpGet]
        [Authorize(Roles = "Employee , Admin")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(Reservations model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);

            if (result.IsValid)
            {
                _reservationsRepository.Insert(model);
                _reservationsRepository.Save();

                return RedirectToAction("Index", "Reservations");
            }
            else
            {
                // Jeśli walidacja nie powiodła się, przekaż błędy do widoku
                ModelState.AddModelError("", result.Errors.ToString());
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Employee , Admin")]
        public ActionResult EditReservations(int ReservationsID)
        {

            Reservations model = _reservationsRepository.GetById(ReservationsID);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditReservation(Reservations model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);
            //First Check whether the Model State is Valid or not
            if (result.IsValid)
            {
                //If Valid, then call the Update Method of EmployeeRepository  to make the Entity State Modified
                _reservationsRepository.Update(model);

                //To make the changes permanent in the database, call the Save method of EmployeeRepository
                _reservationsRepository.Save();
                //Once the updated data is saved into the database, redirect to the Index View
                return RedirectToAction("Index", "Reservation");
            }
            else
            {
                //If the Model State is invalid, then stay on the same view
                return View(model);
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteReservation(int ReservationsID)
        {

            Reservations model = _reservationsRepository.GetById(ReservationsID);

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int ReservationsID)
        {
            _reservationsRepository.Delete(ReservationsID);
            _reservationsRepository.Save();
            return RedirectToAction("Index", "Reservations");
        }
    }
}