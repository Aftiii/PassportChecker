using Microsoft.AspNetCore.Mvc;
using PassportChecker.Common.ViewModels;
using PassportChecker.Common.Models;
using PassportChecker.Common.BusinessLogic.Interfaces;
using AutoMapper;
using System;

namespace PassportChecker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportValidator : ControllerBase
    {
        //Make this controller mockable
        private readonly IMrzValidator _mrzValidator;
        private readonly IParseMrzLine2 _parsemrzLine2;
        private readonly IMapper _mapper;
        public PassportValidator(IParseMrzLine2 parseMrzLine2, IMrzValidator MrzValidator, IMapper mapper)
        {
            _mrzValidator = MrzValidator;
            _parsemrzLine2 = parseMrzLine2;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<ValidationResults> Validate([FromBody]PassportInput input)
        {
            //Map view model onto model
            PassportBaseData baseData = _mapper.Map<PassportBaseData>(input);
            
            try
            {
                //Get the Mrzline2 string into a manageable object
                MrzLine2 mrzLine2 = _parsemrzLine2.ParseMrzLine2FromString(input.MrzLine2);
                //Check all data on the mrzline2 and whether what the user entered matches the mrzline2
                return _mrzValidator.ValidateMrzAndBaseData(baseData, mrzLine2);
            }
            catch(Exception e)
            {
                //Always return a bad status code with the exception to the view
                return BadRequest(e);
            }
        }
    }
}
