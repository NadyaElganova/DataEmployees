using DataEmployees.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

namespace DataEmployees.Services
{
    public class CsvIOService : ICsvIOService
    {
        private readonly AppDbContext _context;

        public CsvIOService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<byte[]> ExportToCsvAsync<T>(IEnumerable<T> data) where T : IExportableToCsv
        {
            var csv = new StringBuilder();

            foreach (var item in data)
            {
                csv.AppendLine(item.ToCsvString());
            }

            return Encoding.UTF8.GetBytes(csv.ToString());
        }

        public async Task ImportEmployeesFromCsvAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Файл не был загружен.");
            }

            var employees = new List<Employee>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    var values = line.Split(',');

                    var employee = new Employee
                    {
                        FirstName = values[0],
                        SecondName = values[1],
                        SeriesPassport = values[2],
                        NumberPassport = values[3],
                        BirthDate = DateTime.ParseExact(values[4], "yyyy-MM-dd HH:mm:ss.fffffff", CultureInfo.InvariantCulture),
                    };
                    int organizationId = int.Parse(values[5]);

                    employee.Organization = await _context.Organizations.FindAsync(organizationId);

                    employees.Add(employee);
                }
            }

            await _context.AddRangeAsync(employees);
            await _context.SaveChangesAsync();
        }

        public async Task ImportOrganizationsFromCsvAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Файл не был загружен.");
            }

            var organizations = new List<Organization>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    var values = line.Split(',');

                    var organization = new Organization
                    {
                        Name = values[0],
                        Inn = values[1],
                        LegalAdress = values[2],
                        ActualAdress = values[3]
                    };
                   organizations.Add(organization);
                }
            }

            await _context.AddRangeAsync(organizations);
            await _context.SaveChangesAsync();
        }
    }
}
