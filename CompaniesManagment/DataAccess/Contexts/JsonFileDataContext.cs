using CompaniesManagment.DataAccess.Contexts.Interfaces;
using CompaniesManagment.DataAccess.Domains;
using System.Text.Json;

namespace CompaniesManagment.DataAccess.Contexts
{
    internal class JsonFileDataContext : IFileDataContext
    {
        public string Path { get; set; }

        public JsonFileDataContext(string path)
        {
            Path = path;
        }

        public void CreateOrDefault()
        {
            Company[] companies = new Company[] { };
            //var data = new { companies };

            

            if (!File.Exists(Path) || (File.Exists(Path) && new FileInfo(Path).Length == 0))
            {
                using (FileStream fileStream = new FileStream(Path, FileMode.OpenOrCreate))
                {
                    var jsonData = JsonSerializer.Serialize(companies, new JsonSerializerOptions { WriteIndented = true });
                }
            }
        }
    }
}
