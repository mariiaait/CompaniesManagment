using CompaniesManagment.DataAccess.Domains;

namespace CompaniesManagment.Application.Services.Interfaces
{
    internal interface IFileService
    {
        List<Company>? Get();
        void Add(Company company);
        void Update(Company company);
        void Delete(Guid id);
        Company? GetById(Guid id);
        List<Employee>? GetEmployeesById(Guid id);
    }
}
