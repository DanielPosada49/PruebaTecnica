using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Domain.Interfaces;

namespace PruebaTecnica.Infrastructure.Respository.Base;

public class BaseRespository<T> : IRepository<T> where T : class
{
    internal PruebaTecnicaContext _context;
    internal DbSet<T> dbSet;

    public BaseRespository(PruebaTecnicaContext context){
        this._context = context;
        this.dbSet = _context.Set<T>();
    }

    public virtual void Delete(object id)
    {
        try{
            T entityToDelete = dbSet.Find(id);
            if(entityToDelete != null){
                Delete(entityToDelete);
            }
        }catch(Exception ex){
            throw new Exception("Error al eliminar el ID", ex);
        }
    }
    public virtual void Delete(T entityToDelete)
    {
        try{
            if(_context.Entry(entityToDelete).State == EntityState.Detached){
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }catch(Exception ex){
            throw new Exception("Error al eliminar el elemento", ex);
        }
    }
    public virtual T GetByID(object id)
    {
        try{
            return dbSet.Find(id);
        }catch(Exception ex){
            throw new Exception("Error al consultar el ID", ex);
        }
    }
    public virtual void Insert(T entity)
    {
        try{
            dbSet.Add(entity);
        }catch(Exception ex){
            throw new Exception("Error al consultar el elemento", ex);
        }
    }
    public virtual void Update(T entityToUpdate)
    {
        try{
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }catch(Exception ex){
            throw new Exception("Error al actualizar el elemento", ex);
        }
    }
}
