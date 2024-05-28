using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelSiteWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RepositoryUsingEFinMVC.Repository;
using TravelSiteWeb.Data;
using static RepositoryUsingEFinMVC.Repository.DestinationsRepository;
using Microsoft.AspNetCore.Authorization;

namespace RepositoryUsingEFinMVC.Controllers
{
    public class DestinationsController : Controller
    {

        private IDestinationsRepository _destinationsRepository;
        private  TripContext _tripContext;

        public DestinationsController(TripContext tripContext, IDestinationsRepository DestinationsRepository)
        {
            _destinationsRepository = DestinationsRepository;
            _tripContext = tripContext;
        }
        [Authorize(Roles = "Employee , Admin")]
        [HttpGet]
        public ActionResult Index()
        {

            var model = _destinationsRepository.GetAll();
            return View(model);
        }

        
        [HttpGet]
        [Authorize(Roles = "Employee , Admin")]
        public ActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDestination(Destinations model)
        {

            if (ModelState.IsValid)
            {

                _destinationsRepository.Insert(model);

                _destinationsRepository.Save();

                return RedirectToAction("Index", "Destinations");
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Employee , Admin")]
        public ActionResult EditDestination(int DestinationsID)
        {

            Destinations model = _destinationsRepository.GetById(DestinationsID);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditDestination(Destinations model)
        {

            if (ModelState.IsValid)
            {

                _destinationsRepository.Update(model);

                _destinationsRepository.Save();

                return RedirectToAction("Index", "Destinations");
            }
            else
            {

                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteDestination(int DestinationsID)
        {

            Destinations model = _destinationsRepository.GetById(DestinationsID);

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int DestinationsID)
        {
            _destinationsRepository.Delete(DestinationsID);
            _destinationsRepository.Save();
            return RedirectToAction("Index", "Destinations");
        }
    }
}