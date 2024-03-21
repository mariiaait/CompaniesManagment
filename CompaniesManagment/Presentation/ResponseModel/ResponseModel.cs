namespace CompaniesManagment.Presentation.ResponseModel
{
    internal class ResponseModel<T>
    {
        private readonly bool _isSuccess;
        private readonly T _response;
        private readonly List<Exception> _errors;

        public ResponseModel(bool isSuccess, T response, List<Exception> errors)
        {
            _isSuccess = isSuccess;
            _response = response;
            _errors = errors;
        }
    }
}