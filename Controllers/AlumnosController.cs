using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using testI.BD;


namespace testI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        [HttpGet]
        public IActionResult getAllAlumns()
        {
            var dbContext = new escuelatestContext();
            var alumns = from a in dbContext.Alumnos
                         select new { a.IdAlumno, a.NombreAlumno };

            return Ok(alumns);
        }
    }
}
