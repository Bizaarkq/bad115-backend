﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bad115_backend.Models;

#nullable disable

namespace bad115_backend.Migrations
{
    [DbContext(typeof(Bad115Context))]
    [Migration("20230616061224_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Categoriza", b =>
                {
                    b.Property<int>("IdSub")
                        .HasColumnType("int")
                        .HasColumnName("ID_SUB");

                    b.Property<int>("IdProd")
                        .HasColumnType("int")
                        .HasColumnName("ID_PROD");

                    b.HasKey("IdSub", "IdProd");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdSub", "IdProd"), false);

                    b.HasIndex(new[] { "IdProd" }, "CATEGORIZA2_FK");

                    b.HasIndex(new[] { "IdSub" }, "CATEGORIZA_FK");

                    b.ToTable("CATEGORIZA", (string)null);
                });

            modelBuilder.Entity("Provee", b =>
                {
                    b.Property<int>("IdProd")
                        .HasColumnType("int")
                        .HasColumnName("ID_PROD");

                    b.Property<int>("IdProv")
                        .HasColumnType("int")
                        .HasColumnName("ID_PROV");

                    b.HasKey("IdProd", "IdProv");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdProd", "IdProv"), false);

                    b.HasIndex(new[] { "IdProv" }, "PROVEE2_FK");

                    b.HasIndex(new[] { "IdProd" }, "PROVEE_FK");

                    b.ToTable("PROVEE", (string)null);
                });

            modelBuilder.Entity("bad115_backend.Models.Almacena", b =>
                {
                    b.Property<int>("IdProd")
                        .HasColumnType("int")
                        .HasColumnName("ID_PROD");

                    b.Property<int>("IdBodega")
                        .HasColumnType("int")
                        .HasColumnName("ID_BODEGA");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("CANTIDAD");

                    b.HasKey("IdProd", "IdBodega");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdProd", "IdBodega"), false);

                    b.HasIndex(new[] { "IdBodega" }, "ALMACENA2_FK");

                    b.HasIndex(new[] { "IdProd" }, "ALMACENA_FK");

                    b.ToTable("ALMACENA", (string)null);
                });

            modelBuilder.Entity("bad115_backend.Models.Bodega", b =>
                {
                    b.Property<int>("IdBodega")
                        .HasColumnType("int")
                        .HasColumnName("ID_BODEGA");

                    b.Property<string>("Direccion")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("DIRECCION");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(15, 12)")
                        .HasColumnName("LATITUDE");

                    b.Property<decimal>("Longitud")
                        .HasColumnType("decimal(15, 12)")
                        .HasColumnName("LONGITUD");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NOMBRE");

                    b.HasKey("IdBodega");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdBodega"), false);

                    b.ToTable("BODEGA", (string)null);
                });

            modelBuilder.Entity("bad115_backend.Models.Categorium", b =>
                {
                    b.Property<int>("IdCat")
                        .HasColumnType("int")
                        .HasColumnName("ID_CAT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NOMBRE");

                    b.HasKey("IdCat");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdCat"), false);

                    b.ToTable("CATEGORIA", (string)null);
                });

            modelBuilder.Entity("bad115_backend.Models.Cliente", b =>
                {
                    b.Property<int>("IdCli")
                        .HasColumnType("int")
                        .HasColumnName("ID_CLI");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("APELLIDOS");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("CORREO");

                    b.Property<string>("Direccion")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("DIRECCION");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime")
                        .HasColumnName("FECHA_NACIMIENTO");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NOMBRES");

                    b.Property<string>("Sexo")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("SEXO");

                    b.HasKey("IdCli");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdCli"), false);

                    b.ToTable("CLIENTE", (string)null);
                });

            modelBuilder.Entity("bad115_backend.Models.Envio", b =>
                {
                    b.Property<int>("IdEnv")
                        .HasColumnType("int")
                        .HasColumnName("ID_ENV");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("CODIGO");

                    b.Property<decimal>("CostoEnvio")
                        .HasColumnType("decimal(6, 2)")
                        .HasColumnName("COSTO_ENVIO");

                    b.Property<string>("DireccionDestino")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("DIRECCION_DESTINO");

                    b.Property<string>("DireccionOrigen")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("DIRECCION_ORIGEN");

                    b.Property<string>("EstadoActual")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("ESTADO_ACTUAL");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime")
                        .HasColumnName("FECHA");

                    b.Property<DateTime?>("FechaEntregaEstimada")
                        .HasColumnType("datetime")
                        .HasColumnName("FECHA_ENTREGA_ESTIMADA");

                    b.Property<int>("IdPed")
                        .HasColumnType("int")
                        .HasColumnName("ID_PED");

                    b.Property<string>("MetodoEnvio")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("METODO_ENVIO");

                    b.Property<string>("Notas")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("NOTAS");

                    b.HasKey("IdEnv");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdEnv"), false);

                    b.HasIndex(new[] { "IdPed" }, "PROGRAMA_FK");

                    b.ToTable("ENVIO", (string)null);
                });

            modelBuilder.Entity("bad115_backend.Models.Factura", b =>
                {
                    b.Property<int>("IdFac")
                        .HasColumnType("int")
                        .HasColumnName("ID_FAC");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("CODIGO");

                    b.Property<decimal>("Descuentos")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("DESCUENTOS");

                    b.Property<string>("DireccionFacturacion")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("DIRECCION_FACTURACION");

                    b.Property<string>("EstadoPago")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("ESTADO_PAGO");

                    b.Property<DateTime>("FechaEmision")
                        .HasColumnType("datetime")
                        .HasColumnName("FECHA_EMISION");

                    b.Property<int>("IdPed")
                        .HasColumnType("int")
                        .HasColumnName("ID_PED");

                    b.Property<decimal>("Impuestos")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("IMPUESTOS");

                    b.Property<string>("MetodoPago")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("METODO_PAGO");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("SUBTOTAL");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("TOTAL");

                    b.HasKey("IdFac");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdFac"), false);

                    b.HasIndex(new[] { "IdPed" }, "EMITE_FK");

                    b.ToTable("FACTURA", (string)null);
                });

            modelBuilder.Entity("bad115_backend.Models.Pago", b =>
                {
                    b.Property<int>("IdPag")
                        .HasColumnType("int")
                        .HasColumnName("ID_PAG");

                    b.Property<string>("Colector")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("COLECTOR");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("DESCRIPCION");

                    b.Property<string>("EstadoActual")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("ESTADO_ACTUAL");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime")
                        .HasColumnName("FECHA_PAGO");

                    b.Property<int>("IdFac")
                        .HasColumnType("int")
                        .HasColumnName("ID_FAC");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("MONTO");

                    b.Property<string>("Notas")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("NOTAS");

                    b.Property<string>("NumReferencia")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("NUM_REFERENCIA");

                    b.HasKey("IdPag");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdPag"), false);

                    b.HasIndex(new[] { "IdFac" }, "TIENE_FK");

                    b.ToTable("PAGOS", (string)null);
                });

            modelBuilder.Entity("bad115_backend.Models.Pedido", b =>
                {
                    b.Property<int>("IdPed")
                        .HasColumnType("int")
                        .HasColumnName("ID_PED");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("CODIGO");

                    b.Property<string>("EstadoActual")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("ESTADO_ACTUAL");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime")
                        .HasColumnName("FECHA");

                    b.Property<int>("IdCli")
                        .HasColumnType("int")
                        .HasColumnName("ID_CLI");

                    b.Property<string>("Notas")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("NOTAS");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("TOTAL");

                    b.HasKey("IdPed");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdPed"), false);

                    b.HasIndex(new[] { "IdCli" }, "REALIZA_FK");

                    b.ToTable("PEDIDO", (string)null);
                });

            modelBuilder.Entity("bad115_backend.Models.Pedidoproducto", b =>
                {
                    b.Property<int>("IdProd")
                        .HasColumnType("int")
                        .HasColumnName("ID_PROD");

                    b.Property<int>("IdPed")
                        .HasColumnType("int")
                        .HasColumnName("ID_PED");

                    b.Property<int>("IdEnv")
                        .HasColumnType("int")
                        .HasColumnName("ID_ENV");

                    b.Property<int>("IdBodega")
                        .HasColumnType("int")
                        .HasColumnName("ID_BODEGA");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("CANTIDAD");

                    b.Property<decimal?>("Descuento")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("DESCUENTO");

                    b.Property<string>("Notas")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("NOTAS");

                    b.HasKey("IdProd", "IdPed", "IdEnv", "IdBodega");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdProd", "IdPed", "IdEnv", "IdBodega"), false);

                    b.HasIndex(new[] { "IdProd" }, "PEDIDOPRODUCTO2_FK");

                    b.HasIndex(new[] { "IdPed" }, "PEDIDOPRODUCTO3_FK");

                    b.HasIndex(new[] { "IdEnv" }, "PEDIDOPRODUCTO4_FK");

                    b.HasIndex(new[] { "IdBodega" }, "PEDIDOPRODUCTO_FK");

                    b.ToTable("PEDIDOPRODUCTO", (string)null);
                });

            modelBuilder.Entity("bad115_backend.Models.Producto", b =>
                {
                    b.Property<int>("IdProd")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_PROD");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProd"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("DESCRIPCION");

                    b.Property<string>("Marca")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("MARCA");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NOMBRE");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("PRECIO");

                    b.HasKey("IdProd");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdProd"), false);

                    b.ToTable("PRODUCTO", (string)null);
                });

            modelBuilder.Entity("bad115_backend.Models.Proveedor", b =>
                {
                    b.Property<int>("IdProv")
                        .HasColumnType("int")
                        .HasColumnName("ID_PROV");

                    b.Property<string>("Contacto")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("CONTACTO");

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("CORREO");

                    b.Property<string>("Direccion")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("DIRECCION");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NOMBRE");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("TELEFONO");

                    b.HasKey("IdProv");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdProv"), false);

                    b.ToTable("PROVEEDOR", (string)null);
                });

            modelBuilder.Entity("bad115_backend.Models.Seguimiento", b =>
                {
                    b.Property<int>("IdSeg")
                        .HasColumnType("int")
                        .HasColumnName("ID_SEG");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("DESCRIPCION");

                    b.Property<string>("EstadoActual")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("ESTADO_ACTUAL");

                    b.Property<string>("EstadoPrevio")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("ESTADO_PREVIO");

                    b.Property<byte[]>("FechaHoraUpdate")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion")
                        .HasColumnName("FECHA_HORA_UPDATE");

                    b.Property<int>("IdEnv")
                        .HasColumnType("int")
                        .HasColumnName("ID_ENV");

                    b.Property<string>("NivelUrgencia")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("NIVEL_URGENCIA");

                    b.Property<string>("Notas")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("NOTAS");

                    b.Property<string>("Responsable")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("RESPONSABLE");

                    b.Property<string>("UbicacionActual")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("UBICACION_ACTUAL");

                    b.HasKey("IdSeg");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdSeg"), false);

                    b.HasIndex(new[] { "IdEnv" }, "EJECUTA_FK");

                    b.ToTable("SEGUIMIENTO", (string)null);
                });

            modelBuilder.Entity("bad115_backend.Models.Subcategoria", b =>
                {
                    b.Property<int>("IdSub")
                        .HasColumnType("int")
                        .HasColumnName("ID_SUB");

                    b.Property<int>("IdCat")
                        .HasColumnType("int")
                        .HasColumnName("ID_CAT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NOMBRE");

                    b.HasKey("IdSub");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("IdSub"), false);

                    b.HasIndex(new[] { "IdCat" }, "POSEE_FK");

                    b.ToTable("SUBCATEGORIAS", (string)null);
                });

