using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bad115_backend.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BODEGA",
                columns: table => new
                {
                    ID_BODEGA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DIRECCION = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    LATITUDE = table.Column<decimal>(type: "decimal(15,12)", nullable: false),
                    LONGITUD = table.Column<decimal>(type: "decimal(15,12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BODEGA", x => x.ID_BODEGA)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIA",
                columns: table => new
                {
                    ID_CAT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIA", x => x.ID_CAT)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    ID_CLI = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRES = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    APELLIDOS = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DIRECCION = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CORREO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FECHA_NACIMIENTO = table.Column<DateTime>(type: "datetime", nullable: true),
                    SEXO = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.ID_CLI)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTO",
                columns: table => new
                {
                    ID_PROD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PRECIO = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MARCA = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DESCRIPCION = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTO", x => x.ID_PROD)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "PROVEEDOR",
                columns: table => new
                {
                    ID_PROV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DIRECCION = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CONTACTO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TELEFONO = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    CORREO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROVEEDOR", x => x.ID_PROV)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    ID_ROL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROL", x => x.ID_ROL)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID_USER = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    PASSWORD = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID_USER)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "SUBCATEGORIAS",
                columns: table => new
                {
                    ID_SUB = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_CAT = table.Column<int>(type: "int", nullable: false),
                    NOMBRE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBCATEGORIAS", x => x.ID_SUB)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_SUBCATEG_POSEE_CATEGORI",
                        column: x => x.ID_CAT,
                        principalTable: "CATEGORIA",
                        principalColumn: "ID_CAT");
                });

            migrationBuilder.CreateTable(
                name: "PEDIDO",
                columns: table => new
                {
                    ID_PED = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_CLI = table.Column<int>(type: "int", nullable: false),
                    CODIGO = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    FECHA = table.Column<DateTime>(type: "datetime", nullable: false),
                    ESTADO_ACTUAL = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    TOTAL = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    NOTAS = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDO", x => x.ID_PED)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_PEDIDO_REALIZA_CLIENTE",
                        column: x => x.ID_CLI,
                        principalTable: "CLIENTE",
                        principalColumn: "ID_CLI");
                });

            migrationBuilder.CreateTable(
                name: "ALMACENA",
                columns: table => new
                {
                    ID_PROD = table.Column<int>(type: "int", nullable: false),
                    ID_BODEGA = table.Column<int>(type: "int", nullable: false),
                    CANTIDAD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALMACENA", x => new { x.ID_PROD, x.ID_BODEGA })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_ALMACENA_ALMACENA2_BODEGA",
                        column: x => x.ID_BODEGA,
                        principalTable: "BODEGA",
                        principalColumn: "ID_BODEGA");
                    table.ForeignKey(
                        name: "FK_ALMACENA_ALMACENA_PRODUCTO",
                        column: x => x.ID_PROD,
                        principalTable: "PRODUCTO",
                        principalColumn: "ID_PROD");
                });

            migrationBuilder.CreateTable(
                name: "PROVEE",
                columns: table => new
                {
                    ID_PROD = table.Column<int>(type: "int", nullable: false),
                    ID_PROV = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROVEE", x => new { x.ID_PROD, x.ID_PROV })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_PROVEE_PROVEE2_PROVEEDO",
                        column: x => x.ID_PROV,
                        principalTable: "PROVEEDOR",
                        principalColumn: "ID_PROV");
                    table.ForeignKey(
                        name: "FK_PROVEE_PROVEE_PRODUCTO",
                        column: x => x.ID_PROD,
                        principalTable: "PRODUCTO",
                        principalColumn: "ID_PROD");
                });

            migrationBuilder.CreateTable(
                name: "USERS_ROLES",
                columns: table => new
                {
                    ROL_ID = table.Column<int>(type: "int", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ROL",
                        column: x => x.ROL_ID,
                        principalTable: "ROLES",
                        principalColumn: "ID_ROL");
                    table.ForeignKey(
                        name: "FK_USER",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID_USER");
                });

            migrationBuilder.CreateTable(
                name: "CATEGORIZA",
                columns: table => new
                {
                    ID_SUB = table.Column<int>(type: "int", nullable: false),
                    ID_PROD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIZA", x => new { x.ID_SUB, x.ID_PROD })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_CATEGORI_CATEGORIZ_PRODUCTO",
                        column: x => x.ID_PROD,
                        principalTable: "PRODUCTO",
                        principalColumn: "ID_PROD");
                    table.ForeignKey(
                        name: "FK_CATEGORI_CATEGORIZ_SUBCATEG",
                        column: x => x.ID_SUB,
                        principalTable: "SUBCATEGORIAS",
                        principalColumn: "ID_SUB");
                });

            migrationBuilder.CreateTable(
                name: "ENVIO",
                columns: table => new
                {
                    ID_ENV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_PED = table.Column<int>(type: "int", nullable: false),
                    CODIGO = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    FECHA = table.Column<DateTime>(type: "datetime", nullable: false),
                    DIRECCION_ORIGEN = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    DIRECCION_DESTINO = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    METODO_ENVIO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ESTADO_ACTUAL = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    FECHA_ENTREGA_ESTIMADA = table.Column<DateTime>(type: "datetime", nullable: true),
                    COSTO_ENVIO = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    NOTAS = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENVIO", x => x.ID_ENV)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_ENVIO_PROGRAMA_PEDIDO",
                        column: x => x.ID_PED,
                        principalTable: "PEDIDO",
                        principalColumn: "ID_PED");
                });

            migrationBuilder.CreateTable(
                name: "FACTURA",
                columns: table => new
                {
                    ID_FAC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_PED = table.Column<int>(type: "int", nullable: false),
                    CODIGO = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    FECHA_EMISION = table.Column<DateTime>(type: "datetime", nullable: false),
                    DIRECCION_FACTURACION = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    SUBTOTAL = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IMPUESTOS = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DESCUENTOS = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TOTAL = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    METODO_PAGO = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ESTADO_PAGO = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACTURA", x => x.ID_FAC)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_FACTURA_EMITE_PEDIDO",
                        column: x => x.ID_PED,
                        principalTable: "PEDIDO",
                        principalColumn: "ID_PED");
                });

            migrationBuilder.CreateTable(
                name: "PEDIDOPRODUCTO",
                columns: table => new
                {
                    ID_PROD = table.Column<int>(type: "int", nullable: false),
                    ID_PED = table.Column<int>(type: "int", nullable: false),
                    ID_ENV = table.Column<int>(type: "int", nullable: true),
                    ID_BODEGA = table.Column<int>(type: "int", nullable: true),
                    DESCUENTO = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    NOTAS = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CANTIDAD = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDOPRODUCTO", x => new { x.ID_PROD, x.ID_PED })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_PEDIDOPR_PEDIDOPRO_BODEGA",
                        column: x => x.ID_BODEGA,
                        principalTable: "BODEGA",
                        principalColumn: "ID_BODEGA");
                    table.ForeignKey(
                        name: "FK_PEDIDOPR_PEDIDOPRO_ENVIO",
                        column: x => x.ID_ENV,
                        principalTable: "ENVIO",
                        principalColumn: "ID_ENV");
                    table.ForeignKey(
                        name: "FK_PEDIDOPR_PEDIDOPRO_PEDIDO",
                        column: x => x.ID_PED,
                        principalTable: "PEDIDO",
                        principalColumn: "ID_PED");
                    table.ForeignKey(
                        name: "FK_PEDIDOPR_PEDIDOPRO_PRODUCTO",
                        column: x => x.ID_PROD,
                        principalTable: "PRODUCTO",
                        principalColumn: "ID_PROD");
                });

            migrationBuilder.CreateTable(
                name: "SEGUIMIENTO",
                columns: table => new
                {
                    ID_SEG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_ENV = table.Column<int>(type: "int", nullable: false),
                    ESTADO_ACTUAL = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    FECHA_HORA_UPDATE = table.Column<DateTime>(type: "datetime", nullable: false),
                    UBICACION_ACTUAL = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    DESCRIPCION = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    NOTAS = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    RESPONSABLE = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NIVEL_URGENCIA = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ESTADO_PREVIO = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEGUIMIENTO", x => x.ID_SEG)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_SEGUIMIE_EJECUTA_ENVIO",
                        column: x => x.ID_ENV,
                        principalTable: "ENVIO",
                        principalColumn: "ID_ENV");
                });

            migrationBuilder.CreateTable(
                name: "PAGOS",
                columns: table => new
                {
                    ID_PAG = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_FAC = table.Column<int>(type: "int", nullable: false),
                    FECHA_PAGO = table.Column<DateTime>(type: "datetime", nullable: false),
                    MONTO = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DESCRIPCION = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    ESTADO_ACTUAL = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NUM_REFERENCIA = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NOTAS = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    COLECTOR = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGOS", x => x.ID_PAG)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_PAGOS_TIENE_FACTURA",
                        column: x => x.ID_FAC,
                        principalTable: "FACTURA",
                        principalColumn: "ID_FAC");
                });

            migrationBuilder.CreateIndex(
                name: "ALMACENA_FK",
                table: "ALMACENA",
                column: "ID_PROD");

            migrationBuilder.CreateIndex(
                name: "ALMACENA2_FK",
                table: "ALMACENA",
                column: "ID_BODEGA");

            migrationBuilder.CreateIndex(
                name: "CATEGORIZA_FK",
                table: "CATEGORIZA",
                column: "ID_SUB");

            migrationBuilder.CreateIndex(
                name: "CATEGORIZA2_FK",
                table: "CATEGORIZA",
                column: "ID_PROD");

            migrationBuilder.CreateIndex(
                name: "PROGRAMA_FK",
                table: "ENVIO",
                column: "ID_PED");

            migrationBuilder.CreateIndex(
                name: "EMITE_FK",
                table: "FACTURA",
                column: "ID_PED");

            migrationBuilder.CreateIndex(
                name: "TIENE_FK",
                table: "PAGOS",
                column: "ID_FAC");

            migrationBuilder.CreateIndex(
                name: "REALIZA_FK",
                table: "PEDIDO",
                column: "ID_CLI");

            migrationBuilder.CreateIndex(
                name: "PEDIDOPRODUCTO_FK",
                table: "PEDIDOPRODUCTO",
                column: "ID_BODEGA");

            migrationBuilder.CreateIndex(
                name: "PEDIDOPRODUCTO2_FK",
                table: "PEDIDOPRODUCTO",
                column: "ID_PROD");

            migrationBuilder.CreateIndex(
                name: "PEDIDOPRODUCTO3_FK",
                table: "PEDIDOPRODUCTO",
                column: "ID_PED");

            migrationBuilder.CreateIndex(
                name: "PEDIDOPRODUCTO4_FK",
                table: "PEDIDOPRODUCTO",
                column: "ID_ENV");

            migrationBuilder.CreateIndex(
                name: "PROVEE_FK",
                table: "PROVEE",
                column: "ID_PROD");

            migrationBuilder.CreateIndex(
                name: "PROVEE2_FK",
                table: "PROVEE",
                column: "ID_PROV");

            migrationBuilder.CreateIndex(
                name: "EJECUTA_FK",
                table: "SEGUIMIENTO",
                column: "ID_ENV");

            migrationBuilder.CreateIndex(
                name: "POSEE_FK",
                table: "SUBCATEGORIAS",
                column: "ID_CAT");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLES_ROL_ID",
                table: "USERS_ROLES",
                column: "ROL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLES_USER_ID",
                table: "USERS_ROLES",
                column: "USER_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALMACENA");

            migrationBuilder.DropTable(
                name: "CATEGORIZA");

            migrationBuilder.DropTable(
                name: "PAGOS");

            migrationBuilder.DropTable(
                name: "PEDIDOPRODUCTO");

            migrationBuilder.DropTable(
                name: "PROVEE");

            migrationBuilder.DropTable(
                name: "SEGUIMIENTO");

            migrationBuilder.DropTable(
                name: "USERS_ROLES");

            migrationBuilder.DropTable(
                name: "SUBCATEGORIAS");

            migrationBuilder.DropTable(
                name: "FACTURA");

            migrationBuilder.DropTable(
                name: "BODEGA");

            migrationBuilder.DropTable(
                name: "PROVEEDOR");

            migrationBuilder.DropTable(
                name: "PRODUCTO");

            migrationBuilder.DropTable(
                name: "ENVIO");

            migrationBuilder.DropTable(
                name: "ROLES");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "CATEGORIA");

            migrationBuilder.DropTable(
                name: "PEDIDO");

            migrationBuilder.DropTable(
                name: "CLIENTE");
        }
    }
}
