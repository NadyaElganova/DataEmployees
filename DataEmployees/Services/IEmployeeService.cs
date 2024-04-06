using DataEmployees.Models;

namespace DataEmployees.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmpoyeesAsync();
        Task<bool> AddEmployeeAsync(Employee employee);
    }
}
