using CompaniesManagment.Application.Services;
using CompaniesManagment.Application.Services.Interfaces;
using CompaniesManagment.DataAccess.Contexts;
using CompaniesManagment.DataAccess.Domains;
using CompaniesManagment.DataAccess.Repositories;
using CompaniesManagment.DataAccess.Repositories.Interfaces;
using CompaniesManagment.Infrastructure.Initializer;
using CompaniesManagment.Infrastructure.Logging;
using CompaniesManagment.Infrastructure.Logging.LogLevels;
using CompaniesManagment.Sharable;

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

            Console.WriteLine("Testing Get() - list of all companies");
            PrintCompanies(repository.Get());


            Console.WriteLine("\nTesting GetById");
            Console.WriteLine(repository.GetById(new Guid("32e0adfd-d4a5-4bec-9edd-8702ecf737d8"))?.NameCompany);


            Console.WriteLine("\nTesting GetEmployeesById");
            var employees = repository.GetEmployeesById(new Guid("32e0adfd-d4a5-4bec-9edd-8702ecf737d8"));
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }


            Console.WriteLine("\nTesting Add - adding new company 987Soft");
            repository.Add(new Company { NameCompany = "987Soft", Employees = null });
            PrintCompanies(repository.Get());


            Console.WriteLine("\nTesting Delete - deleted ABCSoft");
            repository.Delete(new Guid("e3cdbb36-3d15-4f39-8303-f29b83c745a8"));
            PrintCompanies(repository.Get());


            Console.WriteLine("\nTesting Update - updating FGHSoft");
            repository.Update(new Company {Id= new Guid("576a2174-a6bb-4124-a01e-35780d8d4263"),
                NameCompany = "FGHSoft123", Employees = null });
            PrintCompanies(repository.Get());

            Console.WriteLine("\nTesting Update - updating FGHSoft with random guid");
            repository.Update(new Company {NameCompany = "FGHSoft", Employees = null });
            PrintCompanies(repository.Get());

            Logger logger = new Logger(Configuration.RELATIVE_PATH_TO_LOGS);
            IFileService service = new JsonFileService(repository, logger);

            service.Add(new Company { NameCompany = "Soft987", Employees = null });
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
