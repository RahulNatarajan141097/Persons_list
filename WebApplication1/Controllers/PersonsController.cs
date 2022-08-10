using log4net;
using Microsoft.AspNetCore.Mvc;
using Persons_list.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Persons_list.Controllers
{
    [Route("api/Persons")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        DataContext DB = new DataContext();

        [HttpGet]
        [Route("GetPersons")]
        public IEnumerable<Persons> Get()
        { 
            return DB.Persons.ToList(); 
        }

        [HttpGet]
        [Route("Delete")]
        public string Delete(int id)
        {
            Persons persons = DB.Persons.Where(x => x.id == id).FirstOrDefault();
            DB.Persons.Remove(persons);
            DB.SaveChanges();

            return "Deleted"; 
        }

        [HttpPost]  
        [Route("Add")] 
        public async Task<ActionResult> Post([FromBody]Persons persons) 
        {
            DB.Persons.Add(persons); 
            DB.SaveChanges();
            return Ok("Person Added sucesfully");
        }

        [HttpPost]
        [Route("Edits")]
        public string Edits(Persons persons)
        {
            var persons_ = DB.Persons.Find(persons.id); 
            persons_.lastname = persons.lastname;
            persons_.firstname = persons.firstname;
            persons_.address = persons.address;
            persons_.country = persons.country;

            DB.Entry(persons_).State = System.Data.Entity.EntityState.Modified; 
            DB.SaveChanges();

            return "Product Updated";
        }

        [HttpGet]
        [Route("Edit")]
        public Persons Edit(int id) 
        {
            return DB.Persons.Where(x => x.id == id).FirstOrDefault(); 
        }

        [HttpGet]
        [Route("GetPersonsById")]
        public IEnumerable<Persons> GetPersonsById(int id)
        {
            return DB.Persons.Where(x => x.id == id);
        }
    }
}
