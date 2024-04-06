using DataEmployees.Models;
using Microsoft.EntityFrameworkCore;

namespace DataEmployees.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddEmployeeAsync(Employee employee)
        {
            try
            {
                await _context.Employees.AddAsync(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmpoyeesAsync()
        {
            return await _context.Employees.Include(e => e.Organization).ToListAsync();
        }
    }
}
