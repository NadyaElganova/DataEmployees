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

        public async Task<string> ImportEmployeesFromCsvAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return "Файл не был загружен.";
            }

            var employees = new List<Employee>();
            try
            {
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
                            NumberPassport = values[3]
                        };
                        if (DateTime.TryParseExact(values[4], "yyyy-MM-dd HH:mm:ss.fffffff", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate))
                        {
                            employee.BirthDate = birthDate;
                        }
                        else
                        {
                            throw new FormatException($"Ошибка при парсинге даты: {values[4]}");
                        }
                        int organizationId;
                        if (int.TryParse(values[5], out organizationId))
                        {
                            var organization = await _context.Organizations.FindAsync(organizationId);
                            if (organization != null)
                            {
                                employee.Organization = organization;
                            }
                            else
                            {
                                throw new ArgumentException($"Организация с Id {organizationId} не найдена.");
                            }
                        }
                        else
                        {
                            throw new FormatException($"Неверный формат идентификатора организации: {values[5]}");
                        }
                        employees.Add(employee);
                    }
                }

                await _context.AddRangeAsync(employees);
                await _context.SaveChangesAsync();

                return "Данные успешно импортированы.";
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message}";
            }
        }


        public async Task<string> ImportOrganizationsFromCsvAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Файл не был загружен.");
            }

            var organizations = new List<Organization>();
            try
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = await reader.ReadLineAsync();
                        var values = line.Split(',');
                        if (values.Length != 4)
                        {
                            throw new FormatException("Неверное количество значений в строке CSV файла.");
                        }

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
                return "Данные успешно импортированы.";
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message}";
            }           
        }
    }
}
