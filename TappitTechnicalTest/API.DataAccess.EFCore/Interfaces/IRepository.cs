using System.Linq;

namespace API.DataAccess.EFCore.Interfaces
{
    internal interface IRepository<T> where T : class
    {
        T GetById(int id);
        IQueryable<T> GetAllReadOnly();
        int Add(T entity);
        void Remove(T entity);
    }
}
