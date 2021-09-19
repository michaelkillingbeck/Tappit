using API.DataAccess.Interfaces;
using API.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.DataAccess.EFCore.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        protected readonly TappitTechnicalTestContext _context;

        public PersonRepository(TappitTechnicalTestContext context)
        {
            _context = context;
        }

        public int Add(Person entity)
        {
            _context.People.Add(entity);
            int changesMade = _context.SaveChanges();

            return changesMade;
        }

        public IQueryable<Person> GetAllReadOnly()
        {
            return _context
                .People
                .Include(person => person.Favouritesports)
                .ThenInclude(favouriteSport => favouriteSport.Sport)
                .AsNoTracking();
        }

        public Person GetById(int id)
        {
            return _context
                .People
                .Include(person => person.Favouritesports)
                .ThenInclude(favouriteSport => favouriteSport.Sport)
                .FirstOrDefault(person => person.Personid == id);
        }

        public Person GetByIdReadOnly(int id)
        {
            return _context
                .People
                .Include(person => person.Favouritesports)
                .ThenInclude(favouriteSport => favouriteSport.Sport)
                .AsNoTracking()
                .FirstOrDefault(person => person.Personid == id);
        }

        public void Remove(Person entity)
        {
            Person removedEntity = _context.People.Remove(entity).Entity;
        }

        public Person Update(Person entity)
        {
            var updatedEntity = _context.People.Update(entity).Entity;
            _context.SaveChanges();

            return updatedEntity;
        }
    }
}
