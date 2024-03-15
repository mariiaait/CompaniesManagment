using CompaniesManagment.DataAccess.Domains;

namespace CompaniesManagment.DataAccess.Repositories.Interfaces
{
    internal interface IFileRepository
    {
        List<Company> Get();
        void Add(Company company);
        void Update(Company company);
        void Delete(Company company);
        Company GetById(int id);

    }
}
