using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PassportChecker.API.Controllers;
using PassportChecker.API.Interfaces;
using PassportChecker.API.Tests.FakeServices;
using Xunit;

namespace PassportChecker.API.Tests.Controllers
{
    public class NationalitiesControllerTests_Get
    {
        NationalitiesController _controller;
        INationalitiesService _service;
        public NationalitiesControllerTests_Get()
        {
            _service = new NationalitiesServiceFake();
            _controller = new NationalitiesController(_service);
        }

        [Fact]
        public void GetSelectList_From_Nationlities_Returns_ListOfNationalities()
        {
            //The fake nationalities service only returns 20 nationalities, we're testing the function, not the data
            List<KeyValuePair<int, string>> expectedNationalities = new List<KeyValuePair<int, string>>();
            KeyValuePair<int, string> afghanistan = new KeyValuePair<int, string>(1, "Afghanistan");
            KeyValuePair<int, string> albania = new KeyValuePair<int, string>(2, "Albania");
            KeyValuePair<int, string> algeria = new KeyValuePair<int, string>(3, "Algeria");
            KeyValuePair<int, string> americanSamoa = new KeyValuePair<int, string>(4, "American Samoa");
            KeyValuePair<int, string> andorra = new KeyValuePair<int, string>(5, "Andorra");
            KeyValuePair<int, string> angola = new KeyValuePair<int, string>(6, "Angola");
            KeyValuePair<int, string> anguilla = new KeyValuePair<int, string>(7, "Anguilla");
            KeyValuePair<int, string> antarctica = new KeyValuePair<int, string>(8, "Antarctica");
            KeyValuePair<int, string> antiguaAndBarbuda = new KeyValuePair<int, string>(9, "Antigua and Barbuda");
            KeyValuePair<int, string> argentina = new KeyValuePair<int, string>(10, "Argentina");
            KeyValuePair<int, string> armenia = new KeyValuePair<int, string>(11, "Armenia");
            KeyValuePair<int, string> aruba = new KeyValuePair<int, string>(12, "Aruba");
            KeyValuePair<int, string> australia = new KeyValuePair<int, string>(13, "Australia");
            KeyValuePair<int, string> austria = new KeyValuePair<int, string>(14, "Austria");
            KeyValuePair<int, string> azerbaijan = new KeyValuePair<int, string>(15, "Azerbaijan");
            KeyValuePair<int, string> bahamas = new KeyValuePair<int, string>(16, "Bahamas");
            KeyValuePair<int, string> bahrain = new KeyValuePair<int, string>(17, "Bahrain");
            KeyValuePair<int, string> bangladesh = new KeyValuePair<int, string>(18, "Bangladesh");
            KeyValuePair<int, string> barbados = new KeyValuePair<int, string>(19, "Barbados");
            KeyValuePair<int, string> belarus = new KeyValuePair<int, string>(20, "Belarus");
            expectedNationalities.Add(afghanistan);
            expectedNationalities.Add(albania);
            expectedNationalities.Add(algeria);
            expectedNationalities.Add(americanSamoa);
            expectedNationalities.Add(andorra);
            expectedNationalities.Add(angola);
            expectedNationalities.Add(anguilla);
            expectedNationalities.Add(antarctica);
            expectedNationalities.Add(antiguaAndBarbuda);
            expectedNationalities.Add(argentina);
            expectedNationalities.Add(armenia);
            expectedNationalities.Add(aruba);
            expectedNationalities.Add(australia);
            expectedNationalities.Add(austria);
            expectedNationalities.Add(azerbaijan);
            expectedNationalities.Add(bahamas);
            expectedNationalities.Add(bahrain);
            expectedNationalities.Add(bangladesh);
            expectedNationalities.Add(barbados);
            expectedNationalities.Add(belarus);

            var okResult = _controller.Get().Result as OkObjectResult;

            var returnedNationalities = Assert.IsType<List<KeyValuePair<int, string>>>(okResult.Value);
            Assert.Equal(expectedNationalities, returnedNationalities);
        }
    }
}
