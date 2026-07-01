using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arauco.ProjectHub.Infrastructure.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class EsquemaInicialCu002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "negocio",
                columns: table => new
                {
                    identificador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_negocio", x => x.identificador);
                    table.CheckConstraint("CK_negocio_nombre_no_vacio", "LEN(LTRIM(RTRIM([nombre]))) > 0");
                });

            migrationBuilder.CreateTable(
                name: "iniciativa",
                columns: table => new
                {
                    identificador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    negocio_identificador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    objetivo = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    justificacion = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    beneficio_esperado = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iniciativa", x => x.identificador);
                    table.CheckConstraint("CK_iniciativa_nombre_no_vacio", "LEN(LTRIM(RTRIM([nombre]))) > 0");
                    table.CheckConstraint("CK_iniciativa_objetivo_no_vacio", "LEN(LTRIM(RTRIM([objetivo]))) > 0");
                    table.ForeignKey(
                        name: "FK_iniciativa_negocio_negocio_identificador",
                        column: x => x.negocio_identificador,
                        principalTable: "negocio",
                        principalColumn: "identificador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "participante",
                columns: table => new
                {
                    identificador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    iniciativa_identificador = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    identificacion_persona_o_equipo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    rol_participacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    identificador_tenant = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    object_identifier = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participante", x => x.identificador);
                    table.CheckConstraint("CK_participante_identidad_corporativa_conjunta", "([identificador_tenant] IS NULL AND [object_identifier] IS NULL) OR ([identificador_tenant] IS NOT NULL AND [object_identifier] IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_participante_iniciativa_iniciativa_identificador",
                        column: x => x.iniciativa_identificador,
                        principalTable: "iniciativa",
                        principalColumn: "identificador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_iniciativa_negocio_identificador",
                table: "iniciativa",
                column: "negocio_identificador");

            migrationBuilder.CreateIndex(
                name: "IX_participante_iniciativa_identificador",
                table: "participante",
                column: "iniciativa_identificador");

            migrationBuilder.CreateIndex(
                name: "UX_participante_identidad_corporativa",
                table: "participante",
                columns: new[] { "iniciativa_identificador", "identificador_tenant", "object_identifier" },
                unique: true,
                filter: "[identificador_tenant] IS NOT NULL AND [object_identifier] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "participante");

            migrationBuilder.DropTable(
                name: "iniciativa");

            migrationBuilder.DropTable(
                name: "negocio");
        }
    }
}
