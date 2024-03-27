using CompaniesManagment.DataAccess.Contexts.Interfaces;
using CompaniesManagment.DataAccess.Domains;
using CompaniesManagment.DataAccess.Repositories.Interfaces;
using CompaniesManagment.Infrastructure.Exceptions;
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
            else
            {
                throw new CompanyException("Company with such name already exists.");
            }
        }

        public void Delete(Guid id)
        {
            var companies = Get();
            var company = companies?.FirstOrDefault(company => company.Id == id);
            if (company != null) { companies.Remove(company); }
            else
            {
                throw new CompanyException("Company with such id doesn't exist.");
            }
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
            var companies = Get();
            if (companies.Any(currentCompany => currentCompany.Id == company.Id))
            {
                Serialize(companies.Select(currentCompany => 
                currentCompany.Id == company.Id ? company : currentCompany).ToList());
                return;
            }

            if (!companies.Any(currentCompany => currentCompany.NameCompany == company.NameCompany))
            {
                companies.Add(company);
                Serialize(companies);
            }
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
