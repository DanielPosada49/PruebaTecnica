using System.Linq;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Interfaces;
using PruebaTecnica.Infrastructure.Respository.Base;

namespace PruebaTecnica.Infrastructure.Respository;

public class UnitOfWork : IUnitOfWork
{
    private readonly PruebaTecnicaContext _context;
    private IRepository<Employee> employeeRepository;

    public UnitOfWork(PruebaTecnicaContext context){
        _context = context;
    }

    public IRepository<Employee> EmployeeRepository {
        get{
            if(this.employeeRepository == null){
                this.employeeRepository = new BaseRespository<Employee>(_context);
            }
            return employeeRepository;
        }
    }

    public Employee DeleteEmpployee(int id)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public object GetEmployee(int id)
    {
        var query = (from x in _context.Employees
                        where x.Id == id
                        select new {
                            x.Id,
                            x.Name,
                            x.CurrentPosition,
                            Department = (from y in _context.Departments where (y.Id.Equals(x.DepartmentId)) select y.Name).First(),
                            x.Salary,
                            Project = (from a in _context.Projects where (a.Id.Equals(x.ProjectId)) select a.Name).First(),
                            PositionHistory = (from z in _context.PositionHistories where (z.EmployeeId.Equals(x.Id)) select z).ToList()
                        }).ToList();

        return query.First();
    }

    public object GetEmployees()
    {
        var query = (from x in _context.Employees
                        select new {
                            x.Id,
                            x.Name,
                            x.CurrentPosition,
                            Department = (from y in _context.Departments where (y.Id.Equals(x.DepartmentId)) select y.Name).First(),
                            x.Salary,
                            Project = (from a in _context.Projects where (a.Id.Equals(x.ProjectId)) select a.Name).First(),
                            PositionHistory = (from z in _context.PositionHistories where (z.EmployeeId.Equals(x.Id)) select z).ToList()
                        }).ToList();

        return query;
    }

    public void save()
    {
        _context.SaveChanges();
    }

    public Employee SetEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Employee UpdateEmployee(Employee employee)
    {
        throw new NotImplementedException();
    }
}
