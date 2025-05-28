using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace safeheat_backend_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class safeheat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SH_ABRIGOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CapacidadeTotal = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CapacidadeAtual = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_ABRIGOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SH_REGISTOS_ENTRADA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomePessoa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    AbrigoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SH_REGISTOS_ENTRADA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SH_REGISTOS_ENTRADA_SH_ABRIGOS_AbrigoId",
                        column: x => x.AbrigoId,
                        principalTable: "SH_ABRIGOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SH_REGISTOS_ENTRADA_AbrigoId",
                table: "SH_REGISTOS_ENTRADA",
                column: "AbrigoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SH_REGISTOS_ENTRADA");

            migrationBuilder.DropTable(
                name: "SH_ABRIGOS");
        }
    }
}
