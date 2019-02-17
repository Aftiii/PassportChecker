using Microsoft.AspNetCore.Mvc;
using PassportChecker.API.Interfaces;
using PassportChecker.Common.ViewModels;
using PassportChecker.Common.Models;
using PassportChecker.Common.BusinessLogic;
using PassportChecker.Common.BusinessLogic.Interfaces;
using AutoMapper;
using System;

namespace PassportChecker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportValidator : ControllerBase
    {
        private readonly IMzrValidator _mzrValidator;
        private readonly IParseMzrLine2 _parseMzrLine2;
        private readonly IMapper _mapper;
        public PassportValidator(IParseMzrLine2 parseMzrLine2, IMzrValidator mzrValidator, IMapper mapper)
        {
            _mzrValidator = mzrValidator;
            _parseMzrLine2 = parseMzrLine2;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<ValidationResults> Validate([FromBody]PassportInput input)
        {
            //Map view model onto model
            PassportBaseData baseData = _mapper.Map<PassportBaseData>(input);
            
            try
            {
                //Get the mzrline2 string into a manageable object
                MzrLine2 mzrLine2 = _parseMzrLine2.ParseMzrLine2FromString(input.mzrLine2);
                //Check all data on the mzrline2 and whether what the user entered matches the mzrline2
                return _mzrValidator.ValidateMzrAndBaseData(baseData, mzrLine2);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
