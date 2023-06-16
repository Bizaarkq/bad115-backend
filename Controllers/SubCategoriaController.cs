using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bad115_backend.Models;

namespace bad115_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubCategoriaController : ControllerBase
    {
        private readonly ILogger<SubCategoriaController> _logger;
        private readonly Bad115Context _context;

        public SubCategoriaController(ILogger<SubCategoriaController> logger, Bad115Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetSubCategorias")]
        public async Task<ActionResult<IEnumerable<Subcategoria>>> GetSubCategorias()
        {
            return await _context.Subcategorias.ToListAsync();
        }

        [HttpGet("productos/{idSub}")]
        public IActionResult GetProductosPorCategoria(int idSub)
        {
            var productos = _context.Productos
                .Where(p => p.IdSubs.Any(s => s.IdSub == idSub))
                .ToList();

            return Ok(productos);
        }
    }
}