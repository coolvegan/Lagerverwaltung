using System.Linq;
using ClosedXML.Excel;
using Marmelade.Data;

using String = System.String;

public class ExcelImport
{
    DatenbankContext Datenbank { get; set; }
    public ExcelImport(DatenbankContext datenbankContext)
    {
        Datenbank = datenbankContext;
    }
    
    public async void OrteInDieDatenbank(HashSet<string> orte)
    {
        foreach (var ort in orte)
        {
            Lagerort lagerort = new Lagerort { Name = ort, Beschreibung = "" };
            var dbort = Datenbank.Lagerorte.Where(id => id.Name == ort).ToList();
            if (dbort.Count >0)
            {
                continue;
            }
            await Datenbank.AddAsync(lagerort);
        }
        await Datenbank.SaveChangesAsync();
    }

    public void Start()
    {

        using (var workbook = new XLWorkbook("/Users/marcokittel/paul.xlsx"))
        {
            var orte = GetArbeitsorte(workbook);
            OrteInDieDatenbank(orte);
            var lg = GetLagerGegenstaende(workbook);
            if(lg == null)
            {
                return;
            }
            LagergegenstandZuDatenbank(lg);
           
        }
    }

    private async void LagergegenstandZuDatenbank(List<Lagergegenstand> liste)
    {
        foreach(var gegenstand in liste)
        {
            await Datenbank.AddAsync<Lagergegenstand>(gegenstand);
        }
        Datenbank.SaveChanges();
    }

    private List<Lagergegenstand> GetLagerGegenstaende(XLWorkbook workbook)
    {
        List<Lagergegenstand> importListe = new List<Lagergegenstand>();
        try
        {
            var ortsListe = Datenbank.Lagerorte.ToList();
            var worksheet = workbook.Worksheet(1);
            foreach (var row in worksheet.RowsUsed())
            {
                string lagergegenstand = "";
  
                foreach (var cell in row.CellsUsed())
                {
                    if (cell.Value.IsBlank)
                    {
                        continue;
                    }
                    if (cell.Address.ToString()!.Contains("A"))
                    {
                        lagergegenstand = cell.Value.ToString().Trim();
                        continue;
                    }
                    var gewicht = cell.Value.ToString().Split(" ").ElementAt(0).Trim();
                    var lagerOrt = cell.Value.ToString().Split(" ").ElementAt(1).Trim();
                    var monat = cell.Value.ToString().Split(" ").ElementAt(2).Split(".").ElementAt(0).Trim();
                    var jahr = cell.Value.ToString().Split(" ").ElementAt(2).Split(".").ElementAt(1).Trim();
                    double gewicht_double;

                    Double.TryParse(gewicht, out gewicht_double);
                    if (lagerOrt.Equals(""))
                    {
                        continue;
                    }
                    Lagerort ort;
                    try
                    {
                        ort = ortsListe.Where(e => e.Name == lagerOrt).First();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Ort konnte nicht gefunden werden: " + lagerOrt);
                        continue;
                    }



                    DateTime date;
                    string datum = "15." + monat  + ".20" + jahr;
                    if (!DateTime.TryParse(datum, out date))
                    {
                        continue;
                    }

                    Lagergegenstand neu = new Lagergegenstand
                    {
                        Name = lagergegenstand,
                        Beschreibung = "",
                        Menge = gewicht_double,
                        Mengenbezeichner = "Gramm",
                        UpdatedBy = "Import",
                        Lagerzeitpunkt = date,
                        LagerortId = ort.Id
                    };
                    importListe.Add(neu);
                }
            }
        } catch(Exception e)
        {
            System.Console.WriteLine(e);
        }
        return importListe;
    }

    private HashSet<string> GetArbeitsorte(XLWorkbook workbook)
    {
        var worksheet = workbook.Worksheet(1);
        HashSet<string> lagerOrte = new HashSet<String>();
        foreach (var row in worksheet.RowsUsed())
        {
            foreach (var cell in row.CellsUsed())
            {
                if (cell.Address.ToString()!.Contains("A") || cell.IsEmpty())
                {
                    continue;
                }
                var lagerOrt = cell.Value.ToString().Split(" ").ElementAt(1);
                lagerOrte.Add(lagerOrt);
            }
        }
        return lagerOrte;
    }
}
