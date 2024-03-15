using CompaniesManagment.DataAccess.Contexts;
using CompaniesManagment.DataAccess.Contexts.Interfaces;
using CompaniesManagment.DataAccess.Domains;
using CompaniesManagment.DataAccess.Repositories.Interfaces;
using CompaniesManagment.Sharable;
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
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Company>? Get()
        {
            using (FileStream fileStream = new FileStream(_context.Path, FileMode.Open))
            {
               return JsonSerializer.Deserialize<List<Company>>(fileStream);
            }
        }

        public Company GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeesById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
