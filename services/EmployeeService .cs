using CSharpExam.Interfaces;
using CSharpExam.Models;
using CSharpExam.Conf;

namespace CSharpExam.Services
{
    public class EmployeeService : IEmployeeService
    {
        private ApplicationContext Context;
        private List<Employee> EmployeeList;

        public EmployeeService()
        {
            Context = ApplicationContext.Instance;
            EmployeeList = Context.GetEmployeeLists();
        }

        public void AddSale(SalesEmployee e, Sale s)
        {
            e.AddEmployeeSale(s);
        }

        public void Delete(Employee e)
        {
            this.GetAll().Remove(e);
        }

        public List<Employee> GetAll()
        {
            return this.EmployeeList;
        }

        public Employee EmployeeFindById(int employeeId)
        {
            return this.GetAll().FirstOrDefault(e => e.Id == employeeId);
        }

        public SalesEmployee SalesEmployeeFindById(int employeeId)
        {
            return (SalesEmployee)this.GetAll().FirstOrDefault(e => e.Id == employeeId);
        }

        public List<Employee> GetAllNormalEmployees()
        {
            return this.GetAll().Where(employee => !(employee is SalesEmployee)).ToList();
        }

        public List<Employee> GetAllSalesEmployees()
        {
            return this.GetAll().OfType<SalesEmployee>().Cast<Employee>().ToList();
        }

        public Employee Save(Employee e)
        {
            this.GetAll().Add(e);
            return e;
        }
    }
}
