using System;
using System.Collections.Generic;
using System.Text;
using PassportChecker.API.Interfaces;

namespace PassportChecker.API.Tests.FakeServices
{
    public class GendersServiceFake : IGendersService
    {
        private readonly List<KeyValuePair<int, string>> _genders;

        public GendersServiceFake()
        {
            _genders = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1, "Non-specified"),
                new KeyValuePair<int, string>(2, "Male"),
                new KeyValuePair<int, string>(4, "Female")
            };
        }

        public List<KeyValuePair<int, string>> Get()
        {
            return _genders;
        }
    }
}
