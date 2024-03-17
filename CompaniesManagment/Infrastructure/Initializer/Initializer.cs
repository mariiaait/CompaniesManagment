using CompaniesManagment.DataAccess.Domains;
using System.Text.Json;

namespace CompaniesManagment.Infrastructure.Initializer
{
    internal static class Initializer
    {
        public static void Initialize(string fromFile, string toFile)
        {
            List<Company>? deserializedData = null;

            using (FileStream fileStream = new FileStream(fromFile, FileMode.Open))
            {
               deserializedData = JsonSerializer.Deserialize<List<Company>>(fileStream);
            }
            // Tmp note: https://stackoverflow.com/questions/52020383/filestreams-filemode-openorcreate-overwrites-file
            using (FileStream fileStream = new FileStream(toFile, FileMode.Create))
            {
                JsonSerializer.Serialize(fileStream, deserializedData, new JsonSerializerOptions{
                    WriteIndented = true });
            }
        }
    }
}
