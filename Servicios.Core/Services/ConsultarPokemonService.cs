using AutoMapper;
using Servicios.Core.DTOs;
using Servicios.Core.Interfaces;



namespace Servicios.Core.Services
{
    public class ConsultarPokemonService : IConsultarPokemonService
    {
        private readonly IConsultarPokemonRepository _consultarPokemonRepository;
        private readonly IMapper _mapper;

        public ConsultarPokemonService(IMapper mapper, IConsultarPokemonRepository consultarPokemonRepository)
        {
            _consultarPokemonRepository = consultarPokemonRepository;
            _mapper = mapper;
        }

        public async Task<PokemonDto> ConsultarPokemon(string nombre_pokemon)
        {
            Ocultas oculta = new Ocultas();
            Habilidades habilidades = new Habilidades();
            List<Ocultas> ocultas = new List<Ocultas>();

            PokemonDto responseDto = new PokemonDto();

            var response = await _consultarPokemonRepository.ConsultarPokemon(nombre_pokemon);


           
            if (response.response != "NOK")
            {

                foreach (var ability in response.abilities)
                {
                    if (ability.is_hidden == true)
                    {

                        oculta.nombre_habilidades = ability.ability.name;
                        ocultas.Add(oculta);
                    }
                
                }

                habilidades.ocultas = ocultas;
                responseDto.habilidades = habilidades;

                responseDto.nombre_pokemon = nombre_pokemon;

                responseDto = _mapper.Map<PokemonDto>(responseDto);
                responseDto.response = "OK";
               

            }
            else
            {
                responseDto.error = response.error; 
                responseDto.response = "NOK";
            }

            return responseDto;


        }
    }
}
