using CSharpExam.Models;
using System.Text.Json;
using CSharpExam.Services;
using CSharpExam.Interfaces;

namespace CSharpExam.Commands
{

    public class BuildReport
    {
        private IEmployeeService EmployeeService;

        public BuildReport()
        {
            this.EmployeeService = new EmployeeService();
        }

        public string Execute()
        {
            var employees = this.EmployeeService.GetAllNormalEmployees();
            var salesEmployees = this.EmployeeService.GetAllSalesEmployees().Cast<SalesEmployee>().ToList();

            // Computation of totalSales and totalCommission
            var totalSales = salesEmployees.Sum(salesEmployee => salesEmployee.GetSales().Sum(sale => sale.Amount));
            var totalCommission = salesEmployees.Sum(salesEmployee => salesEmployee.GetSales().Sum(sale => sale.Amount * salesEmployee.Commission));

            var report = new
            {
                employees = employees.Select(e => new { e.Id, e.EmployeeNumber, e.FirstName, e.LastName, e.BaseSalary }),
                salesEmployees = salesEmployees.Select(se => new { se.Id, se.EmployeeNumber, se.FirstName, se.LastName, se.BaseSalary, se.Commission }),
                totalSales = totalSales,
                totalCommission = totalCommission
            };

            var seralizerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(report, seralizerOptions);
        }
    }
}