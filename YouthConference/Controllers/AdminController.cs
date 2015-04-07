using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using PagedList;
using Telerik.OpenAccess;
using WebMatrix.WebData;
using YouthConference.DataAccess.Services;
using YouthConference.Models;
using YouthConference.Models.ViewModels;

namespace YouthConference.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {

        private readonly UserProfilePersistenceService _userPersistenceService;
        private readonly RegistrantPersistenceService _registrantPersistenceService;
        public AdminController(OpenAccessContext context, UserProfilePersistenceService userPersistenceService, RegistrantPersistenceService registrantPersistenceService) : base(context)
        {
         
            _userPersistenceService = userPersistenceService;
            _registrantPersistenceService = registrantPersistenceService;
        }


        public ActionResult Users()
        {
            return View();
        }

        public ActionResult AllUsers(int page = 0)
        {
            int pageNumber = 1;
            int pageSize = 15;
            if (page > 1)
                pageNumber = page;
         
            var model = _userPersistenceService.AllUsers()
                                               .OrderBy(i => i.UserName)
                                               .ToPagedList(pageNumber, pageSize);
            return View(model);
        }

     


        public ActionResult Registrants(int page = 0)
        {
            var pageNumber = 1;
            const int pageSize = 15;
            if (page > 1)
                pageNumber = page;

            var registrants = _registrantPersistenceService.GetAll().OrderByDescending(I => I.Id).Select(
                I => new RegistrantViewModel()
                    {
                      
                        EmailAddress = I.Email,
                        FullName = I.LastName + " " + I.FirstName,
                        Gender = I.Gender,
                        Id = I.Id,
                        PhoneNumber = I.PhoneNumber,
                        State = I.State,
                        Institution = I.Institution,
                        
                    }).ToPagedList(pageNumber, pageSize);
            ViewBag.MemberCount = _registrantPersistenceService.GetAll().Count();
            return View(registrants);
        }

       

        [ChildActionOnly]
        public PartialViewResult GenderDistribution()
        {
            var model = from i in _registrantPersistenceService.GetAll()
                        group i by new { i.Gender }
                            into grouping
                            select
                                new RegistrantDistributionModel()
                                {
                                    Name = grouping.Key.Gender,
                                    Value = grouping.Count()
                                };
            ViewBag.MemberCount = _registrantPersistenceService.GetAll().Count();
            return PartialView( model.AsEnumerable());
        }

        [ChildActionOnly]
        public PartialViewResult StateDistribution()
        {
            var model = from i in _registrantPersistenceService.GetAll()
                        group i by new { i.State }
                            into grouping
                            select
                                new RegistrantDistributionModel()
                                {
                                    Name = grouping.Key.State,
                                    Value = grouping.Count()
                                };
            ViewBag.MemberCount = _registrantPersistenceService.GetAll().Count();
            return PartialView( model.AsEnumerable());
        }

        public ActionResult Index()
        {
            ViewBag.MemberCount = _registrantPersistenceService.GetAll().Count();
            return View();
        }
    }
}