using CompaniesManagment.DataAccess.Contexts;
using CompaniesManagment.DataAccess.Domains;
using CompaniesManagment.DataAccess.Repositories;
using CompaniesManagment.DataAccess.Repositories.Interfaces;
using CompaniesManagment.Infrastructure.Initializer;
using CompaniesManagment.Sharable;
using System.Text.Json;

namespace CompaniesManagment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JsonFileDataContext context = new JsonFileDataContext(Configuration.RELATIVE_PATH_TO_JSON);
            context.ConnectOrDefault();
            Initializer.Initialize(Configuration.RELATIVE_PATH_TO_TEST_JSON, Configuration.RELATIVE_PATH_TO_JSON);

            IFileRepository repository = new JsonFileRepository(context);

            var companies = repository.Get();

            foreach(var company in companies)
            {
                Console.WriteLine(company.NameCompany);
            }
        }
    }
}
