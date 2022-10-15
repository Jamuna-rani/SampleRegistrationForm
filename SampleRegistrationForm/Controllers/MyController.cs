using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SampleRegistrationForm.Core.IService;
using SampleRegistrationForm.Core.Model;
using SampleRegistrationForm.Entity;
using SampleRegistrationForm.Services;

namespace SampleRegistrationForm.Controllers
{
    public class MyController : Controller
    {
        private readonly IRegistrationService _RegistrationServices;
        public MyController(IRegistrationService _RegistrationServices)
        {

            this._RegistrationServices = _RegistrationServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region List
        public IActionResult ListForm()
        {
            var value = _RegistrationServices.ListMethod();
            return View(value);
        }
        #endregion

        #region create
        [HttpGet]
        public IActionResult CreateForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateForm(RegistrationModel registration)
        {
            _RegistrationServices.CreateMethod(registration);
            return RedirectToAction("ListForm");
        }
        #endregion


        #region Edit
        [HttpGet]
        public IActionResult EditForm(int userid)
        {
            var value = _RegistrationServices.EditMethod(userid);
            return View("CreateForm", value);
        }
        //[HttpPost]
        //public IActionResult EditForm(RegistrationModel registration)
        //{
        //    _RegistrationServices.EditMethod(registration);
        //    return RedirectToAction("ListForm");
        //}
        #endregion


        #region Delete

        public IActionResult DeleteForm(int userid)
        {
            _RegistrationServices.DeleteMethod(userid);

            return RedirectToAction("ListForm");
        }
        #endregion
    }
}
