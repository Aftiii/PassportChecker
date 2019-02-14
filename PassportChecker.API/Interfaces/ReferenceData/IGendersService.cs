using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassportChecker.API.Interfaces
{
    public interface IGendersService
    {
        List<KeyValuePair<int, string>> Get();
    }
}
