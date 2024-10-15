using PruebaTecnica.Application.Contracts;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Interfaces;
using PruebaTecnica.Domain.Request;

namespace PruebaTecnica.Application.UseCase;  

public class EmployeeUseCase(IUnitOfWork unitOfWork, IPositionHistoryUseCase positionHistoryUseCase) : IEmployeeUseCase
{
    public Task<object> CreateEmployee(EmployeeRequest employeeRequest)
    {
        TblEmployee employee = new TblEmployee(){
            DocumentId = employeeRequest.Document,
            Name = employeeRequest.Name,
            CurrentPosition = employeeRequest.CurrentPosition,
            Salary = employeeRequest.Salary,
            DepartmentId = employeeRequest.DepartmentId,
            ProjectId = employeeRequest.ProjectId
        };

        try{
            unitOfWork.EmployeeRepository.Insert(employee);
            unitOfWork.save();
        }catch(Exception ex){
            throw new Exception("Error al crear el empleado", ex);
        }

        positionHistoryUseCase.AddHistory(employeeRequest.Document, employeeRequest.CurrentPosition);

        return Task.FromResult((object)true);
    }
    public Task<object> DeleteEmployee(int employeeId)
    {
        unitOfWork.EmployeeRepository.Delete(employeeId);
        unitOfWork.save();
        return Task.FromResult((object)true);
    }
    public Task<object> GetEmployeeById(int id)
    {
        return Task.FromResult(unitOfWork.GetEmployee(id));
    }
    public Task<object> GetEmployeeByDepartmenId(int id)
    {
        return Task.FromResult(unitOfWork.GetEmployeeByDepartment(id));
    }
    public Task<object> GetEmployees()
    {
        return Task.FromResult(unitOfWork.GetEmployees());
    }
    public Task<object> UpdateEmployee(UpdateEmployeeRequest employee)
    {
        TblEmployee query = unitOfWork.EmployeeRepository.GetByID(int.Parse(employee.Document));
        if(query == null){
            return Task.FromResult((object)false);
        }
        TblEmployee updateEmployee = query;
        updateEmployee.CurrentPosition = DefineCurrentPosition(query, employee);
        updateEmployee.Salary = (employee.Salary > 0) ? employee.Salary : query.Salary;
        updateEmployee.DepartmentId = (employee.DepartmentId > 0) ? employee.DepartmentId : query.DepartmentId;
        updateEmployee.ProjectId = (employee.ProjectId > 0) ? employee.ProjectId : query.ProjectId;

        unitOfWork.EmployeeRepository.Update(updateEmployee);
        unitOfWork.save();
        return Task.FromResult((object)true);
    }
    private void UpdatePositionHistory(UpdateEmployeeRequest employee){

        int Document = int.Parse(employee.Document);
        try{
            positionHistoryUseCase.UpdateHistoryEndDate(Document);
            positionHistoryUseCase.AddHistory(Document, employee.CurrentPosition);
        }catch{
            positionHistoryUseCase.AddHistory(Document, employee.CurrentPosition);
        }
    }
    private string DefineCurrentPosition(TblEmployee Current, UpdateEmployeeRequest Request){
        if(Request.CurrentPosition != null){
            if(Current.CurrentPosition != Request.CurrentPosition){
                UpdatePositionHistory(Request);
                return Request.CurrentPosition;
            }
        }
        return Current.CurrentPosition;
    }
}
