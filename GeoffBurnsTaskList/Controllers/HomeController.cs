using System;
using System.Web.Mvc;
using GeoffBurnsTaskList.Models;

namespace GeoffBurnsTaskList.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProfileListModel _taskList;
        private readonly IRepository<Profile> _repository;

        public HomeController(IRepository<Profile> repository, IProfileListModel ProfileListModel)
        {
            _taskList = ProfileListModel;
            _repository = repository;
        }

  
        public ActionResult Index()
        {
            return View(_taskList); 
        }
        public ActionResult DeleteAll()
        {
            _repository.DeleteAll();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View(new Profile());
        }

        [HttpPost]
        public ViewResult Create(Profile Profile)
        {
            if(Profile == null)
                Profile = new Profile();
            if (!TryUpdateModel(Profile))
            {
                ViewBag.updateError = "Create Failure";
                ModelState.AddModelError("Create Failure","Could not update Task");
                return View(Profile);
            }
            try
            {
                _repository.Create(Profile);
                ModelState.Clear();
                return View("Create", new Profile());
            }
            catch (Exception ex)
            {
                    ViewBag.updateError = ex.Message;
                    ModelState.AddModelError("Create Failure", ex);
                    return View(Profile);    
            }
        }
  
    }
}
