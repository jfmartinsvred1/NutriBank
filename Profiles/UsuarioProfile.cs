using AutoMapper;
using NutriBank.Data.Dtos;
using NutriBank.Models;

namespace NutriBank.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
