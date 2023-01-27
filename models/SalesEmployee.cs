namespace CSharpExam
{
    namespace Models
    {
        public class SalesEmployee : Employee
        {
            public float Commission { get; private set; }
            private List<Sale> Sales;

            public SalesEmployee(int id, string firstName, string lastName, string employeeNumber, float baseSalary, float commission) : base(id, firstName, lastName, employeeNumber, baseSalary)
            {
                this.Commission = commission;
                this.Sales = new List<Sale>();
            }

            public override float GetSalary()
            {
                float totalSales = Sales.Sum(sale => sale.Amount);
                return base.GetSalary() + this.Commission * totalSales;
            }

            public void AddEmployeeSale(Sale s)
            {
                this.Sales.Add(s);
            }

            public List<Sale> GetSales()
            {
                return this.Sales;
            }
        }
    }
}