using EfCoreExamples2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreExamples2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var context = new pgagoContext();

            var statuses = await context.Statuses.ToListAsync();
            //select * from status inner join;


            //N+1 problem
            foreach (var s in statuses)
            {
                if (s.Students.Where(st => st.LastName == "Kowalski").Count() > 0)
                {
                    //...
                }
            }

            return Ok();
        }

    }
}
