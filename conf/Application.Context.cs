using CSharpExam.Models;

namespace CSharpExam.Conf
{
    public class ApplicationContext
    {
        private List<Employee> EmployeeLists;

        private static ApplicationContext instance = null;

        public static ApplicationContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationContext();
                }
                return instance;
            }
        }

        public ApplicationContext()
        {
            this.EmployeeLists = new List<Employee>();
        }

        public List<Employee> GetEmployeeLists()
        {
            return this.EmployeeLists;
        }
    }
}