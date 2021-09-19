using API.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.DataAccess.Interfaces
{
    public interface ISportRepository
    {
        Sport GetById(int id);
        IQueryable<Sport> GetAllReadOnly();
    }
}
