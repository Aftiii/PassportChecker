using System.Collections.Generic;

namespace PassportChecker.API.Interfaces
{
    public interface IGendersService
    {
        List<KeyValuePair<int, string>> Get();
    }
}
