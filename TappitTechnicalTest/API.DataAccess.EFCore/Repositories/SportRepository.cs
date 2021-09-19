using API.DataAccess.Interfaces;
using API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                .Include(sport => sport.FavouriteSports)
                .AsNoTracking();
        }

        public Sport GetById(int id)
        {
            return _context
                .Sports
                .AsNoTracking()
                .FirstOrDefault(sport => sport.SportId == id);
        }
    }
}
