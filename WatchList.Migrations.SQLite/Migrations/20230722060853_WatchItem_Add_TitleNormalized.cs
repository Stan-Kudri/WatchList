using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchList.Migrations.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class WatchItem_Add_TitleNormalized : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TitleNormalized",
                table: "WatchItem",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleNormalized",
                table: "WatchItem");
        }
    }
}
