#nullable disable


namespace API.DataAccess.Models
{
    public partial class FavouriteSport
    {
        public int PersonId { get; set; }
        public int SportId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Sport Sport { get; set; }
    }
}
