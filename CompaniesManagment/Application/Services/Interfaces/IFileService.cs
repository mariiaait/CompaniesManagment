using CompaniesManagment.DataAccess.Domains;
using CompaniesManagment.Presentation.ResponseModel;

namespace CompaniesManagment.Application.Services.Interfaces
{
    internal interface IFileService
    {
        ResponseModel<List<Company>>? Get();
        ResponseModel<bool> Add(Company company);
        ResponseModel<bool> Update(Company company);
        ResponseModel<bool> Delete(Guid id);
        ResponseModel<Company>? GetById(Guid id);
        ResponseModel<List<Employee>>? GetEmployeesById(Guid id);
    }
}
