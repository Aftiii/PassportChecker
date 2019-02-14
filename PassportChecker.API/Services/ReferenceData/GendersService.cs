using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PassportChecker.API.Interfaces;
using PassportChecker.Common.Helpers;
using PassportChecker.Common.Enums;

namespace PassportChecker.API.Services
{
    public class GendersService : IGendersService
    {
        public List<KeyValuePair<int, string>> Get()
        {
            return EnumHelper.GetSelectList(typeof(Gender));
        }
    }
}
