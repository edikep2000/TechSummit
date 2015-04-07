using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.OpenAccess;
using YouthConference.Common.ListProducers;
using YouthConference.DataAccess.Services;
using YouthConference.Models;
using YouthConference.Models.ViewModels;

namespace YouthConference.Controllers
{
    public class RegisterController : BaseController
    {
        private readonly GenderListProducer _genderListProducer;
        private readonly RegistrantPersistenceService _registrantPersistenceService;

        public RegisterController(OpenAccessContext context, GenderListProducer genderListProducer, RegistrantPersistenceService registrantPersistenceService) : base(context)
        {
            _genderListProducer = genderListProducer;
            _registrantPersistenceService = registrantPersistenceService;
        }

        public ActionResult Index()
        {
            ViewBag.Gender = _genderListProducer.BuildList();
            ViewBag.State = StateListBuilder.States();
            return View();
        }

        [HttpPost]
        public ActionResult Index(RegistrantViewModel model)
        {
            if (ModelState.IsValid)
            {
                var registrant = new Registrant();
                var names = ParseFullName(model.FullName);
                if (names.Length > 2)
                {
                    registrant.LastName = names[0];
                    registrant.MiddleName = names[1];
                    registrant.FirstName = names[2];
                }
                else if (names.Length > 1)
                {
                    registrant.LastName = names[0];
                    registrant.FirstName = names[1];
                }
                else
                {
                  
                    ViewBag.Gender = _genderListProducer.BuildList();
                    ViewBag.State = StateListBuilder.States();
                    ModelState.AddModelError("", "At the very minimum, a first name and a surname are required");
                    return View();
                }

                if (_registrantPersistenceService.GetUnique(model.EmailAddress, model.PhoneNumber) != null)
                {
                    ViewBag.Gender = _genderListProducer.BuildList();
                    ViewBag.State = StateListBuilder.States();
                    ModelState.AddModelError("",
                                             "Seems like you have already registered. We already have that phone number and or Email address");
                    return View(model);
                }
              
                registrant.Email = model.EmailAddress;
                registrant.PhoneNumber = model.PhoneNumber;
                registrant.Gender = model.Gender;
                registrant.State = model.State;
                registrant.Institution = model.Institution;
                _registrantPersistenceService.Insert(registrant);
                TempData["Message"] = "Thanks for indicating your interest!";
                return RedirectToAction("Index");
            }
            ViewBag.Gender = _genderListProducer.BuildList();
            ViewBag.State = StateListBuilder.States();
            return View(model);
        }

        private String[] ParseFullName(String name)
        {
            var model = name.Split(new char[0]);
            return model;
        }
    }
}
