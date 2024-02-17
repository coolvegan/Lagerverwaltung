namespace Marmelade.Data;

public class Lagerort : BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public string Beschreibung { get; set; } = String.Empty;
    public Benutzer? Benutzer { get; set; }
    public int BenutzerId { get; set; }
    public ICollection<Lagergegenstand> Lagergegenstand { get; } = new List<Lagergegenstand>();
}
