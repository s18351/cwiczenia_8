using EfCoreExamples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreExamples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var db = new MainDbContext();

            var students = await db.Students.ToListAsync();

            foreach (var s in students)
            {
                if (s.Status.Name == "Active")
                {
                    //...
                }
            }

            return Ok();
        }

    }
}
