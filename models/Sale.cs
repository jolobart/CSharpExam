namespace CSharpExam
{
    namespace Models
    {
        public class Sale
        {
            public string Name { get; private set; }
            public float Amount { get; private set; }

            public Sale(string name, float amount)
            {
                this.Name = name;
                this.Amount = amount;
            }
        }
    }
}