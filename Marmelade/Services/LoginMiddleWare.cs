using System;
using System.Security.Cryptography;
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
            if (context.Request.Path.StartsWithSegments("/Login"))
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
            await _next(context);
        }
    }

    public class LoginService : ILoginService
    {
        public LoginService()
        {
            ValidityCheck();
        }
        private long validityTimeframeInSeconds = 60*60;
        private List<(string, DateTime, bool)> token = new List<(string, DateTime, bool)>();

        private byte[] ConcatenateArrays(params byte[][] arrays)
        {
            return arrays.SelectMany(array => array).ToArray();
        }

        public string GenerateAndRegisterCsrfToken()
        {
            Guid uuid1 = Guid.NewGuid();
            Guid uuid2 = Guid.NewGuid();
            byte[] tokenBytes = new byte[32]; // 256-Bit-Token
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(tokenBytes);
            }
            var time = DateTime.Now;
            time = time.AddSeconds(validityTimeframeInSeconds);
            var reg = Convert.ToBase64String(ConcatenateArrays(uuid1.ToByteArray(), tokenBytes,uuid2.ToByteArray()));
            token.Add((reg, time, false));
            return reg;
        }

        public bool IsTokenValid(string clientToken) {
            foreach(var t in this.token) {
                if (t.Item1.Equals(clientToken)){
                    return true;
		        }
	        }
            return false;
    	}

        public void ValidityCheck()
        {
            Task task = new Task(async () =>
            {
                while (true)
                {
                    List<(string, DateTime, bool)> todelete = new List<(string, DateTime, bool)>();
                    foreach (var item in token)
                    {
                        var time = DateTime.Now;
                        if ((item.Item2 < time) || item.Item3 == true)
                        {
                            todelete.Add(item);
                        }
                    }
                    foreach(var d in todelete) {
                        token.Remove(d);
		             }
                    await Task.Delay(1000);
                }
            });
            task.Start();
        }

        public List<(string, DateTime, bool)> TokenOpen()
        {
            return token;
        }
    }
}

