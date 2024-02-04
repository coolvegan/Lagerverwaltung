public interface ILoginService
{
    string GenerateAndRegisterCsrfToken();
    
    public List<(string, DateTime, bool)> TokenOpen();
    public bool IsTokenValid(string clientToken);
}