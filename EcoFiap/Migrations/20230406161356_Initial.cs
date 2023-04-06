using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoFiap.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COLETOR",
                columns: table => new
                {
                    COLETORID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOMECOLETOR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ENDERECOCOLETOR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EMAILCOLETOR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TELEFONECOLETOR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COLETOR", x => x.COLETORID);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    USUARIOID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOMEUSUARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ENDERECOUSUARIO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    EMAILSUARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TELEFONEUSUARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.USUARIOID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COLETOR");

            migrationBuilder.DropTable(
                name: "USUARIO");
        }
    }
}
