using CompaniesManagment.DataAccess.Domains;

namespace CompaniesManagment.Sharable
{
    internal static class Configuration
    {
        public static string RELATIVE_PATH_TO_JSON { get; }  = @"..\..\..\Tools\data.json";
        public static string RELATIVE_PATH_TO_TEST_JSON { get; } = @"..\..\..\Tools\TestTools\testData.json";

        public static List<Company> DEFAULT_DATA_JSON = new List<Company> {};
    }
}
