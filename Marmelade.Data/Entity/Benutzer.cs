using System.Security.Cryptography;
using System.Text;

namespace Marmelade.Data;

public class Benutzer: BaseEntity
{
    public string Name { get; set;  } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public ICollection<Lagergegenstand> Lagergegenstand { get; } = new List<Lagergegenstand>();
    public ICollection<Lagerort> Lagerort { get; } = new List<Lagerort>();

    public static string GetPassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            return GetHash(sha256Hash, password);
 
        }
    }

    private static string GetHash(HashAlgorithm hashAlgorithm, string input)
    {
        byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
        var sBuilder = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }
        return sBuilder.ToString();
    }
}
