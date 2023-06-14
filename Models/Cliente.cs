using System;
using System.Collections.Generic;

namespace bad115_backend.Models;

public partial class Cliente
{
    public int IdCli { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? Direccion { get; set; }

    public string Correo { get; set; } = null!;

    public DateTime? FechaNacimiento { get; set; }

    public string? Sexo { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
