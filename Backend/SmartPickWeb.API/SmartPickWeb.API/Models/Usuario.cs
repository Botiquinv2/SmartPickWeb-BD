using System;
using System.Collections.Generic;

namespace SmartPickWeb.API.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Rut { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IdPerfil { get; set; }

    public virtual Perfile IdPerfilNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> PedidoIdUsuarioAdminNavigations { get; set; } = new List<Pedido>();

    public virtual ICollection<Pedido> PedidoIdUsuarioPickerNavigations { get; set; } = new List<Pedido>();
}
