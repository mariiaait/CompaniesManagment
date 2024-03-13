using CompaniesManagment.DataAccess.Contexts;
using CompaniesManagment.DataAccess.Domains;
using CompaniesManagment.Infrastructure.Initializer;
using System.Text.Json;

namespace CompaniesManagment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\Tools\data.json";
            string testToolsPath = @"..\..\..\Tools\TestTools\testData.json";

            JsonFileDataContext jsonFileContext = new JsonFileDataContext(path);
            jsonFileContext.CreateOrDefault();
            Initializer.Initialize(testToolsPath, path);
        }
    }
}
