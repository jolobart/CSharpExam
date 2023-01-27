using CSharpExam.Interfaces;
using CSharpExam.Models;
using CSharpExam.Services;
using CSharpExam.Commands;

namespace CSharpExam
{
    public class Program
    {
        static IEmployeeService employeeService = new EmployeeService();

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1 - List all employees");
                Console.WriteLine("2 - Save an employee record");
                Console.WriteLine("3 - Delete an employee");
                Console.WriteLine("4 - Add sale to a selected employee");
                Console.WriteLine("5 - Quit");
                Console.WriteLine("----------------------------------------");

                var option = Console.ReadLine();

                BuildReport report = new BuildReport();
                string json = report.Execute();
                Console.WriteLine(json);
                switch (option)
                {
                    case "1":
                        // List all employees
                        ListEmployees();
                        break;
                    case "2":
                        // Save an employee record
                        SaveEmployee();
                        break;
                    case "3":
                        // Delete an employee
                        DeleteEmployee();
                        break;
                    case "4":
                        // Add sale to a selected employee
                        AddSale();
                        break;
                    case "5":
                        // Quit

                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        static void ListEmployees()
        {
            var normalEmployees = employeeService.GetAllNormalEmployees();
            var saleEmployees = employeeService.GetAllSalesEmployees().Cast<SalesEmployee>().ToList();

            if (employeeService.GetAll().Count > 0)
            {
                Console.WriteLine("List of all employees:");

                if (normalEmployees.Count > 0)
                {
                    Console.WriteLine("Normal Employee:");
                    foreach (Employee employee in normalEmployees)
                    {
                        Console.WriteLine("Id: " + employee.Id);
                        Console.WriteLine("Employee #: " + employee.EmployeeNumber);
                        Console.WriteLine("Base salary: " + employee.GetSalary());
                    }
                }

                if (saleEmployees.Count > 0)
                {
                    Console.WriteLine("Sales Employee:");
                    foreach (SalesEmployee saleEmployee in saleEmployees)
                    {
                        Console.WriteLine("Id: " + saleEmployee.Id);
                        Console.WriteLine("Employee #: " + saleEmployee.EmployeeNumber);
                        Console.WriteLine("Name: " + saleEmployee.FirstName + " " + saleEmployee.LastName);
                        Console.WriteLine("Base salary: " + saleEmployee.GetSalary());
                        Console.WriteLine("Base salary: " + saleEmployee.Commission);
                    }
                }
            }
            else
            {
                Console.WriteLine("Employee list is empty");
            }
        }

        static void SaveEmployee()
        {
            while (true)
            {
                Console.WriteLine("Select employee type:");
                Console.WriteLine("1 - Normal Employee");
                Console.WriteLine("2 - Sales Employee");
                Console.WriteLine("----------------------------------------");
                Console.Write("Enter employee type: ");
                var employeeType = Console.ReadLine();
                var isValid = employeeType == "1" || employeeType == "2";

                if (isValid)
                {
                    Console.Write("Enter first name: ");
                    var firstName = Console.ReadLine();

                    Console.Write("Enter last name: ");
                    var lastName = Console.ReadLine();

                    Console.Write("Enter employee number: ");
                    var employeeNumber = Console.ReadLine();

                    Console.Write("Enter base salary: ");
                    var baseSalary = float.Parse(Console.ReadLine());

                    if (employeeType == "1")
                    {
                        employeeService.Save(new Employee(employeeService.GetAll().Count + 1, firstName, lastName, employeeNumber, baseSalary));
                        return;
                    }
                    else if (employeeType == "2")
                    {
                        Console.Write("Enter commission: ");
                        var commission = float.Parse(Console.ReadLine());
                        employeeService.Save(new SalesEmployee(employeeService.GetAll().Count + 1, firstName, lastName, employeeNumber, baseSalary, commission));
                        return;
                    }

                    Console.Write("Employee successfully added:");
                }
                else
                {
                    Console.WriteLine("Invalid employee type");
                }
            }
        }

        static void DeleteEmployee()
        {
            Console.Write("Enter employee id: ");
            var id = int.Parse(Console.ReadLine());
            var employee = employeeService.EmployeeFindById(id);

            if (employee != null)
            {
                Console.Write("Employee successfully deleted");
                employeeService.Delete(employee);
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }

        static void AddSale()
        {
            Console.Write("Enter employee id: ");
            var id = int.Parse(Console.ReadLine());
            var saleEmployee = employeeService.SalesEmployeeFindById(id);

            if (saleEmployee != null)
            {
                Console.WriteLine("Enter sale information:");
                Console.Write("Name: ");
                var name = Console.ReadLine();

                Console.Write("Amount: ");
                var amount = float.Parse(Console.ReadLine());
                employeeService.AddSale(saleEmployee, new Sale(name, amount));

                Console.WriteLine("Sale successfuly added");
            }
            else
            {
                Console.WriteLine("Sales employee not found");
            }
        }
    }
}
