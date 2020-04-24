using AutoMapper;
using Escalada.Models;

namespace Escalada.Utils
{
    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserLoginModel, User>();
            CreateMap<UserRegistrationModel, User>();
        }
    }
}