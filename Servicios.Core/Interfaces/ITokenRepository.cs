using Microsoft.AspNetCore.Mvc;
using Servicios.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.Interfaces
{
    public interface ITokenRepository
    {
        Task<Token> GetToken([FromBody] RequestToken req);
    }
}
