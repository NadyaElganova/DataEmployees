using DataEmployees.Models;
using DataEmployees.Services;
using DataEmployees.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace DataEmployees.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IOrganizationService _organizationService;
        private readonly ICsvIOService _csvIOService;
        public HomeController(IEmployeeService employeeService, IOrganizationService organizationService, ICsvIOService csvIOService)
        {
            _employeeService = employeeService;
            _organizationService = organizationService;
            _csvIOService = csvIOService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.organizations = new SelectList(await _organizationService.GetAllOrganizationsAsync(), "Id", "Name");
            return View();
        }
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmpoyeesAsync();
            return View(employees);
        }
        public async Task<IActionResult> GetAllOrganizations()
        {
            var organizations = await _organizationService.GetAllOrganizationsAsync();
            return View(organizations);
        }
        [HttpGet]
        public async Task<IActionResult> ExportEmployeesExcel()
        {
            var csvData = await _csvIOService.ExportToCsvAsync(await _employeeService.GetAllEmpoyeesAsync());
            return File(csvData, "text/csv", $"employees_{DateTime.Now}.csv");
        }
        [HttpGet]
        public async Task<IActionResult> ExportOrganizationsExcel()
        {
            var csvData = await _csvIOService.ExportToCsvAsync(await _organizationService.GetAllOrganizationsAsync());
            return File(csvData, "text/csv", $"organizations_{DateTime.Now}.csv");
        }        
        [HttpPost]
        public async Task<IActionResult> ImportEmployeesFromCsv(IFormFile file)
        {
            try
            {
                var result = await _csvIOService.ImportEmployeesFromCsvAsync(file);
                TempData["status"] = result;
            }
            catch (Exception ex)
            {
                TempData["status"] = ex.Message;
            }
            return RedirectToAction("GetAllEmployees");
        }
        [HttpPost]
        public async Task<IActionResult> ImportOrganizationsFromCsv(IFormFile file)
        {
            try
            {
                var result = await _csvIOService.ImportOrganizationsFromCsvAsync(file);
                TempData["status"] = result;
            }
            catch (Exception ex)
            {
                TempData["status"] = ex.Message;
            }
            return RedirectToAction("GetAllOrganizations");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee(Employee employee, int organizations)
        {
            if(employee!=null && organizations!=0)
            {
                var organization = await _organizationService.GetOrganizationAsync(organizations);
                if(organization!=null)
                {
                    employee.Organization = organization;

                    if(await _employeeService.AddEmployeeAsync(employee))
                    {
                        TempData["status"] = "Сотрудник успешно добавлен!";
                        return RedirectToAction("Index");
                    }
                    TempData["status"] = "Ошибка при сохранении.";
                }
                else 
                {
                    TempData["status"] = "Выбранная организация не найдена.";
                }
            }
            else
            {
                TempData["status"] = "Добавьте сначала организацию.";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrganization(Organization organization)
        {
            if(organization != null)
            {
                if (await _organizationService.AddOrganizationAsync(organization))
                {
                    TempData["status"] = "Организация успешно добавлена!";
                    return RedirectToAction("Index");
                }
            }
            TempData["status"] = "Ошибка при добавлении организации.";
            return RedirectToAction("Index");
        }
    }
}