            modelBuilder.Entity("Categoriza", b =>
                {
                    b.HasOne("bad115_backend.Models.Producto", null)
                        .WithMany()
                        .HasForeignKey("IdProd")
                        .IsRequired()
                        .HasConstraintName("FK_CATEGORI_CATEGORIZ_PRODUCTO");

                    b.HasOne("bad115_backend.Models.Subcategoria", null)
                        .WithMany()
                        .HasForeignKey("IdSub")
                        .IsRequired()
                        .HasConstraintName("FK_CATEGORI_CATEGORIZ_SUBCATEG");
                });

            modelBuilder.Entity("Provee", b =>
                {
                    b.HasOne("bad115_backend.Models.Producto", null)
                        .WithMany()
                        .HasForeignKey("IdProd")
                        .IsRequired()
                        .HasConstraintName("FK_PROVEE_PROVEE_PRODUCTO");

                    b.HasOne("bad115_backend.Models.Proveedor", null)
                        .WithMany()
                        .HasForeignKey("IdProv")
                        .IsRequired()
                        .HasConstraintName("FK_PROVEE_PROVEE2_PROVEEDO");
                });

            modelBuilder.Entity("bad115_backend.Models.Almacena", b =>
                {
                    b.HasOne("bad115_backend.Models.Bodega", "IdBodegaNavigation")
                        .WithMany("Almacenas")
                        .HasForeignKey("IdBodega")
                        .IsRequired()
                        .HasConstraintName("FK_ALMACENA_ALMACENA2_BODEGA");

                    b.HasOne("bad115_backend.Models.Producto", "IdProdNavigation")
                        .WithMany("Almacenas")
                        .HasForeignKey("IdProd")
                        .IsRequired()
                        .HasConstraintName("FK_ALMACENA_ALMACENA_PRODUCTO");

                    b.Navigation("IdBodegaNavigation");

                    b.Navigation("IdProdNavigation");
                });

