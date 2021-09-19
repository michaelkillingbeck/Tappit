using System.Collections.Generic;

namespace API.Models.DTOs
{
    public class PersonDetailDTO : PersonDTO
    {
        public IEnumerable<FavouriteSportDTO> FavouriteSports { get; set; }
    }
}
