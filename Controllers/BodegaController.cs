using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bad115_backend.Models;

namespace bad115_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BodegaController : ControllerBase
    {
        private readonly ILogger<BodegaController> _logger;
        private readonly Bad115Context _context;

        public BodegaController(ILogger<BodegaController> logger, Bad115Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetBodegas")]
        public async Task<ActionResult<IEnumerable<Bodega>>> GetBodegas()
        {
            return await _context.Bodegas.ToListAsync();
        }

    }
}