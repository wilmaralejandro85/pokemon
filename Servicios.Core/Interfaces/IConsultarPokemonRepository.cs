

using Servicios.Core.Entities;

namespace Servicios.Core.Interfaces
{
    public interface IConsultarPokemonRepository
    {
        Task<Pokemon> ConsultarPokemon(string nombre_pokemon);
    }
}
