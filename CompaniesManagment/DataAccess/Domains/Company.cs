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

        private string GetCompanyDataToString()
        {
            if (Employees == null)
            {
                return "empty";
            }
            else
            {
                return string.Join(",\n", Employees.Where(empl => empl.Id != null));
            }
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {NameCompany}, Employees: {GetCompanyDataToString()}";
        }
    }
}
