using System.Collections.Generic;

#nullable disable

namespace API.DataAccess.Models
{
    public partial class Person
    {
        public Person()
        {
            FavouriteSports = new HashSet<FavouriteSport>();
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAuthorised { get; set; }
        public bool IsValid { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ICollection<FavouriteSport> FavouriteSports { get; set; }
    }
}
