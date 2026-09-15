using System;
using System.Collections.Generic;

namespace SmartPickWeb.API.Models;

public partial class DetallePedido
{
    public int IdPedido { get; set; }

    public string Sku { get; set; } = null!;

    public int Cantidad { get; set; }

    public int? EstadoRecoleccion { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Producto SkuNavigation { get; set; } = null!;
}
