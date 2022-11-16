using StudentManager.Backend.Entities;

namespace StudentManager.Backend.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    public T Create(T entity);
    public List<T> ReadAll();
    public T ReadById(int id);
    public T Update(T entity);
    public void Delete(T entity);
    public void DeleteById(int id);
}