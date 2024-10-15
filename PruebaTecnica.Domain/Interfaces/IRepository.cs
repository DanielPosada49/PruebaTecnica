namespace PruebaTecnica.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    T GetByID(object id);
    void Insert(T entity);
    void Delete(object id);
    void Delete(T entityToDelete);
    void Update(T entityToUpdate);
}