namespace DataEmployees.Services
{
    public interface ICsvIOService
    {
        Task<byte[]> ExportEmployeesToCsvAsync();
        Task ImportEmployeesFromCsvAsync(IFormFile file);
        Task<byte[]> ExportOrganizationsToCsvAsync();
    }
}
