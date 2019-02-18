using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using PassportChecker.API.Controllers;
using PassportChecker.API.Interfaces;
using PassportChecker.API.Tests.FakeServices;
using PassportChecker.Common.BusinessLogic.Interfaces;
using PassportChecker.Common.Models;
using PassportChecker.Common.ViewModels;
using PassportChecker.Common.Enums;
using PassportChecker.API.Services;
using PassportChecker.Common.BusinessLogic;
using Xunit;
using Moq;
using AutoMapper;
using PassportChecker.API.Utility;

namespace PassportChecker.API.Tests.Controllers.ValidatePassport
{
    
    public class PassportValidatorTests_Validate
    {

        [Fact]
        public void Validate_Valid_Passport_Returns_Validated_Results()
        {
            var mockMrzParse = new Mock<IParseMrzLine2>();
            var mockMrzValidator = new Mock<IMrzValidator>();
            //We need to mock the IMapper, use the existing profile and pass this in
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();
            PassportValidator controller = new PassportValidator(mockMrzParse.Object, mockMrzValidator.Object, mapper);

            PassportInput passportInput = new PassportInput()
            {
                PassportNumber = "112256503",
                Nationality = Nationality.GBR,
                DateOfBirth = new DateTime(1989, 02, 12),
                Gender = Gender.M,
                DateOfExpiry = new DateTime(2020, 10, 01),
                MrzLine2 = "1122565035GBR8902122M2010016<<<<<<<<<<<<<<04"
            };
            MrzLine2 fakeMrzLine2 = new MrzLine2()
            {
                PassportNumber = "112256503",
                CheckDigitPassportNumber = "5",
                Nationality = Nationality.GBR,
                DateOfBirth = new DateTime(1989,02,12),
                CheckDigitDateOfBirth = "2",
                Gender = Gender.M,
                DateOfExpiry = new DateTime(2020,10,01),
                CheckDigitDateOfExpiry = "6",
                PersonalNumber = "",
                CheckDigitPersonalNumber = "0",
                CheckDigitOverall = "4"
            };
            ValidationResults expectedValidationResults = new ValidationResults()
            {
                PassportNumberCheckDigit = true,
                DateOfBirthCheckDigit = true,
                PassportExpirationDateCheckDigit = true,
                PersonalNumberCheckDigit = true,
                FinalCheckDigit = true,
                GenderCrossCheck = true,
                DateOfBirthCrossCheck = true,
                ExpirationDateCrossCheck = true,
                NationalityCrossCheck = true,
                PassportNumberCrossCheck = true
            };
            mockMrzParse.Setup(x => x.ParseMrzLine2FromString(It.IsAny<string>())).Returns(fakeMrzLine2);
            mockMrzValidator.Setup(x => x.ValidateMrzAndBaseData(It.IsAny<PassportBaseData>(), It.IsAny<MrzLine2>())).Returns(expectedValidationResults);

            ValidationResults returnedValidationResults = controller.Validate(passportInput).Value;

            Assert.Equal(expectedValidationResults, returnedValidationResults);
        }
    }
}
