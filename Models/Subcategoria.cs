using System;
using System.Collections.Generic;

namespace bad115_backend.Models;

public partial class Subcategoria
{
    public int IdSub { get; set; }

    public int IdCat { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual Categorium IdCatNavigation { get; set; } = null!;

    public virtual ICollection<Producto> IdProds { get; set; } = new List<Producto>();
}
