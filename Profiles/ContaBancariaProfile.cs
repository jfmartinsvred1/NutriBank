using AutoMapper;
using NutriBank.Data.Dtos;
using NutriBank.Models;

namespace NutriBank.Profiles
{
    public class ContaBancariaProfile:Profile
    {
        public ContaBancariaProfile()
        {
            CreateMap<CreateContaBancariaDto, ContaBancaria>();
            CreateMap<ContaBancaria, ReadContaBancariaDto>();
            CreateMap<ReadContaBancariaDto, ContaBancaria>();
        }
    }
}
