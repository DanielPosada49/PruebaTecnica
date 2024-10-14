using Microsoft.AspNetCore.Http;
using PruebaTecnica.Application.Common;
using PruebaTecnica.Application.Contracts;
using PruebaTecnica.Application.DataTransferObjects;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Interfaces;

namespace PruebaTecnica.Application.UseCase;  

public class EmployeeUseCase(IUnitOfWork unitOfWork) : IEmployeeUseCase
{
    public Task<ServiceResponseDto> CreateEmployee(Employee employee)
    {
        unitOfWork.EmployeeRepository.Insert(employee);
        unitOfWork.save();
        return Task.FromResult(Utilities.CreateResponse(StatusCodes.Status200OK, true));
    }

    public Task<ServiceResponseDto> DeleteEmployee(int employeeId)
    {
        unitOfWork.EmployeeRepository.Delete(employeeId);
        unitOfWork.save();
        return Task.FromResult(Utilities.CreateResponse(StatusCodes.Status200OK, true));
    }

    public Task<ServiceResponseDto> GetEmployeeById(int id)
    {
        return Task.FromResult(Utilities.CreateResponse(StatusCodes.Status200OK, unitOfWork.GetEmployee(id)));
    }

    public Task<ServiceResponseDto> GetEmployees()
    {
        return Task.FromResult(Utilities.CreateResponse(StatusCodes.Status200OK, unitOfWork.GetEmployees()));
    }

    public Task<ServiceResponseDto> UpdateEmployee(int employee)
    {
        throw new NotImplementedException();
    }
}
