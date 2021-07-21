using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreProject.API.DTOs;
using AspNetCoreProject.Core.Entities;
using AspNetCoreProject.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        /*
         * CRUD işlemleri için ek bir repository oluşturmaya gerek yok
         */
        private readonly IService<Person> _personService;
        private readonly IMapper _mapper;
        public PersonsController(IService<Person> personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _personService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            return Ok(person);
        }
        [HttpPost]
        public async Task<IActionResult> Save(PersonDto personDto)
        {
            var newPerson = await _personService.AddAsync(_mapper.Map<Person>(personDto));
            return Created(String.Empty, newPerson);
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var person = _personService.GetByIdAsync(id).Result;
            _personService.Remove(person);
            return NoContent();
        }
        [HttpPut]
        public IActionResult Update(PersonDto personDto)
        {
            _personService.Update(_mapper.Map<Person>(personDto));
            return NoContent();
        }
    }
}
