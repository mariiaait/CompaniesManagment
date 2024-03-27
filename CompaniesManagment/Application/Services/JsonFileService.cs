using CompaniesManagment.Application.Services.Interfaces;
using CompaniesManagment.DataAccess.Domains;
using CompaniesManagment.DataAccess.Repositories.Interfaces;
using CompaniesManagment.Infrastructure.Logging;
using CompaniesManagment.Presentation.ResponseModel;

namespace CompaniesManagment.Application.Services
{
    internal class JsonFileService : IFileService
    {
        private readonly IFileRepository _repository;
        private readonly Logger _logger;

        public JsonFileService(IFileRepository repository, Logger logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public ResponseModel<bool> Add(Company company)
        {
            try
            {
                _repository.Add(company);
                _logger.Info($"New company {company} was added to file.");
                return new ResponseModel<bool>(true, true, null);
            }
            catch(Exception ex) 
            {
                _logger.Error(ex.Message);
                return new ResponseModel<bool>(false, false, ex);
            }
        }

        public ResponseModel<bool> Delete(Guid id)
        {
            try
            {
                _repository.Delete(id);
                _logger.Info($"The company with id {id} was deleted from file.");
                return new ResponseModel<bool>(true, true, null);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new ResponseModel<bool>(false, false, ex);
            }
        }

        public ResponseModel<List<Company>>? Get()
        {
            try
            {
                List<Company>? result = _repository.Get();
                _logger.Info($"The companies got succeful.");
                return new ResponseModel<List<Company>>(true, result, null);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new ResponseModel<List<Company>>(false, null, ex);
            }
        }

        public ResponseModel<Company>? GetById(Guid id)
        {
            try
            {
                var result = _repository.GetById(id);
                _logger.Info($"The company with id {id} was getting.");
                return new ResponseModel<Company>(true, result, null);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new ResponseModel<Company>(false, null, ex);
            }
        }

        public ResponseModel<List<Employee>>? GetEmployeesById(Guid id)
        {
            try
            {
                var result = _repository.GetEmployeesById(id);
                _logger.Info($"The employees with id {id} was getting.");
                return new ResponseModel<List<Employee>>(true, result, null); ;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new ResponseModel<List<Employee>>(false, null, ex);
            }
        }

        public ResponseModel<bool> Update(Company company)
        {
            try
            {
                _repository.Update(company);
                _logger.Info($"The company {company.NameCompany} was updating.");
                return new ResponseModel<bool>(true, true, null);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new ResponseModel<bool>(false, false, ex);
            }
        }
    }
}
