using ClosedXML.Excel;
using Marmelade.Data;

using String = System.String;

public class ExcelGenerator : IExcelGenerator
{
    public XLWorkbook Create(List<Lagergegenstand> lg)
    {
        Dictionary<string, List<string>> keyValuePairs = new Dictionary<String, List<String>>();
        foreach (var item in lg)
        {
            List<string> valueList;
            keyValuePairs.TryGetValue(item.Name.Trim(), out valueList);
            if (valueList == null)
            {
                valueList = new List<String>();
                keyValuePairs.Add(item.Name.Trim(), valueList);
            }

            var month = item.Lagerzeitpunkt.Month.ToString();
            var year = item.Lagerzeitpunkt.Year.ToString().Substring(2);

            if (month.Length == 1)
            {
                month = "0" + month;
            }
            var day = item.Lagerzeitpunkt.Day.ToString();
            if (day.Length == 1)
            {
                day = "0" + day;
            }
            valueList.Add(item.Menge + " " + item.Lagerort.Name + "\n" + month + "." + year);
        };

        var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Blatt1");
        var row = 1;
        ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        var columnA = ws.Column(1);
        columnA.Style.Font.Bold = true;
        columnA.Style.Font.FontSize = 12;
        columnA.Width = 30;
        foreach (var item in keyValuePairs)
        {
            var key = item.Key;
            var col = 1;
            ws.Cell(row, 1).SetValue(key);
            col++;
            for (int i = 0; i < item.Value.Count; i++)
            {
                if (i % 6 == 0 && i != 0)
                {
                    row++;
                    ws.Cell(row, 1).SetValue(key);
                }
                ws.Cell(row, (i % 6) + 2).SetValue(item.Value.ElementAt<string>(i));
            }
            row++;
        }

        return wb;
    }
}