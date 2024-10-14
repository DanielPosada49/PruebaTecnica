using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Employee> EmployeeRepository { get; }
    object GetEmployees();
    object GetEmployee(int id);
    Employee SetEmployee(Employee employee);
    Employee UpdateEmployee(Employee employee);
    Employee DeleteEmpployee(int id);
    void save();
}
