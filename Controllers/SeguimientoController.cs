using Microsoft.EntityFrameworkCore;
using bad115_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace bad115_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguimientoController : ControllerBase
    {
        private readonly ILogger<SeguimientoController> _logger;
        private readonly Bad115Context _context;

        public SeguimientoController(ILogger<SeguimientoController> logger, Bad115Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{id}", Name = "GetSeguimiento")]
        public async Task<ActionResult<Seguimiento>> GetSeguimiento(int id)
        {
            var Seguimiento = await _context.Seguimientos.FindAsync(id);
            if (Seguimiento == null)
            {
                return NotFound();
            }

            return Seguimiento;

        }

        [HttpPost]
        public async Task<ActionResult<Seguimiento>> Post(Seguimiento seguimiento)
        {
            _context.Seguimientos.Add(seguimiento);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("Getseguimiento", new { id = seguimiento.IdSeg }, seguimiento);
        }

    }
}