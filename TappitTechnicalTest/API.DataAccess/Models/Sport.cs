using System.Collections.Generic;

#nullable disable

namespace API.DataAccess.Models
{
    public partial class Sport
    {
        public Sport()
        {
            FavouriteSports = new HashSet<FavouriteSport>();
        }

        public int SportId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ICollection<FavouriteSport> FavouriteSports { get; set; }
    }
}
