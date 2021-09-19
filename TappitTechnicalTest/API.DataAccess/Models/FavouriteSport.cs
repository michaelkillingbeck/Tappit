#nullable disable

namespace API.DataAccess.Models
{
    public partial class Favouritesport
    {
        public int Personid { get; set; }
        public int Sportid { get; set; }

        public virtual Person Person { get; set; }
        public virtual Sport Sport { get; set; }
    }
}
