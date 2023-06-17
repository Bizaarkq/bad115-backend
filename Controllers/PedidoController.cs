using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bad115_backend.Models;

namespace bad115_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly Bad115Context _context;

        public PedidoController(ILogger<PedidoController> logger, Bad115Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetPedidos")]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        [HttpGet("productos-pedido/{IdPed}")]
        public IActionResult ObtenerProductosDePedido(int IdPed)
        {
            var pedidoProductos = _context.Pedidoproductos
        .Where(p => p.IdPed == IdPed)
        .ToList();

            if (pedidoProductos.Count == 0)
            {
                return NotFound();
            }

            return Ok(pedidoProductos);
        }
    }
}