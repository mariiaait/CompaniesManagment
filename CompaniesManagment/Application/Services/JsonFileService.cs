using CompaniesManagment.Application.Services.Interfaces;
using CompaniesManagment.DataAccess.Domains;
using CompaniesManagment.DataAccess.Repositories.Interfaces;
using CompaniesManagment.Infrastructure.Logging;

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
        public void Add(Company company)
        {
            try
            {
                _repository.Add(company);
                _logger.Info($"New company {company} was added to file.");
            }
            catch(Exception ex) 
            {
                _logger.Error(ex.Message);
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                _repository.Delete(id);
                _logger.Info($"The company with id {id} was deleted from file.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }

        public List<Company>? Get()
        {
            try
            {
                var result = _repository.Get();
                _logger.Info($"The companies got succeful.");
                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public Company? GetById(Guid id)
        {
            try
            {
                var result = _repository.GetById(id);
                _logger.Info($"The company with id {id} was getting.");
                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public List<Employee>? GetEmployeesById(Guid id)
        {
            try
            {
                var result = _repository.GetEmployeesById(id);
                _logger.Info($"The employees with id {id} was getting.");
                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public void Update(Company company)
        {
            try
            {
                _repository.Update(company);
                _logger.Info($"The company {company.NameCompany} was updating.");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }
    }
}
