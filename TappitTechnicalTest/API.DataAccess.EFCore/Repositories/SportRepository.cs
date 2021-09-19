using API.DataAccess.Interfaces;
using API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.DataAccess.EFCore.Repositories
{
    public class SportRepository : ISportRepository
    {
        protected readonly TappitTechnicalTestContext _context;

        public SportRepository(TappitTechnicalTestContext context)
        {
            _context = context;
        }

        public IQueryable<Sport> GetAllReadOnly()
        {
            return _context
                .Sports
                .Include(sport => sport.Favouritesports)
                .AsNoTracking();
        }

        public Sport GetById(int id)
        {
            return _context
                .Sports
                .AsNoTracking()
                .FirstOrDefault(sport => sport.Sportid == id);
        }
    }
}
