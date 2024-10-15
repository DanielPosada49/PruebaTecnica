using PruebaTecnica.Application.DataTransferObjects;
using PruebaTecnica.Domain.Request;

namespace PruebaTecnica.Application.Contracts;

public interface IEmployeeUseCase
{
    Task<object> GetEmployees();
    Task<object> GetEmployeeById(int id);
    Task<object> GetEmployeeByDepartmenId(int id);
    Task<object> CreateEmployee(EmployeeRequest employee);
    Task<object> UpdateEmployee(UpdateEmployeeRequest employee);
    Task<object> DeleteEmployee(int employeeId);
}