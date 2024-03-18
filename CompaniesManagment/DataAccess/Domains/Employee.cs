namespace CompaniesManagment.DataAccess.Domains
{
    internal class Employee
    {
        public Employee()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}, Position: {Position}";
        }
    }
}
