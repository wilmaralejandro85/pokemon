using Microsoft.AspNetCore.Mvc;
using Servicios.Core.DTOs;
using Servicios.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Interfaces
{
    public interface ITokenService
    {
        Task<TokenDTO> GetToken([FromBody] RequestToken req);
    }
}
