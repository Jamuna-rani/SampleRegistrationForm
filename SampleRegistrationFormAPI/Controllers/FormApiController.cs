using Microsoft.AspNetCore.Mvc;
using SampleRegistrationForm.Core.IService;
using SampleRegistrationForm.Core.Model;

namespace SampleRegistrationFormAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FormApiController : Controller
    {
        private readonly IRegistrationService _RegistrationServices;
        public FormApiController(IRegistrationService _RegistrationServices)
        {

            this._RegistrationServices = _RegistrationServices;
        }
        [HttpPost]
        public ActionResult Index(RegistrationModel registration)
        {
            _RegistrationServices.CreateMethod(registration);
            return Ok();
        }
    }
    
}
