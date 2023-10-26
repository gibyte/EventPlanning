using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace epControl.Migrations
{
    /// <inheritdoc />
    public partial class Url : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Nomenclature");

            migrationBuilder.CreateTable(
                name: "NomenclatureLink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Link = table.Column<string>(type: "TEXT", nullable: false),
                    NomenclatureId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomenclatureLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NomenclatureLink_Nomenclature_NomenclatureId",
                        column: x => x.NomenclatureId,
                        principalTable: "Nomenclature",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NomenclatureLink_NomenclatureId",
                table: "NomenclatureLink",
                column: "NomenclatureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NomenclatureLink");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Nomenclature",
                type: "TEXT",
                nullable: true);
        }
    }
}
