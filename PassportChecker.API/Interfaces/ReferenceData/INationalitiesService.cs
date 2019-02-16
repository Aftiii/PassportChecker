using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassportChecker.API.Interfaces
{
    public interface INationalitiesService
    {
        List<KeyValuePair<int, string>> Get();
    }
}
