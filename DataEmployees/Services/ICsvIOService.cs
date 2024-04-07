using DataEmployees.Models;

namespace DataEmployees.Services
{
    public interface ICsvIOService
    {
        Task<byte[]> ExportToCsvAsync<T>(IEnumerable<T> data) where T : IExportableToCsv;
        Task ImportEmployeesFromCsvAsync(IFormFile file);
        Task ImportOrganizationsFromCsvAsync(IFormFile file);
    }
}
