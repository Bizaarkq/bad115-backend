using System;
using System.Collections.Generic;

namespace bad115_backend.Models;

public partial class Pago
{
    public int IdPag { get; set; }

    public int IdFac { get; set; }

    public DateTime FechaPago { get; set; }

    public decimal Monto { get; set; }

    public string? Descripcion { get; set; }

    public string EstadoActual { get; set; } = null!;

    public string NumReferencia { get; set; } = null!;

    public string? Notas { get; set; }

    public string Colector { get; set; } = null!;

    public virtual Factura IdFacNavigation { get; set; } = null!;
}
