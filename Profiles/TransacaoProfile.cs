using AutoMapper;
using NutriBank.Data.Dtos;
using NutriBank.Models;

namespace NutriBank.Profiles
{
    public class TransacaoProfile:Profile
    {
        public TransacaoProfile()
        {
            CreateMap<CreateTransacaoDto, Transacao>();
        }
    }
}
