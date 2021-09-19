using System.Collections.Generic;

namespace API.Models.DTOs
{
    public class PersonSummaryDTO : PersonDTO
    {
        public IEnumerable<string> FavouriteSports { get; set; }
    }
}
