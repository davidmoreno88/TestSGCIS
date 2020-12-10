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
    public class PersonTypeController : ControllerBase
    {
        private readonly IPersonTypeService _personTypeService;
        private readonly IMapper _mapper;


        public PersonTypeController(IPersonTypeService personTypeService, IMapper mapper)
        {
            _personTypeService = personTypeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Return all available person types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<PersonTypeDto>>))]
        public IActionResult GetPersonTypes()
        {
            var typePersons = _personTypeService.GetPersonTypes();
            var typePersonsDto = _mapper.Map<IEnumerable<PersonTypeDto>>(typePersons);

            return Ok(typePersonsDto);
        }
    }
}
