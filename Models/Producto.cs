using System;
using System.Collections.Generic;

namespace bad115_backend.Models;

public partial class Producto
{
    public int IdProd { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public string? Marca { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Almacena> Almacenas { get; set; } = new List<Almacena>();

    public virtual ICollection<Pedidoproducto> Pedidoproductos { get; set; } = new List<Pedidoproducto>();

    public virtual ICollection<Proveedor> IdProvs { get; set; } = new List<Proveedor>();

    public virtual ICollection<Subcategoria> IdSubs { get; set; } = new List<Subcategoria>();
}
