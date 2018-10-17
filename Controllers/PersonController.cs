using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetAPI.Business;
using DotNetAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace DotNetAPI.Controllers
{
    [ApiVersion( "1.0" )]
    [Route( "api/v{version:apiVersion}/[controller]" )]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonBusiness personBusiness;

        public PersonController(IPersonBusiness personBusiness)
        {
            this.personBusiness = personBusiness;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            List<Person> people = this.personBusiness.FindAll();
            if(people.Any())
                return Ok(people);
            else
                return NotFound("Don't Exist People in DataBase.");

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Person person = this.personBusiness.FindById(id);
            if (person != null) return Ok(person);
            else return NotFound("Doesn't Exist person in DataBase.");
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(this.personBusiness.Create(person));
        }

        // PUT api/values
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(this.personBusiness.Update(person));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.personBusiness.Delete(id);
            return NoContent();
        }
    }
}
