using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchList.Migrations.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class WatchItem_Add_Index_For_TitleNormalized : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WatchItem_TitleNormalized",
                table: "WatchItem",
                column: "TitleNormalized");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WatchItem_TitleNormalized",
                table: "WatchItem");
        }
    }
}
