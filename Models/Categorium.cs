using System;
using System.Collections.Generic;

namespace bad115_backend.Models;

public partial class Categorium
{
    public int IdCat { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Subcategoria> Subcategoria { get; set; } = new List<Subcategoria>();
}
