using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Interfaces;
using PruebaTecnica.Infrastructure.Respository.Base;

namespace PruebaTecnica.Infrastructure.Respository;

public class UnitOfWork : IUnitOfWork
{
    private readonly PruebaTecnicaContext _context;
    private IRepository<TblEmployee> employeeRepository;
    private IRepository<TblDepartment> departmenRepository;
    private IRepository<TblProject> projectRepository;
    private IRepository<TblPositionHistory> positionHistoryRepository;
    private bool disposed = false;

    public UnitOfWork(PruebaTecnicaContext context){
        _context = context;
    }
    public IRepository<TblEmployee> EmployeeRepository {
        get{
            if(this.employeeRepository == null){
                this.employeeRepository = new BaseRespository<TblEmployee>(_context);
            }
            return employeeRepository;
        }
    }
    public IRepository<TblDepartment> DepartmenRepository {
        get{
            if(this.departmenRepository == null){
                this.departmenRepository = new BaseRespository<TblDepartment>(_context);
            }
            return departmenRepository;
        }
    }
    public IRepository<TblProject> ProjectRepository {
        get{
            if(this.projectRepository == null){
                this.projectRepository = new BaseRespository<TblProject>(_context);
            }
            return projectRepository;
        }
    }
    public IRepository<TblPositionHistory> PositionHistory {
        get{
            if(this.positionHistoryRepository == null){
                this.positionHistoryRepository = new BaseRespository<TblPositionHistory>(_context);
            }
            return positionHistoryRepository;
        }
    }
    public TblEmployee DeleteEmpployee(int id)
    {
        throw new NotImplementedException();
    }
    public object GetEmployee(int id)
    {
        var query = (from x in _context.Employees
                        where x.DocumentId == id
                        select new {
                            x.DocumentId,
                            x.Name,
                            x.CurrentPosition,
                            Department = (from y in _context.Departments where (y.Id.Equals(x.DepartmentId)) select y.Name).First(),
                            x.Salary,
                            Project = (from a in _context.Projects where (a.Id.Equals(x.ProjectId)) select a.Name).First(),
                            PositionHistory = (from z in _context.PositionHistories where (z.DocumentId.Equals(x.DocumentId)) select z).ToList()
                        }).ToList();

        return query.First();
    }
    public object GetEmployeeByDepartment(int id)
    {
        var query = (from x in _context.Employees
                        where (x.DepartmentId == id)
                        select new {
                            x.DocumentId,
                            x.Name,
                            x.CurrentPosition,
                            x.Salary,
                            Project = (from a in _context.Projects where (a.Id.Equals(x.ProjectId)) select a.Name).ToList()
                        }).ToList();

        return query;
    }
    public object GetEmployees()
    {
        var query = (from x in _context.Employees
                        select new {
                            x.DocumentId,
                            x.Name,
                            x.CurrentPosition,
                            Department = (from y in _context.Departments where (y.Id.Equals(x.DepartmentId)) select y.Name).First(),
                            x.Salary,
                            Project = (from a in _context.Projects where (a.Id.Equals(x.ProjectId)) select a.Name).First(),
                            PositionHistory = (from z in _context.PositionHistories where (z.DocumentId.Equals(x.DocumentId)) select z).ToList()
                        }).ToList();

        return query;
    }
    public TblEmployee SetEmployee(TblEmployee employee)
    {
        throw new NotImplementedException();
    }
    public TblEmployee UpdateEmployee(TblEmployee employee)
    {
        throw new NotImplementedException();
    }
    public TblPositionHistory GetPositionByEmployeeId(int id){

        var query = (from x in _context.PositionHistories
                        where (x.DocumentId == id && x.EndDate == null)
                        select x );

        return query.First();
    }
    public void save()
    {
        _context.SaveChanges();
    }
    protected virtual void Dispose(bool disposing){
        if(!this.disposed && disposing){
            _context.Dispose();
        }
        this.disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
