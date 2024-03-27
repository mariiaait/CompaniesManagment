using CompaniesManagment.Application.Services;
using CompaniesManagment.Application.Services.Interfaces;
using CompaniesManagment.DataAccess.Contexts;
using CompaniesManagment.DataAccess.Domains;
using CompaniesManagment.DataAccess.Repositories;
using CompaniesManagment.DataAccess.Repositories.Interfaces;
using CompaniesManagment.Infrastructure.Initializer;
using CompaniesManagment.Infrastructure.Logging;
using CompaniesManagment.Sharable;

namespace CompaniesManagment
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
           Start();
        }

        private  static void Start()
        {
            JsonFileDataContext context = new JsonFileDataContext(Configuration.RELATIVE_PATH_TO_JSON);
            context.ConnectOrDefault();
            Initializer.Initialize(Configuration.RELATIVE_PATH_TO_TEST_JSON, Configuration.RELATIVE_PATH_TO_JSON);

            IFileRepository repository = new JsonFileRepository(context);
            IFileService service = new JsonFileService(repository, new Logger(Configuration.RELATIVE_PATH_TO_LOGS));

            Console.WriteLine("Testing Get() - list of all companies");
            Console.WriteLine(service.Get().ToString());

            Console.WriteLine("\nTesting GetById");
            Console.WriteLine(service.GetById(new Guid("32e0adfd-d4a5-4bec-9edd-8702ecf737d9")));

            Console.WriteLine("\nTesting GetEmployeesById");
            Console.WriteLine(service.GetEmployeesById(new Guid("32e0adfd-d4a5-4bec-9edd-8702ecf737d8")));

            Console.WriteLine("\nTesting Add - adding new company 987Soft");
            Console.WriteLine(service.Add(new Company { NameCompany = "987Soft", Employees = null }));

            Console.WriteLine(service.Add(new Company { NameCompany = "987Soft", Employees = null }));

            Console.WriteLine("\nTesting Delete - deleted ABCSoft");
            Console.WriteLine(service.Delete(new Guid("e3cdbb36-3d15-4f39-8303-f29b83c745a8")));

            Console.WriteLine("\nTesting Update - updating FGHSoft");
            Console.WriteLine(service.Update(new Company
            {
                Id = new Guid("576a2174-a6bb-4124-a01e-35780d8d4263"),
                NameCompany = "FGHSoft123",
                Employees = null
            }));

            Console.WriteLine("\nTesting Update - updating FGHSoft with random guid");
            Console.WriteLine(service.Update(new Company { NameCompany = "FGHSoft", Employees = null }));
        }
        static void PrintCompanies(List<Company> companies)
        {
            foreach (var company in companies)
            {
                Console.WriteLine(company.NameCompany);
            }
        }

    }
}
