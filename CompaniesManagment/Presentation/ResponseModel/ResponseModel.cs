namespace CompaniesManagment.Presentation.ResponseModel
{
    internal class ResponseModel<T>
    {
        private readonly bool _isSuccess;
        private readonly T _response;
        private readonly Exception _error;

        public ResponseModel(bool isSuccess, T response, Exception error)
        {
            _isSuccess = isSuccess;
            _response = response;
            _error = error;
        }

        public override string ToString()
        {
            return $"isSuccess: {_isSuccess}, response: {_response}, error: {_error}";
        }
    }
}