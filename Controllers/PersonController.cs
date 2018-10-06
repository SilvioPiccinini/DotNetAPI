using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetAPI.Model;
using DotNetAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            List<Person> people = this.personService.FindAll();
            if(people.Any())
                return Ok(people);
            else
                return NotFound("Don't Exist People in DataBase.");

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Person person = this.personService.FindById(id);
            if (person != null) return Ok(person);
            else return NotFound("Doesn't Exist person in DataBase.");
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(this.personService.Create(person));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(this.personService.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.personService.Delete(id);
            return NoContent();
        }
    }
}
