using System.ComponentModel.DataAnnotations;
using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using net.Models;
using net.Repositories;

namespace API.Controllers
{
    [ApiController]
    [Route("apiRest/Person")]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        [Route("mostrar")]
        public async Task<IActionResult> Get()
        {
            var person = await _personRepository.GetPersonsAsync();

            return Ok(person);
        }

        [HttpGet]
        [Route("mostrarPorId{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await _personRepository.GetPersonByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        [Route("InsertPerson")]
        public async Task<IActionResult> Post([FromBody] Person person)
        {
            await _personRepository.AddPersonAsync(person);

            return Created(nameof(Get),person);
        }



        [HttpPut("editPerson{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Person person)
        {
            var editPerson = await _personRepository.GetPersonByIdAsync(id);

            if (editPerson == null)
                return NotFound();

            person.Id = id;

            await _personRepository.EditPersonAsync(person);

            return Accepted();
        }


        [HttpDelete("deletePerson{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletePerson = await _personRepository.GetPersonByIdAsync(id);

            if (deletePerson == null)
                return NotFound();

            await _personRepository.DeletePersonAsync(id);

            return NoContent();
        }
    }
}
