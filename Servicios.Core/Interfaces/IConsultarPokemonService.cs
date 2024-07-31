
using Servicios.Core.DTOs;


namespace Servicios.Core.Interfaces
{
    public interface IConsultarPokemonService
    {
        Task<PokemonDto> ConsultarPokemon(string nombre_pokemon);
    }
}
