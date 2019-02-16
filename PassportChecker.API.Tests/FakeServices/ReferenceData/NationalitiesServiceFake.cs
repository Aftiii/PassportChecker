using System;
using System.Collections.Generic;
using System.Text;
using PassportChecker.API.Interfaces;
using PassportChecker.Common.Enums;
using PassportChecker.Common.Helpers;

namespace PassportChecker.API.Tests.FakeServices
{
    public class NationalitiesServiceFake : INationalitiesService
    {
        public List<KeyValuePair<int, string>> Get()
        {
            List<KeyValuePair<int, string>> nationalities = EnumHelper.GetSelectList(typeof(Nationality));
            //Return the first 20, we're testing the function, not the data
            return nationalities.GetRange(0, 20);
        }
    }
}
