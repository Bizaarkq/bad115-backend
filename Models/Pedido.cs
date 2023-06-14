using System;
using System.Collections.Generic;

namespace bad115_backend.Models;

public partial class Pedido
{
    public int IdPed { get; set; }

    public int IdCli { get; set; }

    public string Codigo { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string EstadoActual { get; set; } = null!;

    public decimal? Total { get; set; }

    public string? Notas { get; set; }

    public virtual ICollection<Envio> Envios { get; set; } = new List<Envio>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Cliente IdCliNavigation { get; set; } = null!;

    public virtual ICollection<Pedidoproducto> Pedidoproductos { get; set; } = new List<Pedidoproducto>();
}
