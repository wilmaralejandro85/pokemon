using Microsoft.AspNetCore.Http;
using Renci.SshNet.Messages;
using Servicios.Core.DTOs;
using Servicios.Core.Entities;
using System.ServiceModel.Channels;

namespace Servicios.Api.Responses
{
    public class ApiResponse<T> : BaseResponseDTO
    {
        public ApiResponse(T data, string timems, bool resulStatus = false)
        {
            response = data;
            status = 200;
            result = resulStatus;
            errors = "";
            time = timems;
        }
        public T response { get; set; }


    }



    public class ApiResponseToken<T> : BaseResponseDTOToken
    {
        public ApiResponseToken(T data, string timems)
        {
            response = data;
            status = 200;
            result = "OK";
            errors = "";
            time = timems;
            token_type = "bearer";
            expires_in = "1200";
        }
        public T response { get; set; }
    }

    public class ApiResponseTokenWsp<T> : BaseResponseDTOToken
    {
        public ApiResponseTokenWsp(T data, string timems, string expires)
        {
            response = data;
            status = 200;
            result = "OK";
            errors = "";
            time = timems;
            token_type = "bearer";
            expires_in = "1200";
        }
        public T response { get; set; }
    }

  
}