            modelBuilder.Entity("bad115_backend.Models.Envio", b =>
                {
                    b.HasOne("bad115_backend.Models.Pedido", "IdPedNavigation")
                        .WithMany("Envios")
                        .HasForeignKey("IdPed")
                        .IsRequired()
                        .HasConstraintName("FK_ENVIO_PROGRAMA_PEDIDO");

                    b.Navigation("IdPedNavigation");
                });

            modelBuilder.Entity("bad115_backend.Models.Factura", b =>
                {
                    b.HasOne("bad115_backend.Models.Pedido", "IdPedNavigation")
                        .WithMany("Facturas")
                        .HasForeignKey("IdPed")
                        .IsRequired()
                        .HasConstraintName("FK_FACTURA_EMITE_PEDIDO");

                    b.Navigation("IdPedNavigation");
                });

            modelBuilder.Entity("bad115_backend.Models.Pago", b =>
                {
                    b.HasOne("bad115_backend.Models.Factura", "IdFacNavigation")
                        .WithMany("Pagos")
                        .HasForeignKey("IdFac")
                        .IsRequired()
                        .HasConstraintName("FK_PAGOS_TIENE_FACTURA");

                    b.Navigation("IdFacNavigation");
                });

            modelBuilder.Entity("bad115_backend.Models.Pedido", b =>
                {
                    b.HasOne("bad115_backend.Models.Cliente", "IdCliNavigation")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCli")
                        .IsRequired()
                        .HasConstraintName("FK_PEDIDO_REALIZA_CLIENTE");

                    b.Navigation("IdCliNavigation");
                });

