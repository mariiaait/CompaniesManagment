namespace CompaniesManagment.Infrastructure.Exceptions
{
    internal class CompanyException:Exception
    {
        public string ErrorCode { get; private set; }

        public CompanyException() : base()
        {

        }

        public CompanyException(string message) : base(message)
        {

        }

        public CompanyException(string message, string codeError): base(message)
        {
            ErrorCode = codeError;
        }

        public override string ToString()
        {
            string strErr = base.ToString();
            if (string.IsNullOrEmpty(ErrorCode))
            {
                strErr +=$"ErrorCode: {ErrorCode}";
            }

            return strErr;
        }
    }
}
