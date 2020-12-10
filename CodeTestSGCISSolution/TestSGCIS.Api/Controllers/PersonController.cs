using AutoMapper;
using CodeTestSGCIS.Api.Responses;
using CodeTestSGCIS.Core.DTOs;
using CodeTestSGCIS.Core.Entities;
using CodeTestSGCIS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CodeTestSGCIS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;


        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieve all created persons
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<PersonDto>))]
        public IActionResult GetPersons()
        {
            var persons = _personService.GetPersons();
            var personsDto = _mapper.Map<IEnumerable<PersonDto>>(persons);

            return Ok(personsDto);
        }
        /// <summary>
        /// Retrieve the person with the Id specified
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PersonDto))]
        public async Task<IActionResult> GetPerson(int id)
        {
            var person = await _personService.GetPerson(id);
            var personDto = _mapper.Map<PersonDto>(person);

            return Ok(personDto);
        }
        /// <summary>
        /// Create a new person
        /// </summary>
        /// <param name="personDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PersonDto))]
        public async Task<IActionResult> Post(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);

            await _personService.InsertPerson(person);

            personDto = _mapper.Map<PersonDto>(person);
            return Ok(personDto);
        }
        /// <summary>
        ///  Update all person fields except Person ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personDto"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        public async Task<IActionResult> Put(int id, PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            person.Id = id;

            var result = await _personService.UpdatePerson(person);
            return Ok(result);
        }
        /// <summary>
        /// Delete the person with the Id specified
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _personService.DeletePerson(id);
            return Ok(result);
        }
    }
}