            modelBuilder.Entity("bad115_backend.Models.Pedidoproducto", b =>
                {
                    b.HasOne("bad115_backend.Models.Bodega", "IdBodegaNavigation")
                        .WithMany("Pedidoproductos")
                        .HasForeignKey("IdBodega")
                        .IsRequired()
                        .HasConstraintName("FK_PEDIDOPR_PEDIDOPRO_BODEGA");

                    b.HasOne("bad115_backend.Models.Envio", "IdEnvNavigation")
                        .WithMany("Pedidoproductos")
                        .HasForeignKey("IdEnv")
                        .IsRequired()
                        .HasConstraintName("FK_PEDIDOPR_PEDIDOPRO_ENVIO");

                    b.HasOne("bad115_backend.Models.Pedido", "IdPedNavigation")
                        .WithMany("Pedidoproductos")
                        .HasForeignKey("IdPed")
                        .IsRequired()
                        .HasConstraintName("FK_PEDIDOPR_PEDIDOPRO_PEDIDO");

                    b.HasOne("bad115_backend.Models.Producto", "IdProdNavigation")
                        .WithMany("Pedidoproductos")
                        .HasForeignKey("IdProd")
                        .IsRequired()
                        .HasConstraintName("FK_PEDIDOPR_PEDIDOPRO_PRODUCTO");

                    b.Navigation("IdBodegaNavigation");

                    b.Navigation("IdEnvNavigation");

                    b.Navigation("IdPedNavigation");

                    b.Navigation("IdProdNavigation");
                });

            modelBuilder.Entity("bad115_backend.Models.Seguimiento", b =>
                {
                    b.HasOne("bad115_backend.Models.Envio", "IdEnvNavigation")
                        .WithMany("Seguimientos")
                        .HasForeignKey("IdEnv")
                        .IsRequired()
                        .HasConstraintName("FK_SEGUIMIE_EJECUTA_ENVIO");

                    b.Navigation("IdEnvNavigation");
                });

            modelBuilder.Entity("bad115_backend.Models.Subcategoria", b =>
                {
                    b.HasOne("bad115_backend.Models.Categorium", "IdCatNavigation")
                        .WithMany("Subcategoria")
                        .HasForeignKey("IdCat")
                        .IsRequired()
                        .HasConstraintName("FK_SUBCATEG_POSEE_CATEGORI");

                    b.Navigation("IdCatNavigation");
                });

            modelBuilder.Entity("bad115_backend.Models.Bodega", b =>
                {
                    b.Navigation("Almacenas");

                    b.Navigation("Pedidoproductos");
                });

            modelBuilder.Entity("bad115_backend.Models.Categorium", b =>
                {
                    b.Navigation("Subcategoria");
                });

            modelBuilder.Entity("bad115_backend.Models.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("bad115_backend.Models.Envio", b =>
                {
                    b.Navigation("Pedidoproductos");

                    b.Navigation("Seguimientos");
                });

            modelBuilder.Entity("bad115_backend.Models.Factura", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("bad115_backend.Models.Pedido", b =>
                {
                    b.Navigation("Envios");

                    b.Navigation("Facturas");

                    b.Navigation("Pedidoproductos");
                });

            modelBuilder.Entity("bad115_backend.Models.Producto", b =>
                {
                    b.Navigation("Almacenas");

                    b.Navigation("Pedidoproductos");
                });
#pragma warning restore 612, 618
        }
    }
}
