using AutoMapper;
using Servicios.Core.DTOs;
using Servicios.Core.Entities;


namespace Servicios.Infrastructure.Mappings
{
    internal class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
                       
            #region Token
            CreateMap<Token, TokenDTO>().ReverseMap();
            #endregion
                       
    

            #region Pokemon
            CreateMap<PokemonDto, Pokemon>().ReverseMap();
            #endregion
        }
    }
}
