using AutoMapper;
using PassportChecker.Common.ViewModels;
using PassportChecker.Common.Models;

namespace PassportChecker.API.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PassportInput, PassportBaseData>();
        }
    }
}
