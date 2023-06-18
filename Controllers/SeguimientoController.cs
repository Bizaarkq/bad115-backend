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


    }
}