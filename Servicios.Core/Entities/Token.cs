using System;
using System.Collections.Generic;

namespace Servicios.Core.Entities 
{
    public class Token
    {
        public string? statusCode { get; set; }
        public object? data { get; set; }
        public string? message { get; set; }
    }

    public class ResponseToken
    {
        public string? Token { get; set; }
    }

    public class RequestToken
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }

    public class DecryptText
    {
        public string? statusCode { get; set; }
        public string? data { get; set; }
        public string? message { get; set; }
    }
}
