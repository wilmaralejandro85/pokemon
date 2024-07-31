using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Servicios.Api.Responses;
using Servicios.Core.DTOs;
using Servicios.Core.Entities;
using Servicios.Core.Exceptions;
using Servicios.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Diagnostics;
using System.Web.Http.Cors;
using EnableCorsAttribute = System.Web.Http.Cors.EnableCorsAttribute;

namespace Servicios.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly ILogger _logger;

        public TokenController(ITokenService tokenService, ILogger<TokenController> logger)
        {
            _tokenService = tokenService;
            _logger = logger;
        }


        
        [HttpPost("~/api/v1/Token/")]
        [SwaggerOperation(Summary = "Token para acceder a los metodos")]
        [EnableCors(origins: "https://www.tuya.com.co,http://18.211.118.240:443,https://apiwebchat.emtelco.co,", headers: "*", methods: "POST")]
        public async Task<IActionResult> GetToken([FromBody] RequestToken req)
        {
            try 
            { 
                Stopwatch time = Stopwatch.StartNew();
                var token = await _tokenService.GetToken(req);
                if (token == null)
                {
                    throw new BusinessException("idRegistro no existente");
                } else
                {
                    var resp = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseTokenDTO>(token.data.ToString());
                    var response = new ApiResponseToken<ResponseTokenDTO>(resp, $"{time.ElapsedMilliseconds} ms");
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("/api/v1/Token/ (POST): " + ex.Message.ToString(), DateTime.Now.ToString());
                throw new BusinessException(ex.Message.ToString());
            }
        }
    }
}
