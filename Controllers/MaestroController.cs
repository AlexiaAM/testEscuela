using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using testI.BD;

namespace testI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaestroController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            var dbContext = new escuelatestContext();
            var teachers = from t in dbContext.Maestros
                           select new { t.IdMaestro, t.NombreMaestro, t.Clases };
            return Ok(teachers);
        }
    }
}
