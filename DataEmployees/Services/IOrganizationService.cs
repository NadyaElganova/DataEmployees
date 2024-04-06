using DataEmployees.Models;

namespace DataEmployees.Services
{
    public interface IOrganizationService
    {
        Task<IEnumerable<Organization>> GetAllOrganizationsAsync();
        Task<Organization> GetOrganizationAsync(int id);        
        Task<bool> AddOrganizationAsync(Organization organization);

    }
}
