using Microsoft.EntityFrameworkCore.Migrations;

namespace apiBicicletas.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Bicicleta",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitud",
                table: "Bicicleta",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "Bicicleta",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(nullable: false),
                    Lastname = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bicicleta_PersonaId",
                table: "Bicicleta",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bicicleta_Persona_PersonaId",
                table: "Bicicleta",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bicicleta_Persona_PersonaId",
                table: "Bicicleta");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Bicicleta_PersonaId",
                table: "Bicicleta");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Bicicleta");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Bicicleta");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Bicicleta");
        }
    }
}
