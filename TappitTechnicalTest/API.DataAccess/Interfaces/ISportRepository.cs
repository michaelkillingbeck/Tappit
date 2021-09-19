using API.DataAccess.Models;
using System.Linq;

namespace API.DataAccess.Interfaces
{
    public interface ISportRepository
    {
        Sport GetById(int id);
        IQueryable<Sport> GetAllReadOnly();
    }
}
