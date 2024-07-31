using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;
using Servicios.Core.Entities;
using Servicios.Core.Interfaces;



namespace Servicios.Infrastructure.Repositories
{
    public class ConsultarPokemonRepository : IConsultarPokemonRepository
    {

        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;


        public ConsultarPokemonRepository(IMapper mapper, IConfiguration configuration)
        {
           
            _configuration = configuration;
            _mapper = mapper;
       
        }

        public async Task<Pokemon> ConsultarPokemon(string nombre_pokemon)
        {
            Ability ability = new Ability();
            Abilities abilities = new Abilities();           
            Pokemon pokemonResponse = new Pokemon();

            try
            {
                var client = new RestClient(_configuration["AppSettings:url_pokemon"].ToString() + nombre_pokemon);
                var request = new RestRequest("", Method.Get);
                request.AddHeader("User-Agent", "insomnia/8.6.1");
                RestResponse response = client.Execute(request);


                if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError || response.StatusCode == System.Net.HttpStatusCode.NoContent || response.StatusCode == 0)
                {

                    pokemonResponse.response = "NOK";

                }
                else
                {
                    pokemonResponse.response = "OK";
                    var result = JObject.Parse(response.Content);
                    pokemonResponse = _mapper.Map<Pokemon>(result);
                }
            }
            catch (Exception ex)
            {

                pokemonResponse.response = "NOK";
                pokemonResponse.error = ex.Message;

               
            }

            

            return pokemonResponse;

        }
    }
}
