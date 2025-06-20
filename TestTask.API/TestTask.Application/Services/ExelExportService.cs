using ClosedXML.Excel;
using TestTask.Application.DTOs.User.Responces;
using TestTask.Application.ServicesAbstraction;

namespace TestTask.Application.Services;

public class ExcelExportService : IExcelExportService
{
    public byte[] ExportUsersToExcel(List<UserResponceDto> users)
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Users");
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Name";
            worksheet.Cell(1, 3).Value = "Type";
            
            for (int i = 0; i < users.Count; i++)
            {
                worksheet.Cell(i + 2, 1).Value = users[i].Id;
                worksheet.Cell(i + 2, 2).Value = users[i].Name;
                worksheet.Cell(i + 2, 3).Value = users[i].Type;
            }
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}