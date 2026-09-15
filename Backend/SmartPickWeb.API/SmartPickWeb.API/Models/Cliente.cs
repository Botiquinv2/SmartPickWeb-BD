using System;
using System.Collections.Generic;

namespace SmartPickWeb.API.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NombreRazonSocial { get; set; } = null!;

    public string Rut { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
