using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using PassportChecker.API.Controllers;
using PassportChecker.API.Interfaces;
using PassportChecker.API.Tests.FakeServices;
using Xunit;

namespace PassportChecker.API.Tests.Controllers
{
    public class GendersControllerTests_Get
    {
        GendersController _controller;
        IGendersService _service;
        public GendersControllerTests_Get()
        {
            _service = new GendersServiceFake();
            _controller = new GendersController(_service);
        }

        [Fact]
        public void GetSelectList_From_Genders_Returns_ListOfGenders()
        {
            List<KeyValuePair<int, string>> expectedGenders = new List<KeyValuePair<int, string>>();
            KeyValuePair<int, string> nonSpecified = new KeyValuePair<int, string>(1, "Non-specified");
            KeyValuePair<int, string> male = new KeyValuePair<int, string>(2, "Male");
            KeyValuePair<int, string> female = new KeyValuePair<int, string>(4, "Female");
            expectedGenders.Add(nonSpecified);
            expectedGenders.Add(male);
            expectedGenders.Add(female);

            var okResult = _controller.Get().Result as OkObjectResult;

            var returnedGenders = Assert.IsType<List<KeyValuePair<int,string>>>(okResult.Value);
            Assert.Equal(expectedGenders, returnedGenders);
        }
    }
}
