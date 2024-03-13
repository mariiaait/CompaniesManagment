using CompaniesManagment.DataAccess.Contexts;
using CompaniesManagment.Infrastructure.Initializer;

namespace CompaniesManagment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\Tools\data.json";
            string testToolsPath = @"..\..\..\Tools\TestTools\testData.json";
            //string path = Path.Combine(Directory.GetCurrentDirectory(), "Tools") + "\\data.json";

            JsonFileDataContext jsonFileContext = new JsonFileDataContext(path);
            jsonFileContext.CreateOrDefault();
            Initializer.Initialize(path, testToolsPath);
        }
    }
}
