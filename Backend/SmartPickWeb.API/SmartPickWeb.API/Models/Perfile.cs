using System;
using System.Collections.Generic;

namespace SmartPickWeb.API.Models;

public partial class Perfile
{
    public int IdPerfil { get; set; }

    public string NombrePerfil { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
