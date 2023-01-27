namespace CSharpExam
{
    namespace Models
    {
        public class Employee : Person
        {
            public string EmployeeNumber { get; private set; }
            public float BaseSalary { get; private set; }

            public Employee(int id, string firstName, string lastName, string employeeNumber, float baseSalary) : base(id, firstName, lastName)
            {
                this.EmployeeNumber = employeeNumber;
                this.BaseSalary = baseSalary;
            }

            public virtual float GetSalary()
            {
                return this.BaseSalary;
            }
        }
    }
}