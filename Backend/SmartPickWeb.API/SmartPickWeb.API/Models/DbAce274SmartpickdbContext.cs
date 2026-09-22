using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SmartPickWeb.API.Models;

public partial class DbAce274SmartpickdbContext : DbContext
{
    public DbAce274SmartpickdbContext()
    {
    }

    public DbAce274SmartpickdbContext(DbContextOptions<DbAce274SmartpickdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Perfile> Perfiles { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Ubicacione> Ubicaciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__CATEGORI__CD54BC5A5C72C2E8");

            entity.ToTable("CATEGORIAS");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_categoria");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__CLIENTES__677F38F5E9106596");

            entity.ToTable("CLIENTES");

            entity.HasIndex(e => e.Rut, "UQ__CLIENTES__C2B74E768EB81B30").IsUnique();

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.NombreRazonSocial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_razon_social");
            entity.Property(e => e.Rut)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("rut");
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => new { e.IdPedido, e.Sku }).HasName("PK__DETALLE___122DE0371D231F1F");

            entity.ToTable("DETALLE_PEDIDO");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.Sku)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sku");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.EstadoRecoleccion)
                .HasDefaultValue(0)
                .HasColumnName("estado_recoleccion");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_P__id_pe__4F7CD00D");

            entity.HasOne(d => d.SkuNavigation).WithMany(p => p.DetallePedidos)
                .HasForeignKey(d => d.Sku)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_PED__sku__5070F446");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__PEDIDOS__6FF0148927C6A21F");

            entity.ToTable("PEDIDOS");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdUsuarioAdmin).HasColumnName("id_usuario_admin");
            entity.Property(e => e.IdUsuarioPicker).HasColumnName("id_usuario_picker");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PEDIDOS__id_clie__49C3F6B7");

            entity.HasOne(d => d.IdUsuarioAdminNavigation).WithMany(p => p.PedidoIdUsuarioAdminNavigations)
                .HasForeignKey(d => d.IdUsuarioAdmin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PEDIDOS__id_usua__4AB81AF0");

            entity.HasOne(d => d.IdUsuarioPickerNavigation).WithMany(p => p.PedidoIdUsuarioPickerNavigations)
                .HasForeignKey(d => d.IdUsuarioPicker)
                .HasConstraintName("FK__PEDIDOS__id_usua__4BAC3F29");
        });

        modelBuilder.Entity<Perfile>(entity =>
        {
            entity.HasKey(e => e.IdPerfil).HasName("PK__PERFILES__1D1C8768399D8411");

            entity.ToTable("PERFILES");

            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.NombrePerfil)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_perfil");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Sku).HasName("PK__PRODUCTO__DDDF4BE67E8A33B1");

            entity.ToTable("PRODUCTOS");

            entity.Property(e => e.Sku)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sku");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.IdUbicacion).HasColumnName("id_ubicacion");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_producto");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRODUCTOS__id_ca__44FF419A");

            entity.HasOne(d => d.IdUbicacionNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdUbicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PRODUCTOS__id_ub__45F365D3");
        });

        modelBuilder.Entity<Ubicacione>(entity =>
        {
            entity.HasKey(e => e.IdUbicacion).HasName("PK__UBICACIO__81BAA591D32F73BD");

            entity.ToTable("UBICACIONES");

            entity.Property(e => e.IdUbicacion).HasColumnName("id_ubicacion");
            entity.Property(e => e.Estante)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("estante");
            entity.Property(e => e.Nivel)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nivel");
            entity.Property(e => e.Pasillo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("pasillo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIOS__4E3E04ADB01A3A80");

            entity.ToTable("USUARIOS");

            entity.HasIndex(e => e.Rut, "UQ__USUARIOS__C2B74E76C06E31E3").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Rut)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("rut");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__USUARIOS__id_per__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
