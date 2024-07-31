using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Servicios.Core.DTOs;
using Servicios.Core.Entities;
using Servicios.Core.Exceptions;
using Servicios.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Services
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IMapper _mapper;

        public TokenService(ITokenRepository tokenRepository, IMapper mapper)
        {
            _tokenRepository = tokenRepository;
            _mapper = mapper;
        }

        public async Task<TokenDTO> GetToken([FromBody] RequestToken req)
        {
            var _integradorOutboundGenesysDTO = await _tokenRepository.GetToken(req);

            if (_integradorOutboundGenesysDTO == null)
            {
                throw new BusinessException("No trajo resultado");
            }


            var integradorOutboundGenesysDTO = _mapper.Map<TokenDTO>(_integradorOutboundGenesysDTO);
            return integradorOutboundGenesysDTO;
        }
    }
}
