using System;
using System.Collections.Generic;

namespace bad115_backend.Models;

public partial class Almacena
{
    public int IdProd { get; set; }

    public int IdBodega { get; set; }

    public int Cantidad { get; set; }

    public virtual Bodega IdBodegaNavigation { get; set; } = null!;

    public virtual Producto IdProdNavigation { get; set; } = null!;
}
