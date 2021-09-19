using API.DataAccess.Models;
using System.Linq;

namespace API.DataAccess.Interfaces
{
    public interface IPersonRepository    {
        int Add(Person entity);
        IQueryable<Person> GetAllReadOnly();
        Person GetById(int id);
        Person GetByIdReadOnly(int id);
        void Remove(Person entity);
        Person Update(Person entity);
    }
}
