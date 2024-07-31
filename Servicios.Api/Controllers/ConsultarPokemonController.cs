using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Servicios.Api.Responses;
using Servicios.Core.DTOs;
using Servicios.Core.Exceptions;
using Servicios.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;
using Ubiety.Dns.Core;

namespace Servicios.Api.Controllers
{
    //[AuthActionAsyncFilter(permissionsRoute = new[] { "api_tuya" })]
    [Route("api/[controller]")]
    [ApiController]

    public class ConsultarPokemonController : ControllerBase
    {
        private readonly IConsultarPokemonService _consultarPokemonService;
        private readonly ILogger _logger;

        public ConsultarPokemonController(IConsultarPokemonService consultarPokemonService, ILogger<ConsultarPokemonController> logger)
        {
            _consultarPokemonService = consultarPokemonService;
            _logger = logger;
        }

        [SwaggerOperation(Summary = "Consulta que se realiza para consultar un pokemon")]
        [HttpGet("/pokemon/habilidadesOcultas")]
        public async Task<IActionResult> ConsultarPokemon(string nombre_pokemon)
        {
            var jsonEntrada = JsonConvert.SerializeObject(nombre_pokemon);
            object response;
            Stopwatch time = Stopwatch.StartNew();
            try
            {


                var pokemonResponse = await _consultarPokemonService.ConsultarPokemon(nombre_pokemon);
                if (pokemonResponse.response== "OK")
                {

                    response = new ApiResponse<PokemonDto>(pokemonResponse, $"{time.ElapsedMilliseconds} ms", true);
                }
                else
                {
                    response = new ApiResponse<PokemonDto>(pokemonResponse, $"{time.ElapsedMilliseconds} ms", false);
                }

                var jsonSalida = JsonConvert.SerializeObject(response);
                _logger.LogInformation("--> {1}  /api/v2pokemon/ entrada:{2}, respuesta:{3}, tiempo:{4} ms \n", DateTime.Now.ToString(), nombre_pokemon, jsonSalida, time.ElapsedMilliseconds);

                return Ok(response);

            }
            catch (Exception ex)
            {


                _logger.LogError("--> {1}  /api/v2pokemon/ entrada:{2}, respuesta:{3}, tiempo:{4} ms \n", DateTime.Now.ToString(), nombre_pokemon, ex.Message, time.ElapsedMilliseconds);

                throw new BusinessException(ex.Message.ToString());
            }

        }
    }
}
