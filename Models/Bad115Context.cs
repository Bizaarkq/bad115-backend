using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bad115_backend.Models;

public partial class Bad115Context : DbContext
{
    public Bad115Context()
    {
    }

    public Bad115Context(DbContextOptions<Bad115Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Almacena> Almacenas { get; set; }

    public virtual DbSet<Bodega> Bodegas { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Envio> Envios { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Pedidoproducto> Pedidoproductos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Seguimiento> Seguimientos { get; set; }

    public virtual DbSet<Subcategoria> Subcategorias { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersRole> UsersRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Almacena>(entity =>
        {
            entity.HasKey(e => new { e.IdProd, e.IdBodega }).IsClustered(false);

            entity.ToTable("ALMACENA");

            entity.HasIndex(e => e.IdBodega, "ALMACENA2_FK");

            entity.HasIndex(e => e.IdProd, "ALMACENA_FK");

            entity.Property(e => e.IdProd).HasColumnName("ID_PROD");
            entity.Property(e => e.IdBodega).HasColumnName("ID_BODEGA");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");

            entity.HasOne(d => d.IdBodegaNavigation).WithMany(p => p.Almacenas)
                .HasForeignKey(d => d.IdBodega)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ALMACENA_ALMACENA2_BODEGA");

            entity.HasOne(d => d.IdProdNavigation).WithMany(p => p.Almacenas)
                .HasForeignKey(d => d.IdProd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ALMACENA_ALMACENA_PRODUCTO");
        });

        modelBuilder.Entity<Bodega>(entity =>
        {
            entity.HasKey(e => e.IdBodega).IsClustered(false);

            entity.ToTable("BODEGA");

            entity.Property(e => e.IdBodega)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_BODEGA");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Latitude)
                .HasColumnType("decimal(15, 12)")
                .HasColumnName("LATITUDE");
            entity.Property(e => e.Longitud)
                .HasColumnType("decimal(15, 12)")
                .HasColumnName("LONGITUD");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCat).IsClustered(false);

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.IdCat)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_CAT");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCli).IsClustered(false);

            entity.ToTable("CLIENTE");

            entity.Property(e => e.IdCli)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_CLI");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_NACIMIENTO");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SEXO");
        });

        modelBuilder.Entity<Envio>(entity =>
        {
            entity.HasKey(e => e.IdEnv).IsClustered(false);

            entity.ToTable("ENVIO");

            entity.HasIndex(e => e.IdPed, "PROGRAMA_FK");

            entity.Property(e => e.IdEnv)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_ENV");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CODIGO");
            entity.Property(e => e.CostoEnvio)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("COSTO_ENVIO");
            entity.Property(e => e.DireccionDestino)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("DIRECCION_DESTINO");
            entity.Property(e => e.DireccionOrigen)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("DIRECCION_ORIGEN");
            entity.Property(e => e.EstadoActual)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ESTADO_ACTUAL");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.FechaEntregaEstimada)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_ENTREGA_ESTIMADA");
            entity.Property(e => e.IdPed).HasColumnName("ID_PED");
            entity.Property(e => e.MetodoEnvio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("METODO_ENVIO");
            entity.Property(e => e.Notas)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NOTAS");

            entity.HasOne(d => d.IdPedNavigation).WithMany(p => p.Envios)
                .HasForeignKey(d => d.IdPed)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ENVIO_PROGRAMA_PEDIDO");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFac).IsClustered(false);

            entity.ToTable("FACTURA");

            entity.HasIndex(e => e.IdPed, "EMITE_FK");

            entity.Property(e => e.IdFac)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_FAC");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CODIGO");
            entity.Property(e => e.Descuentos)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("DESCUENTOS");
            entity.Property(e => e.DireccionFacturacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("DIRECCION_FACTURACION");
            entity.Property(e => e.EstadoPago)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ESTADO_PAGO");
            entity.Property(e => e.FechaEmision)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_EMISION");
            entity.Property(e => e.IdPed).HasColumnName("ID_PED");
            entity.Property(e => e.Impuestos)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("IMPUESTOS");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("METODO_PAGO");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("SUBTOTAL");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TOTAL");

            entity.HasOne(d => d.IdPedNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdPed)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FACTURA_EMITE_PEDIDO");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPag).IsClustered(false);

            entity.ToTable("PAGOS");

            entity.HasIndex(e => e.IdFac, "TIENE_FK");

            entity.Property(e => e.IdPag)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_PAG");
            entity.Property(e => e.Colector)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COLECTOR");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.EstadoActual)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ESTADO_ACTUAL");
            entity.Property(e => e.FechaPago)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_PAGO");
            entity.Property(e => e.IdFac).HasColumnName("ID_FAC");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("MONTO");
            entity.Property(e => e.Notas)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NOTAS");
            entity.Property(e => e.NumReferencia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NUM_REFERENCIA");

            entity.HasOne(d => d.IdFacNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdFac)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PAGOS_TIENE_FACTURA");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPed).IsClustered(false);

            entity.ToTable("PEDIDO");

            entity.HasIndex(e => e.IdCli, "REALIZA_FK");

            entity.Property(e => e.IdPed)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_PED");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CODIGO");
            entity.Property(e => e.EstadoActual)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ESTADO_ACTUAL");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdCli).HasColumnName("ID_CLI");
            entity.Property(e => e.Notas)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NOTAS");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TOTAL");

            entity.HasOne(d => d.IdCliNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCli)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PEDIDO_REALIZA_CLIENTE");
        });

        modelBuilder.Entity<Pedidoproducto>(entity =>
        {
            entity.HasKey(e => new { e.IdProd, e.IdPed }).IsClustered(false);

            entity.ToTable("PEDIDOPRODUCTO");

            entity.HasIndex(e => e.IdProd, "PEDIDOPRODUCTO2_FK");

            entity.HasIndex(e => e.IdPed, "PEDIDOPRODUCTO3_FK");

            entity.HasIndex(e => e.IdEnv, "PEDIDOPRODUCTO4_FK");

            entity.HasIndex(e => e.IdBodega, "PEDIDOPRODUCTO_FK");

            entity.Property(e => e.IdProd).HasColumnName("ID_PROD");
            entity.Property(e => e.IdPed).HasColumnName("ID_PED");
            entity.Property(e => e.IdEnv).HasColumnName("ID_ENV").IsRequired(false);
            entity.Property(e => e.IdBodega).HasColumnName("ID_BODEGA").IsRequired(false);
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Descuento)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("DESCUENTO");
            entity.Property(e => e.Notas)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NOTAS");

            entity.HasOne(d => d.IdBodegaNavigation).WithMany(p => p.Pedidoproductos)
                .HasForeignKey(d => d.IdBodega)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PEDIDOPR_PEDIDOPRO_BODEGA");

            entity.HasOne(d => d.IdEnvNavigation).WithMany(p => p.Pedidoproductos)
                .HasForeignKey(d => d.IdEnv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PEDIDOPR_PEDIDOPRO_ENVIO");

            entity.HasOne(d => d.IdPedNavigation).WithMany(p => p.Pedidoproductos)
                .HasForeignKey(d => d.IdPed)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PEDIDOPR_PEDIDOPRO_PEDIDO");

            entity.HasOne(d => d.IdProdNavigation).WithMany(p => p.Pedidoproductos)
                .HasForeignKey(d => d.IdProd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PEDIDOPR_PEDIDOPRO_PRODUCTO");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProd).IsClustered(false);

            entity.ToTable("PRODUCTO");

            entity.Property(e => e.IdProd)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_PROD");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MARCA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRECIO");

            entity.HasMany(d => d.IdProvs).WithMany(p => p.IdProds)
                .UsingEntity<Dictionary<string, object>>(
                    "Provee",
                    r => r.HasOne<Proveedor>().WithMany()
                        .HasForeignKey("IdProv")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PROVEE_PROVEE2_PROVEEDO"),
                    l => l.HasOne<Producto>().WithMany()
                        .HasForeignKey("IdProd")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PROVEE_PROVEE_PRODUCTO"),
                    j =>
                    {
                        j.HasKey("IdProd", "IdProv").IsClustered(false);
                        j.ToTable("PROVEE");
                        j.HasIndex(new[] { "IdProv" }, "PROVEE2_FK");
                        j.HasIndex(new[] { "IdProd" }, "PROVEE_FK");
                        j.IndexerProperty<int>("IdProd").HasColumnName("ID_PROD");
                        j.IndexerProperty<int>("IdProv").HasColumnName("ID_PROV");
                    });
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProv).IsClustered(false);

            entity.ToTable("PROVEEDOR");

            entity.Property(e => e.IdProv)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_PROV");
            entity.Property(e => e.Contacto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONTACTO");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol)
                .HasName("PK_ROL")
                .IsClustered(false);

            entity.ToTable("ROLES");

            entity.Property(e => e.IdRol)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_ROL");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Seguimiento>(entity =>
        {
            entity.HasKey(e => e.IdSeg).IsClustered(false);

            entity.ToTable("SEGUIMIENTO");

            entity.HasIndex(e => e.IdEnv, "EJECUTA_FK");

            entity.Property(e => e.IdSeg)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_SEG");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.EstadoActual)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ESTADO_ACTUAL");
            entity.Property(e => e.EstadoPrevio)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ESTADO_PREVIO");
            entity.Property(e => e.FechaHoraUpdate)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("FECHA_HORA_UPDATE");
            entity.Property(e => e.IdEnv).HasColumnName("ID_ENV");
            entity.Property(e => e.NivelUrgencia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NIVEL_URGENCIA");
            entity.Property(e => e.Notas)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NOTAS");
            entity.Property(e => e.Responsable)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RESPONSABLE");
            entity.Property(e => e.UbicacionActual)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("UBICACION_ACTUAL");

            entity.HasOne(d => d.IdEnvNavigation).WithMany(p => p.Seguimientos)
                .HasForeignKey(d => d.IdEnv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SEGUIMIE_EJECUTA_ENVIO");
        });

        modelBuilder.Entity<Subcategoria>(entity =>
        {
            entity.HasKey(e => e.IdSub).IsClustered(false);

            entity.ToTable("SUBCATEGORIAS");

            entity.HasIndex(e => e.IdCat, "POSEE_FK");

            entity.Property(e => e.IdSub)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_SUB");
            entity.Property(e => e.IdCat).HasColumnName("ID_CAT");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IdCatNavigation).WithMany(p => p.Subcategoria)
                .HasForeignKey(d => d.IdCat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SUBCATEG_POSEE_CATEGORI");

            entity.HasMany(d => d.IdProds).WithMany(p => p.IdSubs)
                .UsingEntity<Dictionary<string, object>>(
                    "Categoriza",
                    r => r.HasOne<Producto>().WithMany()
                        .HasForeignKey("IdProd")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CATEGORI_CATEGORIZ_PRODUCTO"),
                    l => l.HasOne<Subcategoria>().WithMany()
                        .HasForeignKey("IdSub")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CATEGORI_CATEGORIZ_SUBCATEG"),
                    j =>
                    {
                        j.HasKey("IdSub", "IdProd").IsClustered(false);
                        j.ToTable("CATEGORIZA");
                        j.HasIndex(new[] { "IdProd" }, "CATEGORIZA2_FK");
                        j.HasIndex(new[] { "IdSub" }, "CATEGORIZA_FK");
                        j.IndexerProperty<int>("IdSub").HasColumnName("ID_SUB");
                        j.IndexerProperty<int>("IdProd").HasColumnName("ID_PROD");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser)
                .HasName("PK_USER")
                .IsClustered(false);

            entity.ToTable("USERS");

            entity.Property(e => e.IdUser)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_USER");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
        });

        modelBuilder.Entity<UsersRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("USERS_ROLES");

            entity.Property(e => e.RolId).HasColumnName("ROL_ID");
            entity.Property(e => e.UserId).HasColumnName("USER_ID");

            entity.HasOne(d => d.Rol).WithMany()
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROL");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USER");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
