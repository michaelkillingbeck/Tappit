using API.DataAccess.Interfaces;
using API.Interfaces.Services;
using API.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    internal class SportSummaryService : ISportSummaryService
    {
        private readonly ISportRepository _sportRepository;

        public SportSummaryService(ISportRepository sportRepository)
        {
            _sportRepository = sportRepository;
        }

        public IEnumerable<SportFavouriteSummaryDTO> GetAllFavouriteSummaries()
        {
            var allSports = _sportRepository.GetAllReadOnly().ToList();

            return allSports.Select(sport => new SportFavouriteSummaryDTO
            {
                Name = sport.Name,
                NumberOfFavourites = sport.FavouriteSports.Count()
            });
        }
    }
}
