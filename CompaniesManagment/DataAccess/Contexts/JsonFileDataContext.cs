using CompaniesManagment.DataAccess.Contexts.Interfaces;
using CompaniesManagment.Sharable;
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

        public void ConnectOrDefault()
        {
            if (!File.Exists(Path) || (File.Exists(Path) && new FileInfo(Path).Length == 0))
            {
                using (FileStream fileStream = new FileStream(Path, FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize(fileStream, Configuration.DEFAULT_DATA_JSON, new JsonSerializerOptions { WriteIndented = true });
                }
            }
        }
    }
}
