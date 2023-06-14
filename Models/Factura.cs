using System;
using System.Collections.Generic;

namespace bad115_backend.Models;

public partial class Factura
{
    public int IdFac { get; set; }

    public int IdPed { get; set; }

    public string Codigo { get; set; } = null!;

    public DateTime FechaEmision { get; set; }

    public string? DireccionFacturacion { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Impuestos { get; set; }

    public decimal Descuentos { get; set; }

    public decimal Total { get; set; }

    public string MetodoPago { get; set; } = null!;

    public string? EstadoPago { get; set; }

    public virtual Pedido IdPedNavigation { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
