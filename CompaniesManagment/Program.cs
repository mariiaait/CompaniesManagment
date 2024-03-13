using CompaniesManagment.DataAccess.Contexts;
using CompaniesManagment.Infrastructure.Initializer;
using CompaniesManagment.Sharable;

namespace CompaniesManagment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JsonFileDataContext jsonFileContext = new JsonFileDataContext(Configuration.RELATIVE_PATH_TO_JSON);
            jsonFileContext.ConnectOrDefault();
            Initializer.Initialize(Configuration.RELATIVE_PATH_TO_TEST_JSON, Configuration.RELATIVE_PATH_TO_JSON);
        }
    }
}
