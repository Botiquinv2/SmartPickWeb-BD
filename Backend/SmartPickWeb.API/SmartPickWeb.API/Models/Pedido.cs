using System;
using System.Collections.Generic;

namespace SmartPickWeb.API.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int Estado { get; set; }

    public int IdCliente { get; set; }

    public int IdUsuarioAdmin { get; set; }

    public int? IdUsuarioPicker { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Usuario? IdUsuarioAdminNavigation { get; set; }

    public virtual Usuario? IdUsuarioPickerNavigation { get; set; }
}