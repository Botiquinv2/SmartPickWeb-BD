using System;
using System.Collections.Generic;

namespace SmartPickWeb.API.Models;

public partial class Ubicacione
{
    public int IdUbicacion { get; set; }

    public string Pasillo { get; set; } = null!;

    public string Estante { get; set; } = null!;

    public string Nivel { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
