using System;
using System.Collections.Generic;

namespace bad115_backend.Models;

public partial class Seguimiento
{
    public int IdSeg { get; set; }

    public int IdEnv { get; set; }

    public string EstadoActual { get; set; } = null!;

    public DateTime FechaHoraUpdate { get; set; }

    public string UbicacionActual { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Notas { get; set; }

    public string Responsable { get; set; } = null!;

    public string? NivelUrgencia { get; set; }

    public string? EstadoPrevio { get; set; }

    public virtual Envio? IdEnvNavigation { get; set; } = null!;
}
