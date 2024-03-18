using CompaniesManagment.DataAccess.Contexts.Interfaces;
using CompaniesManagment.DataAccess.Domains;
using CompaniesManagment.DataAccess.Repositories.Interfaces;
using System.Text.Json;

namespace CompaniesManagment.DataAccess.Repositories
{
    internal class JsonFileRepository : IFileRepository
    {
        private IFileDataContext _context;

        public JsonFileRepository(IFileDataContext context)
        {
            _context = context;
        }

        public void Add(Company company)
        {
            var companies = Get();
            if(!companies.Any(currentCompany => currentCompany.NameCompany == company.NameCompany))
            {
                companies.Add(company);
                Serialize(companies);
            }
        }

        public void Delete(Guid id)
        {
            var companies = Get();
            var company = companies?.FirstOrDefault(company => company.Id == id);
            if (company != null) { companies.Remove(company); }
            Serialize(companies);
        }

        public List<Company>? Get()
        {
            using (FileStream fileStream = new FileStream(_context.Path, FileMode.Open))
            {
               return JsonSerializer.Deserialize<List<Company>>(fileStream);
            }
        }

        public Company? GetById(Guid id)
        {
            return Get()?.FirstOrDefault(company => company.Id == id);
        }

        public List<Employee>? GetEmployeesById(Guid id)
        {
            return Get()?.FirstOrDefault(company => company.Id == id)?.Employees;
        }

        public void Update(Company company)
        {
            throw new NotImplementedException();
        }

        private void Serialize(List<Company> companies)
        {
            using (FileStream fileStream = new FileStream(_context.Path, FileMode.Create))
            {
                JsonSerializer.Serialize(fileStream, companies, new JsonSerializerOptions {WriteIndented = true});
            }
        }
    }
}
