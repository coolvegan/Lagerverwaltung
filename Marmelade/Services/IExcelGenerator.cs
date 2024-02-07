using ClosedXML.Excel;
using Marmelade.Data;

public interface IExcelGenerator
{
    XLWorkbook Create(List<Lagergegenstand> lg);
}