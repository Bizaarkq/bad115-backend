using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bad115_backend.Models;

namespace bad115_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnvioController : ControllerBase
    {
        private readonly ILogger<EnvioController> _logger;
        private readonly Bad115Context _context;

        public EnvioController(ILogger<EnvioController> logger, Bad115Context context)
        {
            _logger = logger;
            _context = context;
        }

        
    }
}