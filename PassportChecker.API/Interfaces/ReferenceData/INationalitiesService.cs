using System.Collections.Generic;

namespace PassportChecker.API.Interfaces
{
    public interface INationalitiesService
    {
        List<KeyValuePair<int, string>> Get();
    }
}
