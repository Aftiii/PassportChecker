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
            var mockMzrParse = new Mock<IParseMzrLine2>();
            var mockMzrValidator = new Mock<IMzrValidator>();
            //We need to mock the IMapper, use the existing profile and pass this in
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();
            PassportValidator controller = new PassportValidator(mockMzrParse.Object, mockMzrValidator.Object, mapper);

            PassportInput passportInput = new PassportInput()
            {
                PassportNumber = "112256503",
                Nationality = Nationality.GBR,
                DateOfBirth = new DateTime(1989, 02, 12),
                Gender = Gender.M,
                DateOfExpiry = new DateTime(2020, 10, 01),
                mzrLine2 = "1122565035GBR8902122M2010016<<<<<<<<<<<<<<04"
            };
            MzrLine2 fakeMzrLine2 = new MzrLine2()
            {
                PassportNumber = "112256503",
                CheckDigitPassportNumber = '5',
                Nationality = Nationality.GBR,
                DateOfBirth = new DateTime(1989,02,12),
                CheckDigitDateOfBirth = '2',
                Gender = Gender.M,
                DateOfExpiry = new DateTime(2020,10,01),
                CheckDigitDateOfExpiry = '6',
                PersonalNumber = "",
                CheckDigitPersonalNumber = '0',
                CheckDigitOverall = '4'
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
            mockMzrParse.Setup(x => x.ParseMzrLine2FromString(It.IsAny<string>())).Returns(fakeMzrLine2);
            mockMzrValidator.Setup(x => x.ValidateMzrAndBaseData(It.IsAny<PassportBaseData>(), It.IsAny<MzrLine2>())).Returns(expectedValidationResults);

            ValidationResults returnedValidationResults = controller.Validate(passportInput).Value;

            Assert.Equal(expectedValidationResults, returnedValidationResults);
        }
    }
}
