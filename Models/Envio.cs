using System;
using System.Collections.Generic;

namespace bad115_backend.Models;

public partial class Envio
{
    public int IdEnv { get; set; }

    public int IdPed { get; set; }

    public string Codigo { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string DireccionOrigen { get; set; } = null!;

    public string DireccionDestino { get; set; } = null!;

    public string MetodoEnvio { get; set; } = null!;

    public string EstadoActual { get; set; } = null!;

    public DateTime? FechaEntregaEstimada { get; set; }

    public decimal CostoEnvio { get; set; }

    public string? Notas { get; set; }

    public virtual Pedido IdPedNavigation { get; set; } = null!;

    public virtual ICollection<Pedidoproducto> Pedidoproductos { get; set; } = new List<Pedidoproducto>();

    public virtual ICollection<Seguimiento> Seguimientos { get; set; } = new List<Seguimiento>();
}
