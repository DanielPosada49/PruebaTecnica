using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<TblEmployee> EmployeeRepository { get; }
    IRepository<TblDepartment> DepartmenRepository { get; }
    IRepository<TblProject> ProjectRepository { get; }
    IRepository<TblPositionHistory> PositionHistory { get; }
    object GetEmployees();
    object GetEmployee(int id);
    object GetEmployeeByDepartment(int id);
    TblEmployee SetEmployee(TblEmployee employee);
    TblEmployee UpdateEmployee(TblEmployee employee);
    TblEmployee DeleteEmpployee(int id);
    TblPositionHistory GetPositionByEmployeeId(int id);
    void save();
}
