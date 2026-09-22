using System;
using System.Collections.Generic;

namespace SmartPickWeb.API.Models;

public partial class Producto
{
    public string Sku { get; set; } = null!;

    public string NombreProducto { get; set; } = null!;

    public int Stock { get; set; }

    public int IdCategoria { get; set; }

    public int IdUbicacion { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual Ubicacione IdUbicacionNavigation { get; set; } = null!;
}
