using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Servicios.Core.Interfaces;


#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

namespace api.Filters
{
    public class AuthActionAsyncFilter : Attribute, IAsyncActionFilter
    {
        public string[]? permissionsRoute { get; set; }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            // check if route is 
            if (ValidateJwt(context) == false)
            {
                ObjectResult res = new ObjectResult(null);
                res.StatusCode = 401;
                context.Result = res;
                return;
            }

            // validate roles if route has roles
            if (permissionsRoute.Length > 0)
            {
                if (UserHasCorrectRoles(context) == false)
                {
                    ObjectResult res = new ObjectResult(null);
                    res.StatusCode = 401;
                    context.Result = res;
                    return;
                }
            }

            // execute controller method
            var result = await next();
            
        }

        private bool ValidateJwt(ActionExecutingContext context)
        {
            Guid userId;
            string roles = "";

            IPasswordHelper _passwordHelper = (IPasswordHelper)context.HttpContext.RequestServices.GetService(typeof(IPasswordHelper));

            // extract token
            string token = context.HttpContext.Request.Headers["Authorization"].ToString().Split(" ").Last();
            if (string.IsNullOrEmpty(token) == true)
            {
                return false;
            }

            // validate valid token
            bool jwtValidation = _passwordHelper.ValidateToken(token, out userId, out roles);
            if (jwtValidation == true)
            {
                context.HttpContext.Items["userId"] = userId;
                context.HttpContext.Items["roles"] = roles;
            }

            return jwtValidation;
        }

        private bool UserHasCorrectRoles(ActionExecutingContext context)
        {
            string encriptedRoles = context?.HttpContext.Items?["roles"].ToString();
            IEncryptHelper _encryptService = (IEncryptHelper)context.HttpContext.RequestServices.GetService(typeof(IEncryptHelper));
            encriptedRoles = Task.Run(() => _encryptService.DecryptText(encriptedRoles)).GetAwaiter().GetResult().data;

            List<string>? userRoles = new List<string>(encriptedRoles.Split(','));

            // validate if user has super_admin or user has role for execute this method
            if (userRoles.Contains("super_admin") == true)
            {
                return true;
            }

            //validate each role. If the route has more of one role, the user needs to have all roles
            foreach (var item in permissionsRoute)
            {
                if (userRoles.Contains(item.ToString()) == false)
                {
                    return false;
                }
            }

            // if user get this point has permission to execute the method
            return true;

        }
    }
}

#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.

