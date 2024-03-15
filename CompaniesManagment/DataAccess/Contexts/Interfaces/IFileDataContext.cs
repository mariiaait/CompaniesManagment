namespace CompaniesManagment.DataAccess.Contexts.Interfaces
{
    internal interface IFileDataContext
    {
        public string Path { get; set; }

        void ConnectOrDefault();
    }
}
