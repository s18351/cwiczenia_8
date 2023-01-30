using EfCoreExamples3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreExamples3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var context = new pgagoContext();

            var result = await context.Clients
                                    .Include(c => c.ClientTrips)
                                    .ThenInclude(ct => ct.IdTripNavigation)
                                    .ToListAsync();

            return Ok(result);
        }

    }
}
