using System;
using System.Collections.Generic;

namespace bad115_backend.Models;

public partial class Pedidoproducto
{
    public int IdProd { get; set; }

    public int IdPed { get; set; }

    public int IdEnv { get; set; }

    public int IdBodega { get; set; }

    public decimal? Descuento { get; set; }

    public string? Notas { get; set; }

    public int Cantidad { get; set; }

    public virtual Bodega IdBodegaNavigation { get; set; } = null!;

    public virtual Envio IdEnvNavigation { get; set; } = null!;

    public virtual Pedido IdPedNavigation { get; set; } = null!;

    public virtual Producto IdProdNavigation { get; set; } = null!;
}
