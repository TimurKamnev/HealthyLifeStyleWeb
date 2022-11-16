using StudentManager.Backend.Entities;

namespace StudentManager.Backend.Repositories;

public class FileRepository<T> : IRepository<T> where T : BaseEntity 
{
    public T Create(T entity)
    {
        throw new NotImplementedException();
    }

    public List<T> ReadAll()
    {
        throw new NotImplementedException();
    }

    public T ReadById(int id)
    {
        throw new NotImplementedException();
    }

    public T Update(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}