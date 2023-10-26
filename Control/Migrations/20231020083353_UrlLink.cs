using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace epControl.Migrations
{
    /// <inheritdoc />
    public partial class UrlLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nomenclature_Events_EventId",
                table: "Nomenclature");

            migrationBuilder.DropForeignKey(
                name: "FK_NomenclatureLink_Nomenclature_NomenclatureId",
                table: "NomenclatureLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NomenclatureLink",
                table: "NomenclatureLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nomenclature",
                table: "Nomenclature");

            migrationBuilder.RenameTable(
                name: "NomenclatureLink",
                newName: "NomenclatureLinks");

            migrationBuilder.RenameTable(
                name: "Nomenclature",
                newName: "Nomenclatures");

            migrationBuilder.RenameIndex(
                name: "IX_NomenclatureLink_NomenclatureId",
                table: "NomenclatureLinks",
                newName: "IX_NomenclatureLinks_NomenclatureId");

            migrationBuilder.RenameIndex(
                name: "IX_Nomenclature_EventId",
                table: "Nomenclatures",
                newName: "IX_Nomenclatures_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NomenclatureLinks",
                table: "NomenclatureLinks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nomenclatures",
                table: "Nomenclatures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NomenclatureLinks_Nomenclatures_NomenclatureId",
                table: "NomenclatureLinks",
                column: "NomenclatureId",
                principalTable: "Nomenclatures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nomenclatures_Events_EventId",
                table: "Nomenclatures",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NomenclatureLinks_Nomenclatures_NomenclatureId",
                table: "NomenclatureLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Nomenclatures_Events_EventId",
                table: "Nomenclatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nomenclatures",
                table: "Nomenclatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NomenclatureLinks",
                table: "NomenclatureLinks");

            migrationBuilder.RenameTable(
                name: "Nomenclatures",
                newName: "Nomenclature");

            migrationBuilder.RenameTable(
                name: "NomenclatureLinks",
                newName: "NomenclatureLink");

            migrationBuilder.RenameIndex(
                name: "IX_Nomenclatures_EventId",
                table: "Nomenclature",
                newName: "IX_Nomenclature_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_NomenclatureLinks_NomenclatureId",
                table: "NomenclatureLink",
                newName: "IX_NomenclatureLink_NomenclatureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nomenclature",
                table: "Nomenclature",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NomenclatureLink",
                table: "NomenclatureLink",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nomenclature_Events_EventId",
                table: "Nomenclature",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NomenclatureLink_Nomenclature_NomenclatureId",
                table: "NomenclatureLink",
                column: "NomenclatureId",
                principalTable: "Nomenclature",
                principalColumn: "Id");
        }
    }
}
