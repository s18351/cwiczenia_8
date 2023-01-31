using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly HealthDbContext _context;

        public DoctorsController(HealthDbContext context)
        {
            _context= context;
        }

        // GET api/<DoctorsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var doctor = _context.Doctors.SingleOrDefault(x=>x.IdDoctor == id);

            return doctor != null ? Ok(doctor) : BadRequest("No doctor with given id");
        }

        // POST api/<DoctorsController>
        [HttpPost]
        public IActionResult Post([FromBody] Doctor value)
        {
            _context.Doctors.Add(value);
            _context.SaveChanges();
            return Ok(value.IdDoctor);
        }

        // PUT api/<DoctorsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Doctor doctor)
        {
            Doctor toUpdate = _context.Doctors.SingleOrDefault(x => x.IdDoctor == id);

            if(toUpdate == null)
            {
                return NotFound();
            }

            toUpdate.FirstName = doctor.FirstName;
            toUpdate.LastName = doctor.LastName;
            toUpdate.Email = doctor.Email;

            _context.SaveChanges();
            return Ok();
        }

        // DELETE api/<DoctorsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var doctor = _context.Doctors.SingleOrDefault(x => x.IdDoctor == id);
            if (doctor == null)
            {
                return NotFound();
            }
            _context.Remove(doctor);
            return Ok();
        }
    }
}
