using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Nikom.Migrations
{
    /// <inheritdoc />
    public partial class updatetblProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "tblPart");

            migrationBuilder.CreateTable(
                name: "tblPartPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PartId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPartPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPartPhoto_tblPart_PartId",
                        column: x => x.PartId,
                        principalTable: "tblPart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblPartPhoto_PartId",
                table: "tblPartPhoto",
                column: "PartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblPartPhoto");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "tblPart",
                type: "text",
                nullable: true);
        }
    }
}
