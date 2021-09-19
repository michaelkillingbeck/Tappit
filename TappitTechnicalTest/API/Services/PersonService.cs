using API.DataAccess.Interfaces;
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
                    FirstName = person.Firstname,
                    LastName = person.Lastname,
                    Id = person.Personid,
                    IsEnabled = person.Isenabled,
                    IsAuthorised = person.Isauthorised,
                    IsValid = person.Isvalid,
                    FavouriteSports = person.Favouritesports.Select(sport => sport.Sport.Name),
                });

            return people;
        }

        public PersonDetailDTO GetById(int id)
        {
            var allSports = _sportRepository.GetAllReadOnly().ToList();
            var person = _personRepository
                .GetById(id);
            var favouriteSports = person.Favouritesports;

            return new PersonDetailDTO
            {
                FirstName = person.Firstname,
                LastName = person.Lastname,
                Id = person.Personid,
                IsEnabled = person.Isenabled,
                IsAuthorised = person.Isauthorised,
                IsValid = person.Isvalid,
                FavouriteSports = allSports.Select(sport => new FavouriteSportDTO
                {
                    Active = favouriteSports.Any(favourite => sport.Sportid == favourite.Sportid),
                    Id = sport.Sportid,
                    Name = sport.Name,
                })
            };
        }

        public bool Update(PersonDetailDTO personToUpdate)
        {
            var existingEntity = _personRepository.GetById(personToUpdate.Id);

            existingEntity.Isvalid = personToUpdate.IsValid;
            existingEntity.Firstname = personToUpdate.FirstName;
            existingEntity.Lastname = personToUpdate.LastName;
            existingEntity.Isauthorised = personToUpdate.IsAuthorised;
            existingEntity.Isenabled = personToUpdate.IsEnabled;

            var updatedEntity = _personRepository.Update(existingEntity);

            return updatedEntity != null;
        }
    }
}
