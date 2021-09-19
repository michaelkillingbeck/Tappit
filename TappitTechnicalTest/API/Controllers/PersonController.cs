using API.Interfaces.Services;
using API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<PersonSummaryDTO> GetAll()
        {
            return _personService.GetAllPeople();
        }

        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDetailDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        { 
            var foundEntity = _personService.GetById(id);

            if (foundEntity == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundEntity);
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdatePerson(PersonDetailDTO personDetailDTO)
        {
            _personService.Update(personDetailDTO);

            return Ok();
        }
    }
}
