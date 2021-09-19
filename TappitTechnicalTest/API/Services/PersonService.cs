using API.DataAccess.Interfaces;
using API.DataAccess.Models;
using API.Interfaces.Services;
using API.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ISportRepository _sportRepository;

        public PersonService(IPersonRepository personRepository, ISportRepository sportRepository)
        {
            _personRepository = personRepository;
            _sportRepository = sportRepository;
        }

        public IEnumerable<PersonSummaryDTO> GetAllPeople()
        {
            var people = _personRepository
                .GetAllReadOnly()
                .ToList()
                .Select(person => new PersonSummaryDTO
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Id = person.PersonId,
                    IsEnabled = person.IsEnabled,
                    IsAuthorised = person.IsAuthorised,
                    IsValid = person.IsValid,
                    FavouriteSports = person.FavouriteSports.Select(sport => sport.Sport.Name),
                });

            return people;
        }

        public PersonDetailDTO GetById(int id)
        {
            var allSports = _sportRepository.GetAllReadOnly().ToList();
            var person = _personRepository
                .GetById(id);
            var favouriteSports = person.FavouriteSports;

            return new PersonDetailDTO
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Id = person.PersonId,
                IsEnabled = person.IsEnabled,
                IsAuthorised = person.IsAuthorised,
                IsValid = person.IsValid,
                FavouriteSports = allSports.Select(sport => new FavouriteSportDTO
                {
                    Active = favouriteSports.Any(favourite => sport.SportId == favourite.SportId),
                    Id = sport.SportId,
                    Name = sport.Name,
                })
            };
        }

        public bool Update(PersonDetailDTO personToUpdate)
        {
            var existingEntity = _personRepository.GetById(personToUpdate.Id);

            existingEntity.IsValid = personToUpdate.IsValid;
            existingEntity.FirstName = personToUpdate.FirstName;
            existingEntity.LastName = personToUpdate.LastName;
            existingEntity.IsAuthorised = personToUpdate.IsAuthorised;
            existingEntity.IsEnabled = personToUpdate.IsEnabled;
            existingEntity.FavouriteSports = null;

            var updatedEntity = _personRepository.Update(existingEntity);

            return updatedEntity != null;
        }
    }
}
