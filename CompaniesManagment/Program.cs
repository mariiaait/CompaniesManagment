using CompaniesManagment.DataAccess.Contexts;
using CompaniesManagment.DataAccess.Domains;
using CompaniesManagment.DataAccess.Repositories;
using CompaniesManagment.DataAccess.Repositories.Interfaces;
using CompaniesManagment.Infrastructure.Initializer;
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
            printCompanies();


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
            printCompanies();


            Console.WriteLine("\nTesting Delete - deleted ABCSoft");
            repository.Delete(new Guid("e3cdbb36-3d15-4f39-8303-f29b83c745a8"));
            printCompanies();


            void printCompanies()
            {
                var companies = repository.Get();

                foreach (var company in companies)
                {
                    Console.WriteLine(company.NameCompany);
                }
            }
        }
    }
}
