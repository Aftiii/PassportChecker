using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PassportChecker.API.Interfaces;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PassportChecker.API.Controllers
{

    [Route("api/[controller]")]
    //[EnableCors(]
    public class GendersController : ControllerBase
    {

        private readonly IGendersService _service;

        public GendersController(IGendersService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<KeyValuePair<int, string>>> Get()
        {
            var items = _service.Get();
            return Ok(items);
        }
    }
}
