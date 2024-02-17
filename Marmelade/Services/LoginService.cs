using System.Security.Cryptography;

namespace Marmelade.Api.Services
{
    public class LoginService : ILoginService
    {
        public LoginService()
        {
            ValidityCheck();
        }
        private long validityTimeframeInSeconds = 60*45;
        private List<(string, DateTime, bool, string)> token = new List<(string, DateTime, bool, string)>();

        private byte[] ConcatenateArrays(params byte[][] arrays)
        {
            return arrays.SelectMany(array => array).ToArray();
        }

        public string GenerateAndRegisterCsrfToken(string username)
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
            token.Add((reg, time, false, username));
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
                    List<(string, DateTime, bool, string)> todelete = new List<(string, DateTime, bool, string)>();
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

        public List<(string, DateTime, bool, string)> TokenOpen()
        {
            return token;
        }

        public (bool, string) GetUsernameByToken(string clientToken)
        {
            foreach(var data in token)
            {
                if(data.Item1 == clientToken.Trim())
                {
                    return (true,data.Item4);
                }
            }
            return (false,"");
        }
    }
}

