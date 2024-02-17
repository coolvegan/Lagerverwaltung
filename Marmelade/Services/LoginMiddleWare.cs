using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Marmelade.Api.Services
{
    public class LoginMiddleWare
    {
        private readonly RequestDelegate _next;
        private ILoginService icsrf;

        public LoginMiddleWare(RequestDelegate next, ILoginService cSRF)
        {
            icsrf = cSRF;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api/Login")||(context.Request.Path.StartsWithSegments("/Login")))
            {
                await _next(context);
                return;
            }
            // Füge den CSRF-Token nur für GET-Anfragen hinzu
            Microsoft.Extensions.Primitives.StringValues value;
            if (context.Request.Headers.TryGetValue("Security", out value)) {
                var validToken = icsrf.IsTokenValid(value);
                if (!validToken) {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Invalid Login!");
                    return;
                }
            } else
            {
                await context.Response.WriteAsync("Invalid Login!");
                return;
            }
            context.Session.SetString("Username", icsrf.GetUsernameByToken(value).Item2!);
            await _next(context);
        }
    }
}

