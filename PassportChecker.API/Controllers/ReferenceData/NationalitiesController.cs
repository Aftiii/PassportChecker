using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PassportChecker.API.Interfaces;

namespace PassportChecker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalitiesController : ControllerBase
    {
        private readonly INationalitiesService _service;

        public NationalitiesController(INationalitiesService service)
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
