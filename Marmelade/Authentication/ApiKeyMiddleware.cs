using System.Net;
using Marmelade.Data;

namespace Essensplan.Api
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private string _dbapi_key  = "";
        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _configuration = configuration;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, DatenbankContext datenbankContext)
        {
            if(_dbapi_key == "")
            {
                var data = await datenbankContext.ApiEinstellungen.FindAsync(1);
                if(data != null && _dbapi_key == "")
                {
                    _dbapi_key = data.AuthenticationSchluessel;
                }
            }
            if (!context.Request.Headers.TryGetValue("ApiKey", out var apikeyfromheader))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Schlüssel fehlt.");
                return;
            }
            var apikey = _configuration.GetValue<string>("ApiKey");
            if (_dbapi_key.Length > 0)
            {
                apikey = _dbapi_key;
            }
            if(apikey == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Schlüssel nicht in Applikation registriert.");
                return;
            }
            if (!apikey.Equals(apikeyfromheader))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Schlüssel fehlt.");
                return;
            }
            await _next(context);
        }

    }
}

