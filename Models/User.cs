﻿using System;
using System.Collections.Generic;

namespace bad115_backend.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string? Name { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
