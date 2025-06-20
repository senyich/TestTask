using TestTask.Application.DTOs.User.Responces;

namespace TestTask.Application.ServicesAbstraction;

public interface IExcelExportService
{
    byte[] ExportUsersToExcel(List<UserResponceDto> users);
}