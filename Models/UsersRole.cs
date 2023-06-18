using System;
using System.Collections.Generic;

namespace bad115_backend.Models;

public partial class UsersRole
{
    public int RolId { get; set; }

    public int UserId { get; set; }

    public virtual Role Rol { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
