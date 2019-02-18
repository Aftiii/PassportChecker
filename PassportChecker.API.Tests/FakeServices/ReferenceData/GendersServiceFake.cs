using System.Collections.Generic;
using PassportChecker.API.Interfaces;
using PassportChecker.Common.Helpers;
using PassportChecker.Common.Enums;

namespace PassportChecker.API.Tests.FakeServices
{
    public class GendersServiceFake : IGendersService
    {
        public List<KeyValuePair<int, string>> Get()
        {
            /*Although this is fake service, let's return the object anyway, it's in memory
            if this was a database request then we'd look to return this as a series of elements instead of doing a round trip*/
            return EnumHelper.GetSelectList(typeof(Gender));
        }
    }
}
