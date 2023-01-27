using CSharpExam.Models;

namespace CSharpExam.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        List<Employee> GetAllSalesEmployees();
        Employee Save(Employee e);
        void Delete(Employee e);
        void AddSale(SalesEmployee e, Sale s);
        List<Employee> GetAllNormalEmployees();
        Employee EmployeeFindById(int employeeId);
        SalesEmployee SalesEmployeeFindById(int employeeId);
    }
}