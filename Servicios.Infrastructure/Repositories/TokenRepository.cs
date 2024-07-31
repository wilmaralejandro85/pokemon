using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Servicios.Core.DTOs;
using Servicios.Core.Entities;
using Servicios.Core.Exceptions;
using Servicios.Core.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Servicios.Infrastructure.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        

        public TokenRepository(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
           
        }

        public async Task<Token> GetToken([FromBody] RequestToken req)
        {

            string reqjson = JsonSerializer.Serialize(req);

           Token resp = new Token();

          
            var url = _configuration["AppSettings:url_token"];

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                //var jsonreq = JObject.Parse(req.ToString());

                var content = new StringContent(reqjson, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                var input = response.Content.ReadAsStringAsync().Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //se agrega nuget Microsoft.AspNetCore.Mvc.NewtonsoftJson para poder hacer esta instruccion
                    resp = Newtonsoft.Json.JsonConvert.DeserializeObject<Token>(input);
                }
                else
                {
                    throw new BusinessException(String.Format("Error WS de integracion: {0}", response.StatusCode.ToString()));
                }
            }
            return resp;
        }

    }
}
