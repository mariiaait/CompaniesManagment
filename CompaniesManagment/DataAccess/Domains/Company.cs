namespace CompaniesManagment.DataAccess.Domains
{
    internal class Company
    {
        public Company()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string NameCompany { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
