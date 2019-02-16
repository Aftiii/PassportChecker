﻿using System.Collections.Generic;
using PassportChecker.API.Interfaces;
using PassportChecker.Common.Helpers;
using PassportChecker.Common.Enums;

namespace PassportChecker.API.Services
{
    public class NationalitiesService : INationalitiesService
    {
        public List<KeyValuePair<int, string>> Get()
        {
            return EnumHelper.GetSelectList(typeof(Nationality));
        }
    }
}
