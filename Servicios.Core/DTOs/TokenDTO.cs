using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Core.DTOs
{

    public class TokenDTO
    {
        public string? statusCode { get; set; }
        public object? data { get; set; }
        public string? message { get; set; }
    }

    public class ResponseTokenDTO
    {
        public string? Token { get; set; }
    }

    public class RequestTokenDTO
    { 
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }

    public class DecryptTextDTO
    {
        public string? statusCode { get; set; }
        public string? data { get; set; }
        public string? message { get; set; }
    }
}
