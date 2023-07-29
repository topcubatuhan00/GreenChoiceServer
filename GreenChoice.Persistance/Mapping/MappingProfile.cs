using AutoMapper;
using GreenChoice.Domain.Entities;
using GreenChoice.Domain.Models.AuthModels;

namespace GreenChoice.Persistance.Mapping;

public partial class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserRegisterModel>().ReverseMap();
    }
}
