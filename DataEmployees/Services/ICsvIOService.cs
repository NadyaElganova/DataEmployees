using DataEmployees.Models;

namespace DataEmployees.Services
{
    public interface ICsvIOService
    {
        Task<byte[]> ExportToCsvAsync<T>(IEnumerable<T> data) where T : IExportableToCsv;
        Task<string> ImportEmployeesFromCsvAsync(IFormFile file);
        Task<string> ImportOrganizationsFromCsvAsync(IFormFile file);
    }
}
