using Microsoft.AspNetCore.Mvc;
using HealthCatalyst.API.Models;
using System.Collections.Generic;
using AutoMapper;
using HealthCatalyst.API.DTOs;
using HealthCatalyst.API.Repositories;
using System.Linq;

namespace HealthCatalyst.API.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _repository;
        private readonly IMapper _mapper;

        public PeopleController(IPeopleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// The GetPeople method handles GET requests made at the default route.
        /// </summary>
        /// <returns>
        /// An action result with an HTTP status code of 200 and the people in the database, or a 404 when the request was unsuccessful.
        /// </returns>
        [HttpGet]
        public IActionResult GetPeople()
        {
            var peopleItems = _repository.GetPeople();

            if (peopleItems != null)
            {
                return Ok(peopleItems);
            }

            return NotFound();
        }

        /// <summary>
        /// The GetPersonById method handles GET requests made to the route: api/people/{id}.
        /// </summary>
        /// <param name="id">
        /// Id is the primary key of the People table.
        /// </param>
        /// <returns>
        /// An action result with an HTTTP status code of 200 and a matching PersonReadDTO, and a 404 when returned DTO is null.
        /// </returns>
        [HttpGet("{id:int}", Name = "GetPersonById")]
        public IActionResult GetPersonById(int id)
        {
            var personItem = _repository.GetPersonById(id);

            if (personItem != null)
            {
                return Ok(_mapper.Map<PersonReadDTO>(personItem));
            }

            return NotFound();
        }

        /// <summary>
        /// The GetPersonByName method handles GET requests made to the route: api/people/{name}.
        /// </summary>
        /// <param name="name">
        /// Name is used to query against the first and last name columns of the People table.
        /// </param>
        /// <returns>
        /// An action result with a status code of 200 and a collection of PersonReadDTO, or a 404 when the resturned collection is null.
        /// </returns>
        [HttpGet("{name}")]
        public IActionResult GetPersonByName(string name)
        {
            var personItem = _repository.GetPeopleByFirstOrLastName(name);

            if (personItem.Any())
            {
                return Ok(_mapper.Map<ICollection<PersonReadDTO>>(personItem));
            }

            return NotFound();
        }

        /// <summary>
        /// The CreatePerson method handles POST requests made to the route: api/people.
        /// </summary>
        /// <param name="personCreateDto">
        /// The PersonCreateDTO for the person to be created.
        /// </param>
        /// <returns>
        /// An action result with a status code of 201, the route that was used to send the POST request, and the PersonReadDTO for the person that was created, or a 404 status code and the route that was used to send the POST request.
        /// </returns>
        [HttpPost]
        public IActionResult CreatePerson([FromBody] PersonCreateDTO personCreateDto)
        {
            var personModel = _mapper.Map<Person>(personCreateDto);
            _repository.CreatePerson(personModel);
            _repository.SaveChanges();

            var personReadDto = _mapper.Map<PersonReadDTO>(personModel);

            return CreatedAtRoute(nameof(GetPersonById), new { personReadDto.Id }, personReadDto);
        }
    }
}