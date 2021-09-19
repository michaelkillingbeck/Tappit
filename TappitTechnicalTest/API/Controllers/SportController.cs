using API.Interfaces.Services;
using API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SportController : Controller
    {
        private readonly ISportSummaryService _sportService;

        public SportController(ISportSummaryService sportService)
        {
            _sportService = sportService;
        }

        [HttpGet]
        [Route("GetAllFavouriteSummaries")]
        public IEnumerable<SportFavouriteSummaryDTO> GetSportFavouriteSummaries()
        {
            return _sportService.GetAllFavouriteSummaries();
        }
    }
}
