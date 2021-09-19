using System.Collections.Generic;

#nullable disable

namespace API.DataAccess.Models
{
    public partial class Person
    {
        public Person()
        {
            Favouritesports = new HashSet<Favouritesport>();
        }

        public int Personid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool Isauthorised { get; set; }
        public bool Isvalid { get; set; }
        public bool Isenabled { get; set; }

        public virtual ICollection<Favouritesport> Favouritesports { get; set; }
    }
}
