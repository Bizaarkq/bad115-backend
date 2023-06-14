using System;
using System.Collections.Generic;

namespace bad115_backend.Models;

public partial class Proveedor
{
    public int IdProv { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Contacto { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<Producto> IdProds { get; set; } = new List<Producto>();
}
