public interface ILoginService
{
    string GenerateAndRegisterCsrfToken(string username);
    
    public List<(string, DateTime, bool, string)> TokenOpen();
    public bool IsTokenValid(string clientToken);
    public (bool, string) GetUsernameByToken(string clientToken);
}