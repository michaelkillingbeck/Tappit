using API.Models.DTOs;
using System.Collections.Generic;

namespace API.Interfaces.Services
{
    public interface ISportSummaryService
    {
        IEnumerable<SportFavouriteSummaryDTO> GetAllFavouriteSummaries();
    }
}
