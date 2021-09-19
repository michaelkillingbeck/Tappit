using API.Models.DTOs;
using System.Collections.Generic;

namespace API.Interfaces.Services
{
    public interface IPersonService
    {
        IEnumerable<PersonSummaryDTO> GetAllPeople();
        PersonDetailDTO GetById(int id);
        bool Update(PersonDetailDTO personToUpdate);
    }
}
