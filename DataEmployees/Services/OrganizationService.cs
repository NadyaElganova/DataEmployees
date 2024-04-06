using DataEmployees.Models;
using Microsoft.EntityFrameworkCore;

namespace DataEmployees.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly AppDbContext _context;

        public OrganizationService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddOrganizationAsync(Organization organization)
        {
            try
            {
                await _context.Organizations.AddAsync(organization);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Organization>> GetAllOrganizationsAsync()
        {
            return await _context.Organizations.ToListAsync();
        }

        public async Task<Organization> GetOrganizationAsync(int id)
        {
            return await _context.Organizations.FirstOrDefaultAsync(org => org.Id == id);
        }
    }
}
