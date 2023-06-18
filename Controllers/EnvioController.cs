using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bad115_backend.Models;
using System.Text.Json;

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

        [HttpGet]
        public IActionResult GetEnvios()
        {
            var envios = _context.Set<Envio>()
                .Select(e => new
                {
                    id_envio = e.IdEnv,
                    direccion_origen = e.DireccionOrigen,
                    direccion_destino = e.DireccionDestino,
                    estado_actual = e.EstadoActual,
                    fecha_entrega_estimada = e.FechaEntregaEstimada
                })
                .ToList();

            return Ok(envios);
        }

        [HttpPost]
        public async Task<IActionResult> CrearEnvio([FromBody] JsonElement request)
        {
            // Acceder a las propiedades del objeto JSON utilizando el método GetProperty
            int idPed = request.GetProperty("IdPed").GetInt32();
            string codigo = request.GetProperty("Codigo").GetString();
            DateTime fecha = request.GetProperty("Fecha").GetDateTime();
            string direccionOrigen = request.GetProperty("DireccionOrigen").GetString();
            string direccionDestino = request.GetProperty("DireccionDestino").GetString();
            string metodoEnvio = request.GetProperty("MetodoEnvio").GetString();
            string estadoActual = request.GetProperty("EstadoActual").GetString();
            DateTime fechaEntregaEstimada = request.GetProperty("FechaEntregaEstimada").GetDateTime();
            decimal costoEnvio = request.GetProperty("CostoEnvio").GetDecimal();
            string notas = request.GetProperty("Notas").GetString();

            // Crear el objeto Envio a partir de la información recibida
            var envio = new Envio
            {
                IdPed = idPed,
                Codigo = codigo,
                Fecha = fecha,
                DireccionOrigen = direccionOrigen,
                DireccionDestino = direccionDestino,
                MetodoEnvio = metodoEnvio,
                EstadoActual = estadoActual,
                FechaEntregaEstimada = fechaEntregaEstimada,
                CostoEnvio = costoEnvio,
                Notas = notas
            };

            // Guardar el envío en la base de datos
            _context.Envios.Add(envio);
            await _context.SaveChangesAsync();

            // Acceder a la lista de productos del objeto JSON
            var productos = request.GetProperty("Productos");
            foreach (var producto in productos.EnumerateArray())
            {
                int idProd = producto.GetProperty("IdProd").GetInt32();

                // Modificar el campo IdEnv en PedidoProducto
                var pedidoProducto = _context.Pedidoproductos.FirstOrDefault(pp =>
                    pp.IdPed == idPed && pp.IdProd == idProd);

                if (pedidoProducto != null)
                {
                    pedidoProducto.IdEnv = envio.IdEnv;
                    await _context.SaveChangesAsync();
                }
            }

            return Ok();
        }


    }
}