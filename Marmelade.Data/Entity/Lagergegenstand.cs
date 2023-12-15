namespace Marmelade.Data;

public class Lagergegenstand : BaseEntity
{
    public string Name { get; set; } = String.Empty;
    public string Beschreibung { get; set; } = String.Empty;
    public string Mengenbezeichner { get; set; } = String.Empty;
    public Lagerort Lagerort { get; set; }
    public int LagerortId { get; set; }
    public double Menge { get; set; }
    public DateTime Lagerzeitpunkt { get; set; }
}


