using System.Collections.Generic;

#nullable disable

namespace API.DataAccess.Models
{
    public partial class Sport
    {
        public Sport()
        {
            Favouritesports = new HashSet<Favouritesport>();
        }

        public int Sportid { get; set; }
        public string Name { get; set; }
        public bool Isenabled { get; set; }

        public virtual ICollection<Favouritesport> Favouritesports { get; set; }
    }
}
