using PruebaTecnica.Application.DataTransferObjects;
using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Application.Contracts;

public interface IEmployeeUseCase
{
    Task<ServiceResponseDto> GetEmployees();
    Task<ServiceResponseDto> GetEmployeeById(int id);
    Task<ServiceResponseDto> CreateEmployee(Employee employee);
    Task<ServiceResponseDto> UpdateEmployee(int employee);
    Task<ServiceResponseDto> DeleteEmployee(int employeeId);
}
