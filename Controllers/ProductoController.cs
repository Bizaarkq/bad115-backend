using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bad115_backend.Models;
using Newtonsoft.Json.Linq;

namespace WebApiProducto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly Bad115Context _context;

        public ProductoController(ILogger<ProductoController> logger, Bad115Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetProductos")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetProducto")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var Producto = await _context.Productos.FindAsync(id);
            if (Producto == null)
            {
                return NotFound();
            }

            return Producto;

        }
        [HttpPost]
        public async Task<ActionResult<Producto>> Post(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetProducto", new { id = producto.IdProd }, producto);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Producto>> Put(int id, Producto producto)
        {
            if (id != producto.IdProd)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Producto>> Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        [HttpGet("subcategorias/{id_prod}")]
        public IActionResult ObtenerSubcategoriasDeProducto(int id_prod)
        {
            var subcategorias = _context.Subcategorias
                .Where(sub => sub.IdProds.Any(prod => prod.IdProd == id_prod))
                .ToList();

            return Ok(subcategorias);
        }

        [HttpPost("{idProducto}/{idSubCategoria}")]
        public async Task<IActionResult> AddSubcategoriaToProducto(int idProducto, int idSubCategoria)
        {
            try
            {
                // Verificar si el producto existe
                var producto = await _context.Productos.FindAsync(idProducto);
                if (producto == null)
                {
                    return NotFound($"No se encontró el producto con ID {idProducto}");
                }

                // Verificar si la subcategoría existe
                var subcategoriaExistente = await _context.Subcategorias.FindAsync(idSubCategoria);
                if (subcategoriaExistente == null)
                {
                    return NotFound($"No se encontró la subcategoría con ID {idSubCategoria}");
                }

                var categoriza = _context.Set<Dictionary<string, object>>("Categoriza").FirstOrDefault(c => (int)c["IdProd"] == idProducto && (int)c["IdSub"] == idSubCategoria);
                if (categoriza != null)
                    return BadRequest($"La subcategoría con ID {idSubCategoria} ya existe en el producto con ID {idProducto}");
                // Añadir la subcategoría al producto
                producto.IdSubs.Add(subcategoriaExistente);
                await _context.SaveChangesAsync();

                return Ok($"Se añadió la subcategoría con ID {idSubCategoria} al producto con ID {idProducto}");
            }
            catch (Exception ex)
            {
                // Manejar cualquier error
                return StatusCode(500, $"Ocurrió un error al añadir la subcategoría al producto: {ex.Message}{ex.StackTrace}");
            }
        }
    }
}