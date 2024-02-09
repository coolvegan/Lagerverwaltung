using Marmelade.Data;

public class LagerortDto
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Beschreibung { get; set; } = String.Empty;
    public ICollection<LagergegenstandDto> Lagergegenstand { get; set; } = new List<LagergegenstandDto>();
    public static implicit operator LagerortDto(Lagerort lagerort)
    {
        List<LagergegenstandDto> dtos = new List<LagergegenstandDto>();
        foreach (var item in lagerort.Lagergegenstand)
        {
            LagergegenstandDto dto1 = new LagergegenstandDto();
            dto1 = item;
            dtos.Add(dto1);
        }
        LagerortDto dto = new LagerortDto
        {
            Id = lagerort.Id,
            Beschreibung = lagerort.Beschreibung,
            Name = lagerort.Name,
            Lagergegenstand = dtos
        };
        return dto;
    }
}

public class LagerortCreateDto
{
    public string Name { get; set; } = String.Empty;
    public string Beschreibung { get; set; } = String.Empty;
    public static implicit operator LagerortCreateDto(Lagerort lagerort)
    {

        LagerortCreateDto dto = new LagerortCreateDto
        {
            Beschreibung = lagerort.Beschreibung,
            Name = lagerort.Name,
        };
        return dto;
    }
}

public class LagergegenstandDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Beschreibung { get; set; }
    public string? Mengenbezeichner { get; set; }
    public string? Lagerort { get; set; }
    public string? Lagerzeitpunktcode { get; set; }
    public string? Lagerortmengencode { get; set; }
    public int LagerortId { get; set; }
    public double Menge { get; set; }
    public DateTime Lagerzeitpunkt { get; set; }

    public static implicit operator LagergegenstandDto(Lagergegenstand lagergegenstand)
    {
        LagergegenstandDto dto = new LagergegenstandDto();
        try
        {
            var month = lagergegenstand.Lagerzeitpunkt.Month.ToString();
            var year = lagergegenstand.Lagerzeitpunkt.Year.ToString().Substring(2, 2);
            if (month.Length == 1)
            {
                month = "0" + month;
            }

            dto.Id = lagergegenstand.Id;
            dto.Beschreibung = lagergegenstand.Beschreibung;
            dto.Name = lagergegenstand.Name;
            dto.LagerortId = lagergegenstand.Lagerort.Id;
            dto.Lagerort = lagergegenstand.Lagerort.Name;
            dto.Lagerzeitpunkt = lagergegenstand.Lagerzeitpunkt;
            dto.Menge = lagergegenstand.Menge;
            dto.Mengenbezeichner = lagergegenstand.Mengenbezeichner;
            dto.Lagerzeitpunktcode = month + "." + year;
            dto.Lagerortmengencode = lagergegenstand.Menge + " " + lagergegenstand.Lagerort.Name;
        }catch(Exception e)
        {
            Console.WriteLine(e);
        }
        return dto;
    }
}
public class LagergegenstandCreateDto
{
    public string? Name { get; set; }
    public string? Beschreibung { get; set; }
    public string? Mengenbezeichner { get; set; }
    public int LagerortId { get; set; }
    public double Menge { get; set; }
    public DateTime Lagerzeitpunkt { get; set; }

    public static implicit operator LagergegenstandCreateDto(Lagergegenstand lagergegenstand)
    {
        var dto = new LagergegenstandCreateDto
        {
            Beschreibung = lagergegenstand.Beschreibung,
            Name = lagergegenstand.Name,
            LagerortId = lagergegenstand.Lagerort.Id,
            Lagerzeitpunkt = lagergegenstand.Lagerzeitpunkt,
            Menge = lagergegenstand.Menge,
            Mengenbezeichner = lagergegenstand.Mengenbezeichner
        };
        return dto;
    }
    public static implicit operator Lagergegenstand(LagergegenstandCreateDto lagergegenstand)
    {
        var dto = new Lagergegenstand
        {
            Beschreibung = lagergegenstand.Beschreibung,
            Name = lagergegenstand.Name,
            LagerortId = lagergegenstand.LagerortId,
            Lagerzeitpunkt = lagergegenstand.Lagerzeitpunkt,
            Menge = lagergegenstand.Menge,
            Mengenbezeichner = lagergegenstand.Mengenbezeichner
        };
        return dto;
    }
}
