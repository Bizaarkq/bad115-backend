using System;
using System.Collections.Generic;

namespace bad115_backend.Models;

public partial class Bodega
{
    public int IdBodega { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitud { get; set; }

    public virtual ICollection<Almacena> Almacenas { get; set; } = new List<Almacena>();

    public virtual ICollection<Pedidoproducto> Pedidoproductos { get; set; } = new List<Pedidoproducto>();
}
