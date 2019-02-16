using Microsoft.AspNetCore.Mvc;
using PassportChecker.API.Interfaces;
using PassportChecker.Common.ViewModels;

namespace PassportChecker.API.Controllers
{
    [Route("api/[controller]")]
    public class PassportValidator : ControllerBase
    {
        private readonly IPassportValidator _service;
        public PassportValidator(IPassportValidator service)
        {
            _service = service;
        }
        [HttpPost]
        public ActionResult<ValidationResults> Validate(PassportInput input)
        {
            return Ok(new ValidationResults());
        }
    }
}
