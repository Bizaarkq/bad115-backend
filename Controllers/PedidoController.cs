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
        public async Task<ActionResult> GetPedidos()
        {
            var pedidos = await _context.Pedidos.Include(p => p.IdCliNavigation).ToListAsync();

            var resultado = pedidos.Select(pp => new
            {
                cliente = new
                {
                    IdCli = pp.IdCliNavigation.IdCli,
                    Nombres = pp.IdCliNavigation.Nombres,
                    Apellidos = pp.IdCliNavigation.Apellidos,
                    Direccion = pp.IdCliNavigation.Direccion,
                    Correo = pp.IdCliNavigation.Correo,
                    FechaNacimiento = pp.IdCliNavigation.FechaNacimiento,
                    Sexo = pp.IdCliNavigation.Sexo,
                },
                IdPed = pp.IdPed,
                IdCli = pp.IdCli,
                Codigo = pp.Codigo,
                Fecha = pp.Fecha,
                EstadoActual = pp.EstadoActual,
                Total = pp.Total,
                Notas = pp.Notas,
            });

            return Ok(resultado);
        }

        [HttpGet("productos-pedido/{IdPed}")]
        public async Task<ActionResult> GetPedidoProductos(int IdPed)
        {
            var pedidoProductos = await _context.Set<Pedidoproducto>()
                .Include(pp => pp.IdProdNavigation)  // Incluir la relación con Producto
                .Where(pp => pp.IdPed == IdPed)
                .ToListAsync();

            var resultado = pedidoProductos.Select(pp => new
            {
                producto = new
                {
                    id_pro = pp.IdProdNavigation.IdProd,
                    nombre = pp.IdProdNavigation.Nombre,
                    precio = pp.IdProdNavigation.Precio
                },
                cantidad = pp.Cantidad
            });

            return Ok(resultado);
        }
    }
}