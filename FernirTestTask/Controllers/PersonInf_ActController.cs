using FernirTestTask.DataModels;
using FernirTestTask.RepositoryPattern.Interfaces;
using FernirTestTask.RepositoryPattern.Realizations;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FernirTestTask.Controllers
{
    [ApiController]
    [Route("api")]
    public class PersonInf_ActController : ControllerBase
    {
        IRepository<Person> db;

        public PersonInf_ActController()
        {
            db = new SQLPersonRepository();
        }

        [HttpGet("person")]
        public IEnumerable<Person> GetAllPersons()
        {
            return db.GetAllPersons();
        }

        [HttpPost("person")]
        public async Task<IActionResult> AddPerson(Person newPerson) 
        {
            if (ModelState.IsValid)
            {
                db.AddPerson(newPerson);
                db.Save();
                return StatusCode(200);
            }
            else
            {
                return StatusCode(409);
            }
        }

        [HttpPut("person")]
        public async Task<IActionResult> UpdatePersonInfAsync([FromQuery] Guid personId, [FromQuery] string? newFirstName, [FromQuery] string? newLastName)
        {
            if (!CheckPerson(personId))
            {
                return StatusCode(409);
            }

            Person updatePerson = db.GetAllPersons().FirstOrDefault(p => personId == p.Id);
            if(String.IsNullOrEmpty(newFirstName))
            {
                updatePerson.LastName = newLastName;
            }
            else if (String.IsNullOrEmpty(newLastName))
            {
                updatePerson.FirstName = newFirstName;
            }
            else
            {
                updatePerson.FirstName = newFirstName;
                updatePerson.LastName = newLastName;
            }

            db.UpdatePersonInf(updatePerson);
            db.Save();

            return StatusCode(200); ;
        }

        [HttpDelete("person")]
        public async Task<IActionResult> DeletePerson([FromQuery] Guid personId)
        {
            if (!CheckPerson(personId))
            {
                return StatusCode(409);
            }

            db.DeletePerson(personId);
            db.Save();

            return StatusCode(200); ;
        }

        private bool CheckPerson(Guid personId) 
        {
            return db.GetAllPersons().Any(p => p.Id == personId);
        }
    }
}
